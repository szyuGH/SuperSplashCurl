using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSplashCurl
{
    public class MenuPanel
    {
        const int SPACING = 12;

        private Viewport viewport;
        private Texture2D pixelTex;
        private Texture2D menuButtonTex;
        private Texture2D reqScoreTex;
        private SpriteFont font;

        public MenuPanel(Viewport viewport)
        {
            this.viewport = viewport;
            this.pixelTex = Cache.LoadGraphic("Pixel");
            this.menuButtonTex = Cache.LoadGraphic("MenuButton");
            this.reqScoreTex = Cache.LoadGraphic("ReqScorePanel");
            this.font = Cache.LoadFont("MenuFont");
        }

        public void Render(SpriteBatch batch)
        {
            batch.Draw(menuButtonTex, new Vector2(0, 0), Color.White);
            batch.Draw(reqScoreTex, new Rectangle(menuButtonTex.Width, 0, viewport.Width-menuButtonTex.Width, viewport.Height), Color.White);

            string scoreText = string.Format("Req.: {0}", SessionManager.WinningScore);
            Vector2 measure = font.MeasureString(scoreText);
            RenderOutlinedText(batch, 
                scoreText, 
                // position
                menuButtonTex.Width + (int)((viewport.Width - measure.X) / 2),
                viewport.Height / 2,
                // center
                measure.X,
                measure.Y,
                Color.White, Color.Black, 2,
                1f);

            RenderMenuOutline(batch);
        }

        private void RenderOutlinedText(SpriteBatch batch, string text, int x, int y, float cx, float cy, Color color, Color outlineColor, int strength, float size)
        {
            batch.DrawString(font, text, new Vector2(x - strength, y), outlineColor, 0, new Vector2(cx, cy) * .5f, size, SpriteEffects.None, 0);
            batch.DrawString(font, text, new Vector2(x + strength, y), outlineColor, 0, new Vector2(cx, cy) * .5f, size, SpriteEffects.None, 0);
            batch.DrawString(font, text, new Vector2(x, y - strength), outlineColor, 0, new Vector2(cx, cy) * .5f, size, SpriteEffects.None, 0);
            batch.DrawString(font, text, new Vector2(x, y + strength), outlineColor, 0, new Vector2(cx, cy) * .5f, size, SpriteEffects.None, 0);

            batch.DrawString(font, text, new Vector2(x, y), color, 0, new Vector2(cx, cy) * .5f, size, SpriteEffects.None, 0);
        }

        private void RenderMenuOutline(SpriteBatch batch)
        {
            batch.Draw(pixelTex, new Rectangle(0, 0, viewport.Width, 3), Color.Black);
            batch.Draw(pixelTex, new Rectangle(0, 0, 3, viewport.Height), Color.Black);
            batch.Draw(pixelTex, new Rectangle(viewport.Width - 3, 0, 3, viewport.Height), Color.Black);
            batch.Draw(pixelTex, new Rectangle(0, viewport.Height - 3, viewport.Width, 3), Color.Black);

            batch.Draw(pixelTex, new Rectangle(1, 1, viewport.Width - 2, 1), Color.Brown);
            batch.Draw(pixelTex, new Rectangle(1, 1, 1, viewport.Height - 2), Color.Brown);
            batch.Draw(pixelTex, new Rectangle(viewport.Width - 2, 1, 1, viewport.Height - 2), Color.Brown);
            batch.Draw(pixelTex, new Rectangle(1, viewport.Height - 2, viewport.Width - 2, 1), Color.Brown);

            batch.Draw(pixelTex, new Rectangle(64, 2, 3, viewport.Height-4), Color.Black);
            batch.Draw(pixelTex, new Rectangle(65, 1, 1, viewport.Height - 2), Color.Brown);
        }
    }
}
