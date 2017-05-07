using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSplashCurl
{
    public class Tile
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Value { get; private set; }

        public Tile(int x, int y, int val)
        {
            X = x;
            Y = y;
            Value = val;
        }

        internal void IncreaseValue(int v)
        {
            Value++;
            if (Value >= 5)
                Value = 4;
        }
    }
}
