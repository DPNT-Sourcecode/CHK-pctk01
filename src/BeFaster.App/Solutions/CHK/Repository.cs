using BeFaster.App.Solutions.CHK.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Solutions.CHK
{
    public class Repository
    {
        public List<Item> StartShop()
        {
            return new List<Item>
            {
                new Item("A", 50),
                new Item("B", 30),
                new Item("C", 20),
                new Item("D", 15),
                new Item("E", 40),
                new Item("F", 10),
                new Item("G", 20),
                new Item("H", 10),
                new Item("I", 35),
                new Item("J", 60),
                new Item("K", 80),
                new Item("L", 90),
                new Item("M", 15),
                new Item("N", 40),
                new Item("O", 10),
                new Item("P", 50),
                new Item("Q", 30),
                new Item("R", 50),
                new Item("S", 30),
                new Item("T", 20),
                new Item("U", 40),
                new Item("V", 50),
                new Item("W", 20),
                new Item("X", 90),
                new Item("Y", 10),
                new Item("Z", 50)
            };
        }

        public List<SpecialOfferPrice> StartSpecialOffersPrices(List<Item> items)
        {
            return new List<SpecialOfferPrice>()
            {
                new SpecialOfferPrice(items.Find(i => i.Name.Equals("A")), 3, 130),
                new SpecialOfferPrice(items.Find(i => i.Name.Equals("B")), 2, 45),
                new SpecialOfferPrice(items.Find(i => i.Name.Equals("A")), 5, 200),
            };
        }

        public List<SpecialOfferItem> StartSpecialOffersItems(List<Item> items)
        {
            return new List<SpecialOfferItem>()
            {
                new SpecialOfferItem(items.Find(i => i.Name.Equals("E")), 2, items.Find(i => i.Name.Equals("B"))),
                new SpecialOfferItem(items.Find(i => i.Name.Equals("F")), 3, items.Find(i => i.Name.Equals("F")))
            };
        }
    }
}
