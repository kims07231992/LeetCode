using System.Collections.Generic;
using System.Linq;

namespace Design_Snake_Game
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var width = 3;
            var height = 2;
            var food = new int[][] 
            {
                new int[] { 1, 2 },
                new int[] { 0, 1 }
            };
            var snakeGame = new SnakeGame(width, height, food);

            snakeGame.Move("R"); // 0
            snakeGame.Move("D"); // 0
            snakeGame.Move("R"); // 1
            snakeGame.Move("U"); // 1
            snakeGame.Move("L"); // 2
            snakeGame.Move("U"); // - 1
        }

        public class SnakeGame
        {

            /** Initialize your data structure here.
                @param width - screen width
                @param height - screen height 
                @param food - A list of food positions
                E.g food = [[1,1], [1,0]] means the first food is positioned at [1,1], the second is at [1,0]. 
            */
            private List<int[]> snake;
            private HashSet<string> body; // Used to check if it bites itself
            private int[][] food;
            private int cols;
            private int rows;
            private int score;

            public SnakeGame(int width, int height, int[][] food)
            {
                this.cols = width;
                this.rows = height;
                this.food = food;
                this.score = 0;

                this.snake = new List<int[]>() { new int[] { 0, 0 } };
                this.body = new HashSet<string>() { "0x0" };
            }

            /** Moves the snake.
                @param direction - 'U' = Up, 'L' = Left, 'R' = Right, 'D' = Down 
                @return The game's score after the move. Return -1 if game over. 
                Game over when snake crosses the screen boundary or bites its body. 
            */
            /// <summary>
            /// Time Complexity: O(1) when we suppose snake is implemented with double ended queue
            /// Space Complexity: O(W*H) where W is given width and H is given height
            /// </summary>
            public int Move(string direction)
            {
                var head = snake.First();
                var tail = snake.Last();
                var newHead = new int[] { head[0], head[1] };
                if (direction == "U")
                {
                    newHead[0]--;
                }
                else if (direction == "D")
                {
                    newHead[0]++;
                }
                else if (direction == "L")
                {
                    newHead[1]--;
                }
                else
                {
                    newHead[1]++;
                }

                // bound check
                if (newHead[0] < 0 || newHead[0] >= rows // row
                    || newHead[1] < 0 || newHead[1] >= cols) // col
                {
                    return -1;
                }

                // Check if it bites itself
                // NOTE: If next is equal to last point, it's considered as valid
                if (!(newHead[0] == tail[0] && newHead[1] == tail[1])
                    && body.Contains($"{newHead[0]}x{newHead[1]}"))
                {
                    return -1;
                }

                snake.Insert(0, newHead);
                body.Add($"{newHead[0]}x{newHead[1]}");

                // Check if it reaches food
                if (score < food.Length 
                    && newHead[0] == food[score][0] 
                    && newHead[1] == food[score][1])
                {
                    score++;
                }
                else
                {
                    var last = snake.Last();
                    snake.RemoveAt(snake.Count - 1);
                    if (!(newHead[0] == last[0] && newHead[1] == last[1]))
                    {
                        body.Remove($"{last[0]}x{last[1]}");
                    }
                }

                return score;
            }
        }
    }
}
