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
                new SpecialOfferPrice(items.Find(i => i.Name.Equals("A")), 5, 200),
                new SpecialOfferPrice(items.Find(i => i.Name.Equals("B")), 2, 45),
                new SpecialOfferPrice(items.Find(i => i.Name.Equals("H")), 5, 45),
                new SpecialOfferPrice(items.Find(i => i.Name.Equals("H")), 10, 80),
                new SpecialOfferPrice(items.Find(i => i.Name.Equals("K")), 2, 150),
                new SpecialOfferPrice(items.Find(i => i.Name.Equals("P")), 5, 200),
                new SpecialOfferPrice(items.Find(i => i.Name.Equals("Q")), 3, 80),
                new SpecialOfferPrice(items.Find(i => i.Name.Equals("V")), 2, 90),
                new SpecialOfferPrice(items.Find(i => i.Name.Equals("V")), 3, 130),
            };
        }

        public List<SpecialOfferItem> StartSpecialOffersItems(List<Item> items)
        {
            return new List<SpecialOfferItem>()
            {
                new SpecialOfferItem(items.Find(i => i.Name.Equals("E")), 2, items.Find(i => i.Name.Equals("B"))),
                new SpecialOfferItem(items.Find(i => i.Name.Equals("F")), 3, items.Find(i => i.Name.Equals("F"))),
                new SpecialOfferItem(items.Find(i => i.Name.Equals("N")), 3, items.Find(i => i.Name.Equals("M"))),
                new SpecialOfferItem(items.Find(i => i.Name.Equals("R")), 3, items.Find(i => i.Name.Equals("Q"))),
                new SpecialOfferItem(items.Find(i => i.Name.Equals("U")), 4, items.Find(i => i.Name.Equals("U"))),
            };
        }

        public List<SpecialOfferAnyGroup> StartSpecialOffersAnyGroup(List<Item> items)
        {
            return new List<SpecialOfferAnyGroup>()
            {
                new SpecialOfferAnyGroup(
                        new List<Item>() {  items.Find(i => i.Name.Equals("S")), 
                                            items.Find(i => i.Name.Equals("T")), 
                                            items.Find(i => i.Name.Equals("X")), 
                                            items.Find(i => i.Name.Equals("Y")),
                                            items.Find(i => i.Name.Equals("Z")) },
                        3,
                        45
                    ),

            };
        }
    }
}
