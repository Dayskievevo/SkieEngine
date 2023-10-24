using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Paddle : GameObject {

        public Paddle(Texture2D texture) {
            _texture = texture;
            speed = 500f;
        }

        public override void Start()
        {

        }

        public override void Update(GameTime gameTime) {
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
