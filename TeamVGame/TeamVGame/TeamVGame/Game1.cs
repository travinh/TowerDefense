using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TeamVGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Boolean done = false;
        float elapsed;
        int frames = 0;
        float delay = 200f;

        Texture2D Background;
        Rectangle mainFrame;

        FireSprite Fire1, Fire2, Fire3;
        MediumEnemy E1, E2;
        ProtectSprite P1,P2,P3;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //  changing the back buffer size changes the window size (when in windowed mode)
            graphics.PreferredBackBufferWidth = 2000;
            graphics.PreferredBackBufferHeight = 1400;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);



            // TODO: use this.Content to load your game content here

            //--Backgrounds--
            Background = Content.Load<Texture2D>("Background");
            mainFrame = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            //--Drawing Protect Sprite--
            P1 = new ProtectSprite(Content.Load<Texture2D>("Charizard"), new Vector2(200f, 200f), new Vector2(200f, 200f),
                graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            P2 = new ProtectSprite(Content.Load<Texture2D>("Blastoise"), new Vector2(200f, 400f), new Vector2(200f, 200f),
                graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            P3 = new ProtectSprite(Content.Load<Texture2D>("Bulbasaur"), new Vector2(200f, 600f), new Vector2(200f, 200f),
                graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            //--Drawing Enemy Sprite--
            E1 = new MediumEnemy(Content.Load<Texture2D>("Pidgey"), new Vector2(2000f, 200f), new Vector2(200f, 200f),
               graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            E2 = new MediumEnemy(Content.Load<Texture2D>("Ratata"), new Vector2(2000f, 400f), new Vector2(200f, 200f),
                graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            //--Drawing Fire--
            Fire1 = new FireSprite(Content.Load<Texture2D>("Fire"), new Vector2(400f, 200f), new Vector2(200f, 200f),
               graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            Fire2 = new FireSprite(Content.Load<Texture2D>("Fire"), new Vector2(400f, 400f), new Vector2(200f, 200f),
              graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            Fire3 = new FireSprite(Content.Load<Texture2D>("Fire"), new Vector2(400f, 600f), new Vector2(200f, 200f),
              graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            E1.Populate();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            P1.texture.Dispose();
            P2.texture.Dispose();
            P3.texture.Dispose();
            Fire1.texture.Dispose();
            Fire2.texture.Dispose();
            Fire3.texture.Dispose();
            E1.texture.Dispose();
            E2.texture.Dispose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            

            if (done == false)
            {
                elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (elapsed >= delay) //if time of game is greater then delaty do if statement
                {
                    if (frames >= 5) //if frames are greater then 3 go back to the first.
                    {
                        frames = 0;
                    }
                    else  //otherwise increment frames
                    {
                        frames++;
                    }
                    P1.frames = frames;
                    P2.frames = frames;
                    P3.frames = frames;
                    E1.frames = frames;
                    E2.frames = frames;
                    elapsed = 0; //set time back to zero.
                }
            }
            E1.Move();



            
            base.Update(gameTime);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();


            //MediumEnemy.E_Draw(spriteBatch);
            spriteBatch.Draw(Background, mainFrame, Color.White);
            E1.E_Draw(spriteBatch);
            E2.E_Draw(spriteBatch);
           // E3.E_Draw(spriteBatch);
            //E4.E_Draw(spriteBatch);

            base.Draw(gameTime);

            spriteBatch.End();
        }
    }
}
