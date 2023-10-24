using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.InteropServices;
using System;

namespace Pong
{
    public class GameObject
    {
        protected Texture2D _texture;

        public Vector2 position;
        public Color color = Color.White;
        public float speed = 100f;
        public Input input;

        public GameObject(Texture2D texture)
        {
            _texture = texture;
        }

        public void Update(GameTime gametime)
        {
            Move(gametime);
        }

        private void Move(GameTime gametime)
        {
            if (input == null) { return; }

            float deltaTime = (float)gametime.ElapsedGameTime.TotalSeconds;

            if (Keyboard.GetState().IsKeyDown(input.Left))
            {
                position.X -= speed * deltaTime;
            }

            if (Keyboard.GetState().IsKeyDown(input.Right))
            {
                position.X += speed * deltaTime;
            }

            if (Keyboard.GetState().IsKeyDown(input.Up))
            {
                position.Y -= speed * deltaTime;
            }

            if (Keyboard.GetState().IsKeyDown(input.Down))
            {
                position.Y += speed * deltaTime;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, position, color);
        }


    }
}
