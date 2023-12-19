using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteFont font;
        private bool keyPressed = false;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = Manager.WIDTH;
            _graphics.PreferredBackBufferHeight = Manager.HEIGHT;
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
            Manager.spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            // the pixel texture
            Manager.pixel = new Texture2D(GraphicsDevice, 1, 1);
            Manager.pixel.SetData(new Color[] { Color.White });

            // text
            font = Content.Load<SpriteFont>("Score");


            var texture = Manager.pixel;
            var custText = Content.Load<Texture2D>("def_collision_texture");

            // setup objects 
            Manager._gameObjects = new List<GameObject>()
            {
                // player one
                new Paddle("Player One", texture) {
                    width = 40,
                    height = 400,
                    position = new Vector2(100,Manager.HEIGHT / 2 - 200),
                    color = Color.White,
                    input = new Input() {
                        Down = Keys.S,
                        Up = Keys.W,
                    }
                },

                //player 2
                new Paddle("Player two",texture) {
                    width = 40,
                    height = 400,
                    position = new Vector2(Manager.WIDTH - 40 - 100,Manager.HEIGHT / 2 - 200),
                    color = Color.White,
                    input = new Input() {
                        Down = Keys.Down,
                        Up = Keys.Up,
                    }
                },

                //ball
                new Ball("ball",custText)
                {
                    width = 40,
                    height = 40,
                    position = new Vector2(0,0),
                    color = Color.White,
                },

                //collision tester
             };
            // copy unity lol
            foreach (var gameObject in Manager._gameObjects)
            {
                gameObject.Start();
            }
            
            GameManager.StartGame();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here


            // NOTE
            // TO LIST CREATES A COPY OF THE LIST SO MODEIYING THE GAMEOBJEECTS
            // FROM THIS SPECIFIC LOOP MAY NOT AFFECT THE ACTUAL GAMEOBJECTS BUT A COPY
            // SHOULD BE FINE?
            foreach (var gameObject in Manager._gameObjects.ToList())
            {
                gameObject.Update(gameTime);
            }

            // debug stuff
            if(Keyboard.GetState().IsKeyDown(Keys.Tab) && !keyPressed) {
                Manager.DEBUGINFO = !Manager.DEBUGINFO;
                keyPressed = true;    
             }
            if(Keyboard.GetState().IsKeyUp(Keys.Tab)) {
                keyPressed = false;
            } 

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            Manager.spriteBatch.Begin();

            Manager.Draw();
            Manager.spriteBatch.DrawString(font, GameManager.getCurScore(), new Vector2(Manager.WIDTH / 2,20), Color.White);
            if(Manager.DEBUGINFO) {
                Manager.spriteBatch.DrawString(font, Manager.getGameObjects(), new Vector2(0, 0), Color.White);
            }

            Manager.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}