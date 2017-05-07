using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSplashCurl
{
    static class Extensions
    {
        public static Rectangle Add(this Rectangle a, Rectangle b)
        {
            return new Rectangle(a.X + b.X, a.Y + b.Y, a.Width + b.Width, a.Height + b.Height);
        }

        public static Color FromUint(this Color color, uint packedColor)
        {
            color.B = (byte)(packedColor);
            color.G = (byte)(packedColor >> 8);
            color.R = (byte)(packedColor >> 16);
            color.A = (byte)(packedColor >> 24);
            return color;
        }
    }
}
