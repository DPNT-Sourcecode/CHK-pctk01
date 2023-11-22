using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Solutions.CHK.Entities
{
    public class SpecialOfferItem : ISpecialOffer
    {
        public Item ItemOffer { get; set; }
        public int Quantity { get; set; }
        public Item FreeItem { get; set; }

        public SpecialOfferItem(Item itemOffer, int quantity, Item freeItem)
        {
            ItemOffer = itemOffer;
            Quantity = quantity;
            FreeItem = freeItem;
        }
    }
}
