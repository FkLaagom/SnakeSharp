using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeSharp
{
    class Snake
    {
        public List<Possison> Body;
        private Possison LastPoss;
        public bool IsAlive = true;
        public double Speed { get; set; }
        private ConsoleKey Direction { get; set; }
        private bool hasEaten = false;
        private int length { get; set; }
        public Snake()
        {
            Body = new List<Possison> { new Possison(10, 10) };
            LastPoss = Body[0];
            Direction = ConsoleKey.LeftArrow;
            Speed = 200;
        }

        public void ChangeDirection() { }

        public void PrintSnake()
        {
            var poss = new Possison();
            switch (Direction)
            {
                case ConsoleKey.LeftArrow:
                    poss.XPoss = LastPoss.XPoss - 1;
                    poss.YPoss = LastPoss.YPoss;
                    break;
                case ConsoleKey.RightArrow:
                    poss.XPoss = LastPoss.XPoss + 1;
                    poss.YPoss = LastPoss.YPoss;
                    break;
                case ConsoleKey.UpArrow:
                    poss.XPoss = LastPoss.XPoss;
                    poss.YPoss = LastPoss.YPoss - 1;
                    break;
                case ConsoleKey.DownArrow:
                    poss.XPoss = LastPoss.XPoss;
                    poss.YPoss = LastPoss.YPoss + 1;
                    break;
            }
            LastPoss = poss;
            Body.Add(poss);

            if (!hasEaten)
            {
                Body.ForEach(x => x.PrintPossision(' '));
                Body.RemoveAt(0);
                Body.ForEach(x => x.PrintPossision('O', ConsoleColor.Green));
            }
            else
            {
                Body.ForEach(x => x.PrintPossision('O', ConsoleColor.Green));
                hasEaten = false;
            }

        }

        public void FeedSnake()
        {
            hasEaten = true;
            Speed *= 0.9;
        }

        public Possison GetPoss()
        {
            return Body[0];
        }

        public void SetDirection(ConsoleKey key) => Direction = key == ConsoleKey.UpArrow ? key : key == ConsoleKey.DownArrow ? key : key == ConsoleKey.LeftArrow ? key : key == ConsoleKey.RightArrow ? key : Direction;
    }
}

