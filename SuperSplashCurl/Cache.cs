using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSplashCurl
{
    public static class Cache
    {
        private static ContentManager content;

        public static void Initialize(ContentManager c)
        {
            content = c;
        }

        public static Texture2D LoadGraphic(string name)
        {
            return content.Load<Texture2D>("Graphics/" + name);
        }

        public static SpriteFont LoadFont(string name)
        {
            return content.Load<SpriteFont>("Fonts/" + name);
        }
    }
}
