using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeSharp
{
    public class Possison
    {
        public int XPoss { get; set; }
        public int YPoss { get; set; }

        public Possison() { }

        public Possison(int xPoss, int yPoss)
        {
            XPoss = xPoss;
            YPoss = yPoss;
        }

        public void PrintPossision(char symbol, ConsoleColor clr = ConsoleColor.White)
        {
            Console.ForegroundColor = clr;
            Console.SetCursorPosition(XPoss, YPoss);
            Console.Write(symbol);
            Console.ResetColor();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Possison))
                return false;

            var other = obj as Possison;

            if (XPoss != other.XPoss || YPoss != other.YPoss)
                return false;

            return true;
        }

        public static bool operator ==(Possison x, Possison y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(Possison x, Possison y)
        {
            return !(x == y);
        }
    }
}
