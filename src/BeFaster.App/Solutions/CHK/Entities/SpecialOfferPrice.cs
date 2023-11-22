using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Solutions.CHK
{
    public class SpecialOfferPrice : ISpecialOffer
    {
        public Item ItemOffer { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }

        public SpecialOfferPrice()
        {
            ItemOffer = new Item();
            Quantity = 0;
            TotalPrice = 0;
        }

        public SpecialOfferPrice(Item itemOffer, int quantity, int price)
        {
            ItemOffer = itemOffer;
            Quantity = quantity;
            TotalPrice = price;
        }
    }
}
