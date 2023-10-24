using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private List<GameObject> _gameObjects;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = Globals.WIDTH;
            _graphics.PreferredBackBufferHeight = Globals.HEIGHT;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

        }

        protected override void LoadContent()
        {
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            // the pixel texture
            Globals.pixel = new Texture2D(GraphicsDevice, 1, 1);
            Globals.pixel.SetData(new Color[] { Color.White });

            var texture = Globals.pixel;

            // setup objects 
            _gameObjects = new List<GameObject>()
            {
                // player one
                new Paddle(texture) {
                    width = 20,
                    height = 200,
                    position = new Vector2(0,Globals.HEIGHT / 2 - 100),
                    color = Color.White,
                    input = new Input() {

                        Down = Keys.S,
                        Up = Keys.W,
                    }
                },

                //player 2
                new Paddle(texture) {
                    width = 20,
                    height = 200,
                    position = new Vector2(Globals.WIDTH - 20,Globals.HEIGHT / 2 - 100),
                    color = Color.White,
                    input = new Input() {

                        Down = Keys.Down,
                        Up = Keys.Up,
                    }
                },

                // ball
                new Ball(texture)
                {
                    width = 20,
                    height = 20,
                    position = new Vector2(Globals.WIDTH / 2 - 20,Globals.HEIGHT / 2 - 20),
                    color = Color.Red,
                }
             };

            // copy unity lol

            foreach (var gameObject in _gameObjects)
            {
                gameObject.Start();
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            foreach (var gameObject in _gameObjects)
            {
                gameObject.Update(gameTime);
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            Globals.spriteBatch.Begin();
            foreach(var gameObject in _gameObjects)
            {
                gameObject.Draw(Globals.spriteBatch);
            }
            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}