using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSplashCurl
{
    internal static class GameSettings
    {
        public readonly static Color[] PlayerColors = new Color[]
        {
            new Color().FromUint(0xFFE52E2B),
            new Color().FromUint(0xFF0094FF),
            new Color().FromUint(0xFF2BC63D),
            new Color().FromUint(0xFFC42154),
            new Color().FromUint(0xFFE2C222),
            new Color().FromUint(0xFF2CE0A1),
            new Color().FromUint(0xFF6C96DD),
            new Color().FromUint(0xFFD8732B),
            new Color().FromUint(0xFFFF32D9),
            new Color().FromUint(0xFFD1FFDE),
        };





        public static Viewport DefaultViewport = new Viewport(0,0, 1280, 720);
        public static readonly int GameMenuWidth = 220;
        public static readonly int GameMenuHeight = 64;
    }
}
