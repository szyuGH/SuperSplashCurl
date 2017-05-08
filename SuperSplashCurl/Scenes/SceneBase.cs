using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSplashCurl.Scenes
{
    public abstract class SceneBase : IDisposable
    {

        public abstract void Render(SpriteBatch batch, GameTime gameTime);
        public abstract void Update(GameTime gameTime);
        public abstract void Dispose();
        public abstract void Initialize();
    }
}
