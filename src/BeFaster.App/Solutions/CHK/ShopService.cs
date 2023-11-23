using BeFaster.App.Solutions.CHK.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Solutions.CHK
{
    public class ShopService
    {
        public int CalculateTotalPrice(Dictionary<Item, int> items, List<SpecialOfferPrice> offersPrices, List<SpecialOfferItem> offersItems, List<SpecialOfferAnyGroup> offersGroup)
        {
            ProcessSpecialOffersWithFreeItems(items, offersItems);
            var totalPrice = ProcessSpecialOffersWithBestPrices(items, offersPrices);
            totalPrice += ProcessSpecialOffersWithAnyGroup(items, offersGroup);

            foreach (var it in items)
            {
                totalPrice += it.Key.Price * it.Value;
            }

            return totalPrice;
        }

        private void ProcessSpecialOffersWithFreeItems(Dictionary<Item, int> items, List<SpecialOfferItem> offers)
        {
            var allAppliedOffers = new List<SpecialOfferItem>();

            foreach (var it in items)
            {
                var offer = offers.Find(o => o.ItemOffer == it.Key && o.Quantity <= it.Value && items.Any(x => x.Key == o.FreeItem));

                if (offer != null)
                {
                    allAppliedOffers.Add(offer);
                }
            }

            if (allAppliedOffers.Count > 0)
            {
                foreach (var offer in allAppliedOffers)
                {
                    items[offer.FreeItem] = Math.Max(items[offer.FreeItem] - (items[offer.ItemOffer] / offer.Quantity), 0);
                }
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

        private int ProcessSpecialOffersWithAnyGroup(Dictionary<Item, int> items, List<SpecialOfferAnyGroup> offers)
        {
            int totalPrice = 0;

            foreach (var offer in offers)
            {
                var itemsToApplyOffer = new List<Item>();
                int totalNumberOfItems = 0;

                var itemsOrderedByExpensivePrice = offer.Items.OrderByDescending(x => x.Price);

                foreach(var it in itemsOrderedByExpensivePrice)
                {
                    if (items.ContainsKey(it))
                    {
                        totalNumberOfItems += items[it];
                        itemsToApplyOffer.Add(it);
                    }
                }

                if(totalNumberOfItems >= offer.Quantity)
                {
                    int timesApplied = totalNumberOfItems / offer.Quantity; 
                    int numberOfItemsToRemove = timesApplied * offer.Quantity;

                    foreach(var it in itemsToApplyOffer)
                    {
                        if (items[it] >= numberOfItemsToRemove)
                        {
                            items[it] -= numberOfItemsToRemove;
                            break;
                        }
                        else
                        {
                            numberOfItemsToRemove -= items[it];
                            items[it] = 0;
                        }
                    }

                    totalPrice += timesApplied * offer.TotalPrice;
                }
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
}

