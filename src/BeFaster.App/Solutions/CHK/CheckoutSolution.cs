using BeFaster.App.Solutions.CHK.Entities;
using BeFaster.Runner.Exceptions;
using System;
using System.Collections.Generic;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int ComputePrice(string skus)
        {
            var repository = new Repository();
            var itemsStock = repository.StartShop();
            var specialOffersPrices = repository.StartSpecialOffersPrices(itemsStock);
            var specialOffersItems = repository.StartSpecialOffersItems(itemsStock);
            var specialOffersAnyGroup = repository.StartSpecialOffersAnyGroup(itemsStock);

            var selectedItems = new Dictionary<Item, int>();

            try 
            { 
                selectedItems = Parse.ParseSkus(skus, itemsStock);
            }
            catch (NullReferenceException)
            {
                return 0;
            }
            catch (ArgumentException)
            {
                return -1;
            }

            var shopService = new ShopService();

            return shopService.CalculateTotalPrice(selectedItems, specialOffersPrices, specialOffersItems, specialOffersAnyGroup);
        }
    }
}
