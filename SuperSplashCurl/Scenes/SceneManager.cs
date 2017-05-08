using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSplashCurl.Scenes
{
    public static class SceneManager
    {
        private static SceneBase currentScene;
        private static SceneBase nextScene;

        public static Game Game { get; private set; }

        public static void Initialize<T>(Game game) where T : SceneBase
        {
            Game = game;
            Call<T>();
        }

        public static void Update(GameTime gameTime)
        {
            if (nextScene != null)
            {
                currentScene?.Dispose();
                currentScene = nextScene;
                nextScene = null;
                currentScene.Initialize();
            }
            else if (currentScene != null)
            {
                currentScene.Update(gameTime);
            } else
            {
                Game.Exit();
            }
        }

        public static void Render(SpriteBatch batch, GameTime gameTime)
        {
            currentScene?.Render(batch, gameTime);
        }

        public static void Call<T>(params object[] args) where T : SceneBase
        {
            nextScene = (T)Activator.CreateInstance(typeof(T), args);
        }
    }
}
