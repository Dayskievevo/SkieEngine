using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    public abstract class GameObject
    {
        public Texture2D _texture;
        public Vector2 position;
        public Rectangle rect;
        public Color color = Color.White;
        public float speed = 100f;
        public int width, height;
        public Input input;

        public abstract void Start();
        public abstract void Update(GameTime gametime);
        public  void Draw(SpriteBatch spriteBatch)
        {
            rect = new Rectangle((int)position.X, (int)position.Y, width, height);
            spriteBatch.Draw(Globals.pixel, rect, color);
        }
    }
}
