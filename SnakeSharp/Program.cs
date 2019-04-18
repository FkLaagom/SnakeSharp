using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SnakeSharp
{

    static class Program
    {
        public static Random Rng = new Random();
        public static Snake Snake = new Snake();
        public static Timer SnakeTimer;
        public static Possison ApplePoss;
        public static List<Possison> Grid;
        
        private static void Main()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.CursorVisible = false;
            Grid = GetGrid(1, 40, 1, 20);
            PrintApple(2, 39, 2, 19);
            SetSnakeTimer();
            while (Snake.IsAlive)
            {
                Snake.SetDirection(Console.ReadKey(false).Key);
            }
            SnakeTimer.Stop();
        }

        private static List<Possison> GetGrid(int x1, int x2, int y1, int y2)
        {
            var possisions = new List<Possison>();
            Enumerable.Range(x1, x2 - x1).ToList().ForEach(x => {
                possisions.Add(new Possison(x,y1));
                possisions.Add(new Possison(x,y2));
            });
            Enumerable.Range(y1, y2 - y1).ToList().ForEach(y => {
                possisions.Add(new Possison(x1, y));
                possisions.Add(new Possison(x2, y));
            });
            possisions.ForEach(x => x.PrintPossision('#',ConsoleColor.Yellow));
            return possisions;
        }

        private static void GameLogics()
        {
            if (ApplePoss == Snake.GetPoss())
            {
                Snake.FeedSnake();
                PrintApple(2,39,2,19);
                SnakeTimer.Interval = Snake.Speed;
            }
            if (Grid.Any(x => x == Snake.GetPoss()))
                SnakeTimer.Stop();
        }

        private static void PrintApple(int x1, int x2, int y1, int y2)
        {
            var xExclude = Snake.Body.Select(x => x.XPoss);
            var yExclude = Snake.Body.Select(y => y.YPoss);
            var xNums = Enumerable.Range(x1, x2).Where(x => !xExclude.Contains(x));
            var yNums = Enumerable.Range(y1, y2).Where(x => !yExclude.Contains(x));

            int xPoss = xNums.ElementAt(Rng.Next(0, xNums.Count()-1));
            int yPoss = xNums.ElementAt(Rng.Next(0, yNums.Count()-1));

            var poss = new Possison(xPoss, yPoss);
            poss.PrintPossision('@', ConsoleColor.DarkRed);

            ApplePoss = poss;
        }

        private static void SetSnakeTimer()
        {
            SnakeTimer = new Timer(Snake.Speed);
            SnakeTimer.AutoReset = true;
            SnakeTimer.Elapsed += UpdateSnake;
            SnakeTimer.Enabled = true;
        }

        private static void UpdateSnake(object sender, ElapsedEventArgs e)
        {
            Snake.PrintSnake();
            GameLogics();
        }
    }
}
