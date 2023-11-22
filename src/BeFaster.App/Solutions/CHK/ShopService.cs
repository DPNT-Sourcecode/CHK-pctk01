﻿using BeFaster.App.Solutions.CHK.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Solutions.CHK
{
    public class ShopService
    {
        public int CalculateTotalPrice(Dictionary<Item, int> items, List<SpecialOfferPrice> offersPrices, List<SpecialOfferItem> offersItems)
        {
            ProcessSpecialOffersWithFreeItems(items, offersItems);
            var totalPrice = ProcessSpecialOffersWithBestPrices(items, offersPrices);

            foreach (var it in items)
            {
                totalPrice += it.Key.Price * it.Value;
            }

            return totalPrice;
        }
    }

    private int ProcessSpecialOffersWithBestPrices(Dictionary<Item, int> items, List<SpecialOfferPrice> offers)
    {
        var allAppliedOffers = new List<SpecialOfferPrice>();
        int totalPrice = 0;

        //what offers applies to the checkout list
        foreach (var offer in offers)
        {
            if (items.ContainsKey(offer.ItemOffer) && items[offer.ItemOffer] >= offer.Quantity)
            {
                allAppliedOffers.Add(offer);
            }
        }

        while (allAppliedOffers.Count > 0)
        {
            var bestOffer = CalculateBestOfferPrice(allAppliedOffers);

            int timesApplied = items[bestOffer.ItemOffer] / bestOffer.Quantity;

            if (timesApplied > 0)
            {
                items[bestOffer.ItemOffer] = items[bestOffer.ItemOffer] - bestOffer.Quantity * timesApplied;

                totalPrice += bestOffer.TotalPrice * timesApplied;
            }

            allAppliedOffers.Remove(bestOffer);
        }

        return totalPrice;
    }

    private SpecialOfferPrice CalculateBestOfferPrice(List<SpecialOfferPrice> offers)
    {
        decimal bestPrice = decimal.MaxValue;
        var bestOffer = new SpecialOfferPrice();

        foreach (var offer in offers)
        {
            decimal price = offer.TotalPrice / offer.Quantity;

            if (price < bestPrice)
            {
                bestPrice = price;
                bestOffer = offer;
            }
        }

        return bestOffer;
    }
}