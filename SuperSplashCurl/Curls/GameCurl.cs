using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSplashCurl.Curls
{
    public abstract class GameCurl
    {
        public GamePlayer Player { get; private set; }
        public int IconIndex { get; protected set; }
        public string Name { get; protected set; }



        private static Type[] CurlTypes = new Type[]
        {
            typeof(NormalCurl)
        };

        public static GameCurl CreateRandom()
        {
            Type ct = CurlTypes.ToList().OrderBy(a => Guid.NewGuid()).Skip(Program.Random.Next(CurlTypes.Length)).FirstOrDefault();
            if (ct == null) return new NormalCurl();

            return (GameCurl)Activator.CreateInstance(ct);
        }
    }
}
