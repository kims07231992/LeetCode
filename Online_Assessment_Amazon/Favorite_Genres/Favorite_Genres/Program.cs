using System;
using System.Collections.Generic;

namespace Favorite_Genres
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();   
        }

        private static void Run()
        {
            var userSongs = new Dictionary<string, List<string>>();
            userSongs.Add("David", new List<string> { "song1", "song2", "song3", "song4", "song8" });
            userSongs.Add("Emma", new List<string> { "song5", "song6", "song7" });

            var songGenres = new Dictionary<string, List<string>>();
            songGenres.Add("Rock", new List<string> { "song1", "song3" });
            songGenres.Add("Dubstep", new List<string> { "song7" });
            songGenres.Add("Techno", new List<string> { "song2", "song4" });
            songGenres.Add("Pop", new List<string> { "song5", "song6" });
            songGenres.Add("Jazz", new List<string> { "song8", "song9" });

            var result = FavoriteGenres(userSongs, songGenres);
        }

        /// <summary>
        /// Time Complexity: O(U * S) where U is number of users and S is number of songs
        /// Space Complexity: O(S)
        /// </summary>
        private static Dictionary<string, List<string>> FavoriteGenres(Dictionary<string, List<string>> userMap, Dictionary<string, List<string>> genreMap)
        {
            var result = new Dictionary<string, List<string>>();
            var songsToGenres = new Dictionary<string, string>();

            foreach (string genre in genreMap.Keys)
            {
                var songs = genreMap[genre];
                foreach (string song in songs)
                {
                    songsToGenres.Add(song, genre);
                }
            }

            foreach (string user in userMap.Keys)
            {
                var resultPerUser = new List<string>();
                var count =  new Dictionary<string, int>();
                var max = 0;
                var songs = userMap[user];
                foreach (string song in songs)
                {
                    string genre = songsToGenres[song];
                    if (!count.ContainsKey(genre))
                        count.Add(genre, 0);

                    max = Math.Max(++count[genre], max);
                }
                foreach (string key in count.Keys)
                {
                    if (count[key] == max)
                        resultPerUser.Add(key);

                }

                result.Add(user, resultPerUser);
            }

            return result; 
        }
    }
}
