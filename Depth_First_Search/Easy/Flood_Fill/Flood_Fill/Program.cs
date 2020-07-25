
namespace Flood_Fill
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var image = new int[][] 
            {
                new int[] { 0, 0, 0 },
                new int[] { 0, 1, 1 }
            };
            var sr = 1;
            var sc = 1;
            var newColor = 2;

            var result = FloodFill(image, sr, sc, newColor);
        }

        /// <summary>
        /// Time Complexity: O(N*M) where N is number of rows and M is number of columns
        /// Space Complexity: O(N*M)
        /// </summary>
        private static int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            if (image[sr][sc] == newColor)
                return image;

            Flood(image, sr, sc, image[sr][sc], newColor);

            return image;
        }

        private static void Flood(int[][] image, int sr, int sc, int originalColor, int newColor)
        {
            if (sr < 0 || sr >= image.Length // row
               || sc < 0 || sc >= image[0].Length // column
               || image[sr][sc] != originalColor)
                return;

            image[sr][sc] = newColor;

            Flood(image, sr, sc + 1, originalColor, newColor);
            Flood(image, sr + 1, sc, originalColor, newColor);
            Flood(image, sr, sc - 1, originalColor, newColor);
            Flood(image, sr - 1, sc, originalColor, newColor);
        }
    }
}
