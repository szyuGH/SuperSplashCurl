using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperSplashCurl.Scenes
{
    public class SceneSession : SceneBase
    {
        private Viewport menuViewport;
        private Viewport playersViewport;
        private Viewport gameViewport;

        private MenuPanel menuPanel;
        private PlayerMenuDisplay playermenu;


        public override void Initialize()
        {
            menuViewport = new Viewport(0, 0, GameSettings.GameMenuWidth, GameSettings.GameMenuHeight);
            playersViewport = new Viewport(0, menuViewport.Height, menuViewport.Width, GameSettings.DefaultViewport.Height - menuViewport.Height);
            gameViewport = new Viewport(playersViewport.Width, 0, GameSettings.DefaultViewport.Width - GameSettings.GameMenuWidth, GameSettings.DefaultViewport.Height);

            menuPanel = new MenuPanel(menuViewport);
            playermenu = new PlayerMenuDisplay(playersViewport);

            SessionManager.InitializeBoard();
            Camera2D.Viewport = gameViewport;
            Camera2D.Bounding = SessionManager.Board.GetCameraBounding(gameViewport);
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void Render(SpriteBatch batch, GameTime gameTime)
        {
            GraphicsDevice gd = batch.GraphicsDevice;

            gd.Viewport = menuViewport;
            batch.Begin();
            menuPanel.Render(batch);
            batch.End();

            gd.Viewport = playersViewport;
            batch.Begin();
            playermenu.Render(batch);
            batch.End();


            gd.Viewport = gameViewport;
            batch.Begin(transformMatrix: Camera2D.Transform);
            SessionManager.Board.Renderer.Render(batch, gameTime);
            batch.End();
        }
    }
}
