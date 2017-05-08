using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSplashCurl.Boards
{
    public interface IBoardRenderer
    {
        void Render(SpriteBatch batch, GameTime gameTime);

        int TileWidth { get; }
        int TileHeight { get; }
        int TileOffset { get; }
        string ClickMapPath { get; }
    }
}
