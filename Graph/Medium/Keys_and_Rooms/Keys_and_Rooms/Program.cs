using System;
using System.Collections.Generic;

namespace Keys_and_Rooms
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var rooms = new List<IList<int>>()
            {
                new List<int> { 1 },
                new List<int> { 2 },
                new List<int> { 3 },
                new List<int> { 0 }
            };
            var result = CanVisitAllRooms(rooms);

        }

        /// <summary>
        /// Time Complexity: O(N) where N is length of given array
        /// Space Complexity: O(N)
        /// </summary>
        public static bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            var seen = new Dictionary<int, bool>();
            VisitRoom(seen, rooms, 0);

            return rooms.Count == seen.Count;
        }

        private static void VisitRoom(Dictionary<int, bool> seen, IList<IList<int>> rooms, int roomIndex)
        {
            seen.Add(roomIndex, true); // visited

            var room = rooms[roomIndex];
            foreach (var key in room)
            {
                if (!seen.ContainsKey(key))
                    VisitRoom(seen, rooms, key);
            }
        }
    }
}
