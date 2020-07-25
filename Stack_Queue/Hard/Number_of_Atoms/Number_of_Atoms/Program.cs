using System.Collections.Generic;
using System.Text;

namespace Number_of_Atoms
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var formula = "K4(ON(SO3)4)2";
            var result = CountOfAtoms(formula);
        }

        /// <summary>
        /// Time Complexity: O(NlogN) where N is letters in formula
        /// Space Complexity: O(NlogN) 
        /// </summary>
        private static string CountOfAtoms(string formula)
        {
            var stack = new Stack<Dictionary<string, int>>();
            var map = new Dictionary<string, int>();
            int i = 0;
            int n = formula.Length;
            while (i < n)
            {
                var ch = formula[i];
                i++;
                if (ch == '(') // start new bracket 
                {
                    stack.Push(map);
                    map = new Dictionary<string, int>();
                }
                else if (ch == ')') // merge into previous bracket 
                {
                    int val = 0;
                    while (i < n && char.IsDigit(formula[i]))
                        val = val * 10 + formula[i++] - '0';

                    if (val == 0)
                        val = 1;

                    if (stack.Count > 0)
                    {
                        var current = map;
                        map = stack.Pop();
                        foreach (var key in current.Keys) // merge
                        {
                            if (map.ContainsKey(key))
                            {
                                map[key] += current[key] * val;
                            }
                            else
                            {
                                map.Add(key, current[key] * val);
                            }
                        }
                    }
                }
                else // letter case
                {
                    var start = i - 1;
                    while (i < n && char.IsLower(formula[i])) // sub letter part
                    {
                        i++;
                    }

                    var s = formula.Substring(start, i - start);
                    var val = 0;
                    while (i < n && char.IsDigit(formula[i])) // number part
                    {
                        val = val * 10 + formula[i++] - '0';
                    }

                    if (val == 0)
                        val = 1;

                    if (map.ContainsKey(s))
                    {
                        map[s] += val;
                    }
                    else
                    {
                        map.Add(s, val);
                    }
                }
            }
            var sb = new StringBuilder();
            var list = new List<string>(map.Keys);
            list.Sort();
            foreach (string key in list)
            {
                sb.Append(key);
                if (map[key] > 1)
                    sb.Append(map[key]);
            }

            return sb.ToString();
        }
    }
}
