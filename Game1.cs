using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        Paddle paddle, paddle2;
        Ball ball;
        SpriteFont font;
        Globals.GAME_STATE state;

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
            paddle = new Paddle(false);
            paddle2 = new Paddle(true);
            ball = new Ball();
            base.Initialize();

            state = Globals.GAME_STATE.MENU;
        }

        protected override void LoadContent()
        {
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Globals.pixel = new Texture2D(GraphicsDevice, 1, 1);
            Globals.pixel.SetData(new Color[] { Color.White });

            font = Content.LoadLocalized<SpriteFont>("Score");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            switch (state)
            {
                case Globals.GAME_STATE.MENU:
                    {
                        if(Keyboard.GetState().IsKeyDown(Keys.E)) { state = Globals.GAME_STATE.GAME; }
                        break;
                    }
                case Globals.GAME_STATE.GAME:
                    {
                        paddle.Update(gameTime);
                        paddle2.Update(gameTime);
                        ball.Update(gameTime, paddle, paddle2);
                        break;
                    }
                case Globals.GAME_STATE.OVER:
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.E)) { state = Globals.GAME_STATE.GAME; }
                        break;
                    }
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            Globals.spriteBatch.Begin();
            // add drawing

            switch (state)
            {
                case Globals.GAME_STATE.MENU:
                    {
                        Globals.spriteBatch.DrawString(font, "Main Menu XD\n   Press 'E' To Start", new Vector2(Globals.WIDTH / 2 - 50, Globals.HEIGHT / 2 - 50), Color.White);
                        break;
                    }
                case Globals.GAME_STATE.GAME:
                    {
                        paddle.Draw();
                        paddle2.Draw();
                        ball.Draw();

                        Globals.spriteBatch.DrawString(font, Globals.player1_score.ToString(), new Vector2(100, 50), Color.White);
                        Globals.spriteBatch.DrawString(font, Globals.player2_score.ToString(), new Vector2(Globals.WIDTH - 112, 50), Color.White);
                        break;
                    }
                case Globals.GAME_STATE.OVER:
                    {
                        Globals.spriteBatch.DrawString(font, "lol", new Vector2(Globals.WIDTH / 2 - 50, Globals.HEIGHT / 2 - 50), Color.White);
                        break;
                    }
            }

            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}