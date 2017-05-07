using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace SuperSplashCurl
{
    public class BoardRenderer : IBoardRenderer
    {
        const int TILE_WIDTH = 256;//96;
        const int TILE_HEIGHT = 256;//96;
        const int TILE_OFFSET = TILE_HEIGHT / 4;
        const int TEXT_OFFSET_Y = 8;
        const string CLICKMAP_PATH = "ClickMap256";

        private Dictionary<int, Tuple<Color, Color, Vector2>> tilePresenting;


        private Texture2D tileTex;
        private SpriteFont font;

        private GameBoard board;

        //private Texture2D clickmap;
        
        public BoardRenderer(GameBoard board)
        {
            this.board = board;
            tileTex = Cache.LoadGraphic("TileThick256");
            
            font = Cache.LoadFont("TileFont");

            tilePresenting = new Dictionary<int, Tuple<Color, Color, Vector2>>()
            {
                { -1, new Tuple<Color, Color, Vector2>(Color.Gray, Color.Transparent, Vector2.Zero) },
                { 0, new Tuple<Color, Color, Vector2>(Color.White, Color.Transparent, Vector2.Zero) },
                { 1, new Tuple<Color, Color, Vector2>(Color.Red, Color.Black, font.MeasureString("1")) },
                { 2, new Tuple<Color, Color, Vector2>(Color.Yellow, Color.Black,  font.MeasureString("2")) },
                { 3, new Tuple<Color, Color, Vector2>(Color.Green, Color.Black,   font.MeasureString("3")) },
                { 4, new Tuple<Color, Color, Vector2>(Color.Blue, Color.White,    font.MeasureString("4")) },
            };

        }
        
        public void Render(SpriteBatch batch, GameTime gameTime)
        {
            for (int y = 0; y < board.Height; y++)
            {
                for (int x = 0; x < board.Width; x++)
                {
                    int dx = x * TILE_WIDTH + (TILE_WIDTH / 2) * (y % 2);
                    int dy = y * TILE_HEIGHT - y * TILE_OFFSET;

                    batch.Draw(tileTex, 
                        new Vector2(dx, dy),
                        tilePresenting[board.Tiles[x, y].Value].Item1
                    );
                    if (board.Tiles[x, y].Value > 0)
                    {
                        batch.DrawString(font,
                            board.Tiles[x, y].Value.ToString(),
                            new Vector2(dx + TILE_WIDTH / 2, dy + TILE_HEIGHT / 2 + TEXT_OFFSET_Y),
                            tilePresenting[board.Tiles[x, y].Value].Item2,
                            0,
                            tilePresenting[board.Tiles[x, y].Value].Item3 * .5f,
                            1,
                            SpriteEffects.None,
                            0
                        );
                    }
                }
            }

            board.Bounding.Render(batch);
        }
        

        public int TileWidth { get { return TILE_WIDTH; } }
        public int TileHeight { get { return TILE_HEIGHT; } }
        public int TileOffset { get { return TILE_OFFSET; } }
        public string ClickMapPath { get { return CLICKMAP_PATH; } }
    }
}
