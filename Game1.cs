using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace PumpkinHunt
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Texture file and current position of the ghost
        private Texture2D ghostTexture;
        private Vector2 ghostPos;

        // texture file and current position of the pumpkin
        private Texture2D pumpkinTexture;
        private Vector2 pumpkinPos;

        // Random number generator to use for determining
        // the position of the next pumpkin
        private Random rng;

        // Current score
        private int score;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            // Makes the window a 9:21 aspect ratio
            _graphics.PreferredBackBufferWidth = 420;
            _graphics.PreferredBackBufferHeight = 980;
            _graphics.ApplyChanges();

            // Sets an the initial position of the ghost
            // to be in the center of the screen
            ghostPos = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
            pumpkinPos = new Vector2(100, 100);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Loads the ghost and pumpkin textures
            ghostTexture = Content.Load<Texture2D>("ghost");
            pumpkinTexture = Content.Load<Texture2D>("pumpkin");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Exits the game if the escape key is pressed
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            // Makes ghost move by pressing arrow keys
            // If the edge of the ghost hits a wall, the ghost
            // will not move farther in that direction
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (ghostPos.X - 3 >= 0)
                {
                    ghostPos.X -= 3;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (ghostPos.X + 67 <= GraphicsDevice.Viewport.Width)
                {
                    ghostPos.X += 3;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (ghostPos.Y - 3 >= 0)
                {
                    ghostPos.Y -= 3;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (ghostPos.Y + 67 <= GraphicsDevice.Viewport.Height)
                {
                    ghostPos.Y += 3;
                }   
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(ghostTexture, ghostPos, Color.White);
            _spriteBatch.Draw(pumpkinTexture, pumpkinPos, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}