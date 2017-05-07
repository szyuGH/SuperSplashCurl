using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSplashCurl
{
    public class PlayerMenuDisplay
    {
        const int SPACING = 12;

        private Viewport viewport;
        private Texture2D menuBg;
        private Texture2D pixelTex;
        private Texture2D iconAtlas;
        private Texture2D nextIcon;
        private SpriteFont font;

        private int iconSize;

        public PlayerMenuDisplay(Viewport viewport)
        {
            this.viewport = viewport;
            this.menuBg = Cache.LoadGraphic("MenuBackground");
            this.pixelTex = Cache.LoadGraphic("Pixel");
            this.iconAtlas = Cache.LoadGraphic("CurlIcons");
            iconSize = iconAtlas.Width / 5;
            this.nextIcon = Cache.LoadGraphic("IconNext");
            this.font = Cache.LoadFont("MenuFont");
        }

        public void Render(SpriteBatch batch)
        {
            int rowHeight = viewport.Height / SessionManager.Players.Count;
            int faceSize = Math.Min(viewport.Width, rowHeight) - 3 * SPACING - font.LineSpacing;
            int bgRowCount = (int)Math.Ceiling((float)rowHeight / menuBg.Height);
            int belowFaceSpace = rowHeight - (SPACING + faceSize);

            int index = 0;
            foreach (KeyValuePair<GamePlayer, int> kvp in SessionManager.Players)
            { 
                GamePlayer player = kvp.Key;
                int score = kvp.Value;

                for (int y=0;y< bgRowCount; y++)
                {
                    int bgy = y * menuBg.Height;
                    int bgh = Math.Min(menuBg.Height, rowHeight - (y * menuBg.Height));


                    batch.Draw(menuBg,
                        new Rectangle(0, rowHeight * index + bgy, viewport.Width, bgh),
                        new Rectangle(0, 0, menuBg.Width, bgh),
                        player.Color);
                }

                // Render Curl Icons
                int maxIconSize = Math.Min(iconSize, rowHeight - (SPACING + font.LineSpacing));
                int iconIndex = 0;
                RenderOutlinedText(batch, ">", SPACING / 2, rowHeight * index + SPACING / 2 + font.LineSpacing + (maxIconSize - font.LineSpacing) / 2, Color.White, Color.Black, 3);
                foreach (GameCurl curl in SessionManager.NextCurls[player])
                {
                    batch.Draw(iconAtlas,
                        new Rectangle(
                            SPACING*2 + (SPACING/2 + maxIconSize)*iconIndex,
                            rowHeight * index + SPACING / 3 + font.LineSpacing, 
                            maxIconSize, 
                            maxIconSize
                        ),
                        new Rectangle((curl.IconIndex % 5) * iconSize, (curl.IconIndex / 5) * iconSize, iconSize, iconSize),
                        Color.White
                    );
                    iconIndex++;
                }
                

                //int ty = (rowHeight * index + SPACING + faceSize) + (belowFaceSpace - font.LineSpacing) / 2;
                int ty = rowHeight * (index)  + SPACING / 2;
                RenderOutlinedText(batch, player.Name, SPACING, ty, Color.White, Color.Black, 3);
                RenderOutlinedText(batch, score.ToString(), viewport.Width - SPACING*2, ty, Color.White, Color.Black, 3);


                if (index < SessionManager.Players.Count - 1)
                {
                    batch.Draw(pixelTex, new Rectangle(1, rowHeight * (index + 1) - 2, viewport.Width - 2, 1), Color.Black);
                    batch.Draw(pixelTex, new Rectangle(0, rowHeight * (index + 1) - 1, viewport.Width, 1), Color.Brown);
                }
                batch.Draw(pixelTex, new Rectangle(1, rowHeight * index + 1, viewport.Width - 2, 1), Color.Black);
                batch.Draw(pixelTex, new Rectangle(0, rowHeight * index, viewport.Width, 1), Color.Brown);

                index++;
            }

            RenderMenuOutline(batch);
        }

        private void RenderOutlinedText(SpriteBatch batch, string text, int x, int y, Color color, Color outlineColor, int strength)
        {
            batch.DrawString(font, text, new Vector2(x- strength, y), outlineColor);
            batch.DrawString(font, text, new Vector2(x+ strength, y), outlineColor);
            batch.DrawString(font, text, new Vector2(x, y- strength), outlineColor);
            batch.DrawString(font, text, new Vector2(x, y+ strength), outlineColor);

            batch.DrawString(font, text, new Vector2(x, y), color);
        }
        
        private void RenderMenuOutline(SpriteBatch batch)
        {
            batch.Draw(pixelTex, new Rectangle(0, 0, viewport.Width, 3), Color.Black);
            batch.Draw(pixelTex, new Rectangle(0, 0, 3, viewport.Height), Color.Black);
            batch.Draw(pixelTex, new Rectangle(viewport.Width - 3, 0, 3, viewport.Height), Color.Black);
            batch.Draw(pixelTex, new Rectangle(0, viewport.Height - 3, viewport.Width, 3), Color.Black);

            batch.Draw(pixelTex, new Rectangle(1, 1, viewport.Width-2, 1),                      Color.Brown);
            batch.Draw(pixelTex, new Rectangle(1, 1, 1, viewport.Height-2),                     Color.Brown);
            batch.Draw(pixelTex, new Rectangle(viewport.Width - 2, 1, 1, viewport.Height-2),    Color.Brown);
            batch.Draw(pixelTex, new Rectangle(1, viewport.Height - 2, viewport.Width-2, 1),    Color.Brown);
        }
    }
}
