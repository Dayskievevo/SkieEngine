using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Pong
{
    public class Ball : GameObject
    {
        public Ball(string name, Texture2D texture) {
            this.name = name;
            _texture = texture;
        }

        public float speed = 100f;
        int right = 1, top = 1;

        public override void Start()
        {
            resetBallPos();
        }

        public override void Update(GameTime gameTime) {
            //Move(gameTime);
        }

        private void Move(GameTime gameTime)
        {
            int deltaSpeed = (int)(speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            position.X += right * deltaSpeed;
            position.Y += top * deltaSpeed;
        }

        public void resetBallPos()
        {
            position.X = GameManager.WIDTH / 2 - width;
            position.Y = GameManager.HEIGHT / 2 - height;
        }
    }
}
