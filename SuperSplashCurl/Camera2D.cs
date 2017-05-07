using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSplashCurl
{
    public class Camera2D
    {
        private static Rectangle? _bounding;
        public static Rectangle? Bounding
        {
            get { return _bounding; }
            set
            {
                _bounding = value;
                SetPosition(_position.X, _position.Y);
            }
        }

        public static Viewport Viewport;

        private static Vector2 _position;
        public static Vector2 Position { get { return _position; } }
        public static float Rotation;

        public static void MoveX(float x)
        {
            _position.X += x;
            if (Bounding.HasValue)
            {
                if (_position.X < Bounding.Value.Left)
                    _position.X = Bounding.Value.Left;
                else if (_position.X > Bounding.Value.Right)
                    _position.X = Bounding.Value.Right;
            }
        }

        public static void MoveY(float y)
        {
            _position.Y += y;
            if (Bounding.HasValue)
            {
                if (_position.Y < Bounding.Value.Top)
                    _position.Y = Bounding.Value.Top;
                else if (_position.Y > Bounding.Value.Bottom)
                    _position.Y = Bounding.Value.Bottom;
            }
        }

        public static void SetPosition(float x, float y)
        {
            _position.X = 0;
            _position.Y = 0;
            MoveX(x);
            MoveY(y);
        }


        public static Matrix Transform
        {
            get
            {
                return Matrix.CreateTranslation(-Position.X, -Position.Y, 0)
                    * Matrix.CreateRotationZ(Rotation)
                    * Matrix.CreateScale(1, 1, 1)
                    * Matrix.CreateTranslation(Viewport.Width * .5f, Viewport.Height * .5f, 0);
            }
        }

        public static Vector2 ToWorld(Vector2 position)
        {
            return Vector2.Transform(position - new Vector2(Viewport.X, Viewport.Y), Matrix.Invert(Transform));
        }
    }
}
