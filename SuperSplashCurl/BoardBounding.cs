using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSplashCurl
{
    public class BoardBounding
    {
        public const int BORDER_SIZE = 32;

        private Texture2D borderTex;

        public GameBoard Board { get; private set; }
        

        public BoardBounding(GameBoard board)
        {
            Board = board;
            borderTex = Cache.LoadGraphic("Border");
        }


        public void Render(SpriteBatch batch)
        {
            Rectangle bbounding = Board.GetBounding();
            // top left
            batch.Draw(borderTex,
                new Vector2(bbounding.Left - BORDER_SIZE, bbounding.Top - BORDER_SIZE),
                new Rectangle(0, 0, BORDER_SIZE, BORDER_SIZE),
                Color.White
            );
            // top right
            batch.Draw(borderTex,
                new Vector2(bbounding.Right, bbounding.Top - BORDER_SIZE),
                new Rectangle(BORDER_SIZE * 2, 0, BORDER_SIZE, BORDER_SIZE),
                Color.White
            );
            // bottom left
            batch.Draw(borderTex,
                new Vector2(bbounding.Left - BORDER_SIZE, bbounding.Bottom),
                new Rectangle(0, BORDER_SIZE * 2, BORDER_SIZE, BORDER_SIZE),
                Color.White
            );
            // bottom right
            batch.Draw(borderTex,
                new Vector2(bbounding.Right, bbounding.Bottom),
                new Rectangle(BORDER_SIZE * 2, BORDER_SIZE * 2, BORDER_SIZE, BORDER_SIZE),
                Color.White
            );


            // top
            batch.Draw(borderTex,
                new Rectangle(bbounding.Left, bbounding.Top-BORDER_SIZE, bbounding.Width, BORDER_SIZE),
                new Rectangle(BORDER_SIZE , 0, BORDER_SIZE, BORDER_SIZE),
                Color.White
            );
            // left
            batch.Draw(borderTex,
                new Rectangle(bbounding.Left- BORDER_SIZE, bbounding.Top, BORDER_SIZE, bbounding.Height),
                new Rectangle(0, BORDER_SIZE, BORDER_SIZE, BORDER_SIZE),
                Color.White
            );
            // right
            batch.Draw(borderTex,
                new Rectangle(bbounding.Right, bbounding.Top, BORDER_SIZE, bbounding.Height),
                new Rectangle(BORDER_SIZE*2, BORDER_SIZE, BORDER_SIZE, BORDER_SIZE),
                Color.White
            );
            // bottom
            batch.Draw(borderTex,
                new Rectangle(bbounding.Left, bbounding.Bottom, bbounding.Width, BORDER_SIZE),
                new Rectangle(BORDER_SIZE, BORDER_SIZE*2, BORDER_SIZE, BORDER_SIZE),
                Color.White
            );
        }
    }
}
