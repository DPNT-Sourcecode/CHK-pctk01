using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BeFaster.App.Solutions.CHK
{
    public static class Parse
    {
        public static Dictionary<char, int> ParseSkus(string skus)
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
                var items = new Dictionary<char, int>();

                foreach (char it in skus)
                {
                    if (items.ContainsKey(it))
                    {
                        items[it]++;
                    }
                    else
                    {
                        items.Add(it, 1);
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

