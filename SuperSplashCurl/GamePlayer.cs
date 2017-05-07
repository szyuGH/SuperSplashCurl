using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSplashCurl
{
    public class GamePlayer
    {
        public int Id { get; private set; }
        public int FaceIndex { get; private set; }
        public string Name { get; private set; }
        public Color Color { get; private set; }


        public GamePlayer(int id, string name, int faceIndex, Color color)
        {
            Id = id;
            Name = name;
            FaceIndex = faceIndex;
            Color = color;
        }
    }
}
