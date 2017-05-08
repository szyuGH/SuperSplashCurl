using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperSplashCurl.Boards;
using SuperSplashCurl.Scenes;
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

        

        //MenuPanel menuPanel;
        //PlayerMenuDisplay playermenu;

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
            GameSettings.DefaultViewport = GraphicsDevice.Viewport;
            Cache.Initialize(Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);

            
            SessionManager.InitializePlayer("Szyu", 6, GameSettings.PlayerColors[0]);
            SessionManager.InitializePlayer("Enuma", 3, GameSettings.PlayerColors[8]);
            SessionManager.InitializePlayer("Nidreg", 2, GameSettings.PlayerColors[9]);
            SessionManager.InitializePlayer("Pix", 5, GameSettings.PlayerColors[3]);
            SessionManager.InitializePlayer("Satao", 4, GameSettings.PlayerColors[4]);
            SessionManager.InitializePlayer("Satao", 1, GameSettings.PlayerColors[5]);
            SessionManager.InitializePlayer("Satao", 0, GameSettings.PlayerColors[6]);
            SessionManager.InitializePlayer("Satao", 8, GameSettings.PlayerColors[7]);

            SceneManager.Initialize<SceneSession>(this);
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
            SceneManager.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Viewport = GameSettings.DefaultViewport;
            GraphicsDevice.Clear(Color.Black);
            
            SceneManager.Render(spriteBatch, gameTime);

            base.Draw(gameTime);
            frameCounter.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            Window.Title = string.Format("{0} - {1} fps - ~{2} fps", TITLE, Math.Ceiling(frameCounter.CurrentFramesPerSecond), Math.Ceiling(frameCounter.AverageFramesPerSecond));
        }
    }
}
