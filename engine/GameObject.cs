using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Collision;

namespace Pong
{
    public abstract class GameObject
    {
        public string name;
        public Texture2D _texture;
        public Vector2 position;
        public Rectangle rect;
        public Color color = Color.White;
        public int width, height;
        public Input input;

        public abstract void Start();
        public abstract void Update(GameTime gametime);
        public void Draw(SpriteBatch spriteBatch)
        {
            rect = new Rectangle((int)position.X, (int)position.Y, width, height);
            spriteBatch.Draw(_texture, rect, color);
        }
        public string getGameObject() {
            return name;
        }

        public string getGameObjectPos() {
            return "X: " + Math.Round(position.X, 2, MidpointRounding.AwayFromZero) + " Y: " + Math.Round(position.Y, 2, MidpointRounding.AwayFromZero);
        }
    }
}
