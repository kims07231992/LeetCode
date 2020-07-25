using System;
using System.Collections.Generic;
using System.Linq;

namespace Analyze_User_Website_Visit_Pattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var username = new string[] { "h", "eiy", "cq", "h", "cq", "txldsscx", "cq", "txldsscx", "h", "cq", "cq" };
            var timestamp = new int[] { 527896567, 334462937, 517687281, 134127993, 859112386, 159548699, 51100299, 444082139, 926837079, 317455832, 411747930 };
            var website = new string[] { "hibympufi", "hibympufi", "hibympufi", "hibympufi", "hibympufi", "hibympufi", "hibympufi", "hibympufi", "yljmntrclw", "hibympufi", "yljmntrclw" };

            var result = MostVisitedPattern(username, timestamp, website);
        }

        /// <summary>
        /// Time Complexity: O(N^3) where N is number of logs
        /// Space Complexity: O(N)
        /// </summary>
        private static IList<string> MostVisitedPattern(string[] username, int[] timestamp, string[] website)
        {
            int n = username.Length;
            var userLogMap = new Dictionary<string, List<Tuple<int, string>>>(); // Key: user, Value: timestamp and website 
            for (int i = 0; i < n; i++)
            {
                var user = username[i];
                var time = timestamp[i];
                var web = website[i];
                if (!userLogMap.ContainsKey(user))
                    userLogMap.Add(user, new List<Tuple<int, string>>());

                userLogMap[user].Add(new Tuple<int, string>(time, web));
            }

            var sequenceMap = new Dictionary<string, int>(); // Key: sequence, Value: count
            var maxSequence = string.Empty;
            var maxCount = 0;
            foreach (var userLog in userLogMap)
            {
                userLog.Value.Sort((x, y) => x.Item1.CompareTo(y.Item1));
                var logs = userLog.Value;
                var seen = new HashSet<string>(); // to avoid sequence from same user
                for (int i = 0; i < logs.Count; i++)
                {
                    for (int j = i + 1; j < logs.Count; j++)
                    {
                        for (int k = j + 1; k < logs.Count; k++)
                        {
                            var sequence = $"{logs[i].Item2} {logs[j].Item2} {logs[k].Item2}";
                            if (!seen.Contains(sequence))
                            {
                                seen.Add(sequence);
                                if (!sequenceMap.TryAdd(sequence, 1))
                                    sequenceMap[sequence]++;
                            }

                            if (sequenceMap[sequence] > maxCount ||
                                (sequenceMap[sequence] == maxCount && sequence.CompareTo(maxSequence) < 0))
                            {
                                maxSequence = sequence;
                                maxCount = sequenceMap[sequence];
                            }
                        }
                    }
                }
            }

            return maxSequence
                .Split(" ")
                .ToList();
        }
    }
}
