using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Collision;

namespace Pong
{
    public class Paddle : GameObject {

        public Paddle(string name,Texture2D texture) {
            this.name = name;
            _texture = texture;
        }

        // gameobject components
        public BoxCollider2D box2D;

        public float speed = 300f;
        public override void Start()
        {
            
        }

        public override void Update(GameTime gameTime) {
            box2D = new BoxCollider2D(height, width, position, false);
            Move(gameTime);
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

    }
}
