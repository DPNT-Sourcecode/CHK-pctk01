﻿using System;
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
                new Item("E", 40)
            };
        }

        public List<SpecialOfferPrice> StartSpecialOffersPrices(List<Item> items)
        {
            return new List<SpecialOfferPrice>()
            {
                new SpecialOfferPrice(items.Find(i => i.Name.Equals("A")), 3, 130),
                new SpecialOfferPrice(items.Find(i => i.Name.Equals("B")), 2, 45),
                new SpecialOfferPrice(items.Find(i => i.Name.Equals("A")), 5, 200)
            };
        }
    }
}