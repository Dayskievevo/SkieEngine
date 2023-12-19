using Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Runtime.Serialization;

namespace Pong
{
    public class Ball : GameObject
    {
        public Ball(string name, Texture2D texture) {
            this.name = name;
            _texture = texture;
        }

        public float speed = 500f;
        int right = -1, top = 1;

        public override void Start()
        {
            resetBallPos();
        }

        public override void Update(GameTime gameTime) {
            Box2D = new BoxCollider2D(height, width, position, false);
            Box2D.CheckCollisionDirectional(this);

            // what to do if collission occurs
            if(Box2D.isTouchingLeft) { right = -1;}
            if(Box2D.isTouchingRight) { right = 1; }
            if(Box2D.isTouhcingTop) { top = -1; }
            if(Box2D.IsTouchingBottom) { top = 1; }

            if(Box2D.boundsTop || Box2D.boundsBottom) {
                top *= -1;
            }

            Move(gameTime);

            // p2 scores goal
            if(position.X < 0) {
                GameManager.PlayerScored(false);
                resetBallPos();
            }

            if(position.X + rect.Width > Manager.WIDTH) {
                GameManager.PlayerScored(true);
                resetBallPos();     
            }
        }

        private void Move(GameTime gameTime)
        {
            int deltaSpeed = (int)(speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            position.X += right * deltaSpeed;
            position.Y += top * deltaSpeed;
        }

        public void resetBallPos()
        {
            right *= -1;
            position.X = Manager.WIDTH / 2 - width;
            position.Y = Manager.HEIGHT / 2 - height;
        }
    }
}
