using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SuperSplashCurl
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        const string TITLE = "Super Splash Curl";

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        FrameCounter frameCounter;

        GameBoard board;
        Viewport defaultViewport;
        Viewport menuViewport;
        Viewport playersViewport;
        Viewport gameViewport;

        MenuPanel menuPanel;
        PlayerMenuDisplay playermenu;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;// GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = 720;// GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.PreferMultiSampling = true;
            //graphics.IsFullScreen = true;

            this.IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            frameCounter = new FrameCounter();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Cache.Initialize(Content);

            defaultViewport = GraphicsDevice.Viewport;

            menuViewport = new Viewport(0, 0, 220, 64);
            playersViewport = new Viewport(0, 64, 220, GraphicsDevice.Viewport.Height - 64);
            gameViewport = new Viewport(playersViewport.Width, 0, GraphicsDevice.Viewport.Width - playersViewport.Width, GraphicsDevice.Viewport.Height);
            Camera2D.Viewport = gameViewport;

            board = GameBoard.Create<BoardRenderer>(10, 10);

            Camera2D.Bounding = board.GetCameraBounding(gameViewport);
            spriteBatch = new SpriteBatch(GraphicsDevice);

            menuPanel = new MenuPanel(menuViewport);

            playermenu = new PlayerMenuDisplay(playersViewport);
            SessionManager.InitializePlayer("Szyu", 6, GameSettings.PlayerColors[0]);
            SessionManager.InitializePlayer("Enuma", 3, GameSettings.PlayerColors[8]);
            SessionManager.InitializePlayer("Nidreg", 2, GameSettings.PlayerColors[9]);
            SessionManager.InitializePlayer("Pix", 5, GameSettings.PlayerColors[3]);
            SessionManager.InitializePlayer("Satao", 4, GameSettings.PlayerColors[4]);
            SessionManager.InitializePlayer("Satao", 1, GameSettings.PlayerColors[5]);
            SessionManager.InitializePlayer("Satao", 0, GameSettings.PlayerColors[6]);
            SessionManager.InitializePlayer("Satao", 8, GameSettings.PlayerColors[7]);


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();
            KeyboardState ks = Keyboard.GetState();
            if (ms.LeftButton == ButtonState.Pressed)
            {
                Vector2 wms = Camera2D.ToWorld(new Vector2(ms.X, ms.Y));
                board.TileByPosition(wms)?.IncreaseValue(1);
            }

            int mvsp = 30;
            if (ks.IsKeyDown(Keys.W))
                Camera2D.MoveY(-mvsp);
            else if (ks.IsKeyDown(Keys.S))
                Camera2D.MoveY(mvsp);
            if (ks.IsKeyDown(Keys.A))
                Camera2D.MoveX(-mvsp);
            else if (ks.IsKeyDown(Keys.D))
                Camera2D.MoveX(mvsp);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Viewport = defaultViewport;
            GraphicsDevice.Clear(Color.Black);


            GraphicsDevice.Viewport = menuViewport;
            spriteBatch.Begin();
            menuPanel.Render(spriteBatch);
            spriteBatch.End();

            GraphicsDevice.Viewport = playersViewport;
            spriteBatch.Begin();
            playermenu.Render(spriteBatch);
            spriteBatch.End();


            GraphicsDevice.Viewport = gameViewport;
            spriteBatch.Begin(transformMatrix:Camera2D.Transform);
            board.Renderer.Render(spriteBatch, gameTime);
            spriteBatch.End();

            base.Draw(gameTime);
            frameCounter.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            Window.Title = string.Format("{0} - {1} fps - ~{2} fps", TITLE, Math.Ceiling(frameCounter.CurrentFramesPerSecond), Math.Ceiling(frameCounter.AverageFramesPerSecond));
        }
    }
}
