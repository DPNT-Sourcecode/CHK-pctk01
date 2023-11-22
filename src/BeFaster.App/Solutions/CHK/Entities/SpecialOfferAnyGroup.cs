using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Solutions.CHK.Entities
{
    public class SpecialOfferAnyGroup
    {
        public List<Item> Items { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }

        public SpecialOfferAnyGroup(List<Item> items, int quantity, int totalPrice)
        {
            Items = items;
            Quantity = quantity;
            TotalPrice = totalPrice;
        }
    }
}
