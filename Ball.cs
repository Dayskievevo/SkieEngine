using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Pong
{
    public class Ball : GameObject
    {
        int right = 1, top = 1;

        public Ball(Texture2D texture) {
            _texture = texture;
            speed = 100;
        }

        public override void Start()
        {

        }

        public override void Update(GameTime gameTime) {
            //Move(gameTime);
        }

        // unless i need to manuelly set the draw for some reason
        // leaving it in gameobject should be fine?

        //public override void Draw(SpriteBatch spriteBatch)
        //{
        //    rect = new Rectangle((int)position.X, (int)position.Y, width, height);
        //    spriteBatch.Draw(Globals.pixel, rect, color);
        //}

        private void Move(GameTime gameTime)
        {
            int deltaSpeed = (int)(speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            position.X += right * deltaSpeed;
            position.Y += top * deltaSpeed;
        }

        public void resetBallPos()
        {
            position.X = Globals.WIDTH / 2 - width;
            position.Y = Globals.HEIGHT / 2 - height;
        }
    }
}
