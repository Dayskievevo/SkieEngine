using Collision;
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

        public BoxCollider2D box2D;

        public float speed = 600f;
        int right = 1, top = 1;

        public override void Start()
        {
            resetBallPos();
        }

        public override void Update(GameTime gameTime) {
            box2D = new BoxCollider2D(height, width, position, false);
            box2D.CheckCollision(this);
            Move(gameTime);

            if(position.X < 0 || position.X + rect.Width > GameManager.WIDTH) {
                right *= -1;
            }
        }

        private void Move(GameTime gameTime)
        {
            int deltaSpeed = (int)(speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            if(box2D.isColliding) { right *= -1;}
            if(box2D.isCollidingBounds) { top *= -1; }

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
