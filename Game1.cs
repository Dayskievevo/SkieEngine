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
        private SpriteFont font;
        private string ObjectsInScene;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = GameManager.WIDTH;
            _graphics.PreferredBackBufferHeight = GameManager.HEIGHT;
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
            GameManager.spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            // the pixel texture
            GameManager.pixel = new Texture2D(GraphicsDevice, 1, 1);
            GameManager.pixel.SetData(new Color[] { Color.White });

            // text
            font = Content.Load<SpriteFont>("Score");

            var texture = GameManager.pixel;

            // setup objects 
            GameManager._gameObjects = new List<GameObject>()
            {
                // player one
                new Paddle("Player One", texture) {
                    width = 20,
                    height = 200,
                    position = new Vector2(0,GameManager.HEIGHT / 2 - 100),
                    color = Color.White,
                    input = new Input() {
                        Down = Keys.S,
                        Up = Keys.W,
                    }
                },

                //player 2
                new Paddle("Player two",texture) {
                    width = 20,
                    height = 200,
                    position = new Vector2(GameManager.WIDTH - 20,GameManager.HEIGHT / 2 - 100),
                    color = Color.White,
                    input = new Input() {
                        Down = Keys.Down,
                        Up = Keys.Up,
                    }
                },

                // ball
                new Ball("ball",texture)
                {
                    width = 20,
                    height = 20,
                    position = new Vector2(0,0),
                    color = Color.Red,
                },
                //collision tester
                new Dummy("dummy", texture) {
                    width = 30,
                    height = 30,
                    position = new Vector2(0,0),
                    color = Color.Green,
                }
             };

            // copy unity lol
            foreach (var gameObject in GameManager._gameObjects)
            {
                gameObject.Start();
            }

            ObjectsInScene = "Gameobjects: \n";
            foreach(var gameObject in GameManager._gameObjects)
            {
                ObjectsInScene += gameObject.getGameObject() + "\n";
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here

            foreach (var gameObject in GameManager._gameObjects)
            {
                gameObject.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            GameManager.spriteBatch.Begin();

            GameManager.Draw();
            GameManager.spriteBatch.DrawString(font, ObjectsInScene, new Vector2(0, 0), Color.White);

            GameManager.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}