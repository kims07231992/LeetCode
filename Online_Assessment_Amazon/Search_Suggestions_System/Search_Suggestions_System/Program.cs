using System.Collections.Generic;
using System.Linq;

namespace Search_Suggestions_System
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var products = new string[] { "mobile", "mouse", "moneypot", "monitor", "mousepad" };
            var searchWord = "mouse";

            var result = SuggestedProducts(products, searchWord);
        }

        /// <summary>
        /// Time Complexity: O(NlogN + N*L) where N is number of given products and L is length of searchWord
        /// Space Complexity: O(N)
        /// </summary>
        private static IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            var result = new List<IList<string>>();
            var filteredProducts = products
                .Where(p => p.StartsWith(searchWord.First()))
                .OrderBy(p => p)
                .ToList();
            for (int i = 1; i <= searchWord.Length; i++)
            {
                string keywords = searchWord.Substring(0, i);
                filteredProducts = filteredProducts
                    .Where(p => p.StartsWith(keywords))
                    .ToList();
                result.Add(filteredProducts.Take(3).ToList());
            }

            return result;
        }
    }
}
