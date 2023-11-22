using BeFaster.Runner.Exceptions;
using System;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int ComputePrice(string skus)
        {
            var repository = new Repository();
            var itemsStock = repository.StartShop();
            var specialOffersPrice = repository.StartSpecialOffersPrices(itemsStock);

            try 
            { 
                var selectedItems = Parse.ParseSkus(skus, itemsStock);
            }
            catch (NullReferenceException)
            {
                return 0;
            }
            catch (ArgumentException)
            {
                return -1;
            }

            return 0;
        }
    }
}


