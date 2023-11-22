using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int ComputePrice(string skus)
        {
            var repository = new Repository();
            var itemsStock = repository.StartShop();
            var specialOffersPrice = repository.StartSpecialOffersPrices(itemsStock);

            return 0;
        }
    }
}

