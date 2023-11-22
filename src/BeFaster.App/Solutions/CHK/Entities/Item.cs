using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Solutions.CHK
{
    public class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Item()
        {
            Name = string.Empty;
            Price = 0;
        }

        public Item(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}
