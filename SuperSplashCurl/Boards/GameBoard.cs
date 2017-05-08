using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSplashCurl.Boards
{
    public class GameBoard
    {
        private Texture2D clickMap;

        public int Width { get; private set; }
        public int Height { get; private set; }
        public Tile[,] Tiles { get; private set; }
        public IBoardRenderer Renderer { get; private set; }
        public BoardBounding Bounding { get; private set; }
        
        private GameBoard()
        {
        }

        private void InitializeBounding()
        {
            Bounding = new BoardBounding(this);
        }

        
        public Tile TileByPosition(Vector2 pos)
        {
            int cmx = (int)((pos.X % clickMap.Width));
            int cmy = (int)((pos.Y % clickMap.Height));
            
            if (cmx < 0 || cmy < 0)
            {
                return null;
            }

            Color[] data = new Color[clickMap.Width * clickMap.Height];
            clickMap.GetData(data);

            Color picked = data[cmx + clickMap.Width * cmy];

            int tx = (int)(pos.X / clickMap.Width);
            int ty = (int)(pos.Y / clickMap.Height) * 2;

            switch (picked.PackedValue)
            {
                case 0xFF0000FF: // red
                    tx--;
                    ty--;
                    break;
                case 0xFFFF0000: // blue
                    ty--;
                    break;
                case 0xFFFFFFFF: // white
                    tx--;
                    ty++;
                    break;
                case 0xFF00FF00: // green
                    ty++;
                    break;
            }
            if (tx < 0 || ty < 0 || tx >= Width || ty >= Height)
                return null;

            return Tiles[tx, ty];
        }



        public Rectangle GetBounding()
        {
            return new Rectangle(
                Renderer.TileWidth / 2,
                Renderer.TileHeight / 2,
                Renderer.TileWidth * Width - Renderer.TileWidth / 2,
                (Renderer.TileHeight - Renderer.TileOffset) * Height - Renderer.TileHeight + Renderer.TileOffset
            );
        }
        public Rectangle GetCameraBounding(Viewport vp)
        {
            return GetBounding().Add(
                new Rectangle(
                    vp.Width / 2 - BoardBounding.BORDER_SIZE, 
                    vp.Height / 2 - BoardBounding.BORDER_SIZE, 
                    -vp.Width + BoardBounding.BORDER_SIZE * 2, 
                    -vp.Height + BoardBounding.BORDER_SIZE * 2
                )
            );
        }






        public static GameBoard Create<T>(int width, int height) where T : IBoardRenderer
        {
            GameBoard gb = new GameBoard()
            {
                Width = width,
                Height = height
            };
            gb.Tiles = new Tile[width, height];
            gb.Renderer = (T)Activator.CreateInstance(typeof(T), gb);
            gb.clickMap = Cache.LoadGraphic(gb.Renderer.ClickMapPath);
            gb.InitializeBounding();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int val = -1;
                    if (x >= 3 && x < width - 1 && y > 0 && y < height - 1)
                        val = Program.Random.Next(5 /* TODO: Replace by a config setting */);

                    gb.Tiles[x, y] = new Tile(x, y, val);
                }
            }

            return gb;
        }
    }
}
