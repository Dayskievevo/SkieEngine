using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Collision;
using System.Net.Mime;

namespace Pong
{
    public class Paddle : GameObject {

        public Paddle(string name,Texture2D texture) {
            this.name = name;
            _texture = texture;
        }

        // gameobject components
        public float speed = 500f;        
        public override void Start()
        {

        }

        public override void Update(GameTime gameTime) {
            Box2D = new BoxCollider2D(height, width, position, false);
            Box2D.CheckCollisionDirectional(this);

            if(Box2D.boundsTop) {
                position.Y = 0;
            }
            if(Box2D.boundsBottom) {
                position.Y = Manager.HEIGHT - height;
            }

            Move(gameTime);
        }

        private void Move(GameTime gametime)
        {
            if (input == null) { return; }


            float deltaTime = (float)gametime.ElapsedGameTime.TotalSeconds;

            if (Keyboard.GetState().IsKeyDown(input.Left) ){
                if(Box2D.isTouchingRight) {
                    return;
                }
                position.X -= speed * deltaTime;
            }

            if (Keyboard.GetState().IsKeyDown(input.Right)){
                if(Box2D.isTouchingLeft) {return;}
                position.X += speed * deltaTime;
            }

            if (Keyboard.GetState().IsKeyDown(input.Up)){
                if(Box2D.IsTouchingBottom) {return;}
                position.Y -= speed * deltaTime;
            }

            if (Keyboard.GetState().IsKeyDown(input.Down)){
                if(Box2D.isTouhcingTop) {return;}
                position.Y += speed * deltaTime;
            }
        }

    }
}
