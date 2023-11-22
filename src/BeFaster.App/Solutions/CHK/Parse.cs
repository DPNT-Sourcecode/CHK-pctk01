using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BeFaster.App.Solutions.CHK
{
    internal static class Parse
    {
        internal static Dictionary<Item, int> ParseSkus(string skus, List<Item> itemsStock)
        {
            if (String.IsNullOrEmpty(skus) || String.IsNullOrWhiteSpace(skus))
            {
                throw new NullReferenceException("Invalid input.");
            }

            string pattern = @"[A-Z]+";

            var regex = new Regex(pattern);

            Match match = regex.Match(skus);

            if (match.Success)
            {
                var items = new Dictionary<Item, int>();

                foreach (char it in skus)
                {
                    var item = itemsStock.FirstOrDefault(x => x.Name.Equals(it.ToString()));

                    if(item == null)
                    {
                        throw new ArgumentException("Invalid input.");
                    }
                    else if (items.ContainsKey(item))
                    {
                        items[item]++;
                    }
                    else
                    {
                        items.Add(item, 1);
                    }
                }

                return items;
            }
            else
            {
                throw new ArgumentException("Invalid input.");
            }
        }
    }
}
