using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Paddle {
        public Rectangle rect;
        float moveSpeed = 500f;
        bool isSecondPlayer = false;

        public Paddle(bool isSecondPlayer) {
            this.isSecondPlayer = isSecondPlayer;
            rect = new Rectangle((this.isSecondPlayer ? Globals.WIDTH - 20 : 0), 140, 20, 200);
        }
        public void Update(GameTime gameTime) {

            // gets information about what key is being pressed
            KeyboardState kstate = Keyboard.GetState();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;


            if ((isSecondPlayer ? kstate.IsKeyDown(Keys.Up) : kstate.IsKeyDown(Keys.W)) && rect.Y > 0)
            {
                rect.Y -= (int)(moveSpeed * deltaTime);
            }
            if ((isSecondPlayer ? kstate.IsKeyDown(Keys.Down) : kstate.IsKeyDown(Keys.S)) && rect.Y < Globals.HEIGHT - rect.Height)
            {
                rect.Y += (int)(moveSpeed * deltaTime);
            }

        }
        public void Draw() {
            Globals.spriteBatch.Draw(Globals.pixel, rect, Color.White);
        }
    }
}
