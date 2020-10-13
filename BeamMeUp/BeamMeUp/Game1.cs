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

namespace BeamMeUp
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //Declare rectangle and texture for Star Trek Image
        Texture2D starTrek;
        Rectangle starTrekRect;
        //Declare the sounds
        SoundEffect sound1;
        SoundEffect sound2;
        SoundEffect sound3;
        SoundEffect sound4;
        SoundEffect sound5;
        //Dec;are the old keyboard so that it can be compared to the new keyboard state
        KeyboardState oldKB;
        //Declare font which will be used for the text
        SpriteFont font;
        //The delay is used so multiple sounds aren't played at once
        int delay;
        //Represents whether or not there is currently a delay
        bool delayTrue;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            //Initialize old keyboard to current state
            oldKB = Keyboard.GetState();

            //Create rectangle
            starTrekRect = new Rectangle(450, 50, 330, 400);
            //Set default values
            delay = 180;
            delayTrue = false;

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
            //Initialize all the sound files
            sound1 = Content.Load<SoundEffect>("tng_transporter1");
            sound2 = Content.Load<SoundEffect>("tos_phaser_ricochet");
            sound3 = Content.Load<SoundEffect>("tos_phaser_stun");
            sound4 = Content.Load<SoundEffect>("tos_red_alert_3");
            sound5 = Content.Load<SoundEffect>("tng_tricorder10");

            //Initialize texture
            starTrek = Content.Load<Texture2D>("Star Trek");
            //Initialize font
            font = this.Content.Load<SpriteFont>("SpriteFont1");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //Get current KeyBoard State
            KeyboardState kb = Keyboard.GetState();
            //If the delay is set to true subtract from it
            if (delayTrue == true)
            {
                delay--;
                //If the delay reaches 0,reset it
                if (delay == 0)
                {
                    delayTrue = false;
                    delay = 180;
                }

            }
            //If there isn't a delay sounds can be played
            if (delayTrue == false)
            {

                if (kb.IsKeyDown(Keys.A) && !oldKB.IsKeyDown(Keys.A))
                {
                    sound1.Play();
                    delayTrue = true;
                }
                if (kb.IsKeyDown(Keys.B) && !oldKB.IsKeyDown(Keys.B))
                {
                    sound2.Play();
                    delayTrue = true;
                }
                if (kb.IsKeyDown(Keys.C) && !oldKB.IsKeyDown(Keys.C))
                {
                    sound3.Play();
                    delayTrue = true;
                }
                if (kb.IsKeyDown(Keys.D) && !oldKB.IsKeyDown(Keys.D))
                {
                    sound4.Play();
                    delayTrue = true;
                }
                if (kb.IsKeyDown(Keys.E) && !oldKB.IsKeyDown(Keys.E))
                {
                    sound5.Play();
                    delayTrue = true;
                }

            }

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            //Update old keyboard to be current value of keyboard state
            oldKB = kb;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            //Draw the image
            spriteBatch.Draw(starTrek, starTrekRect, Color.White);
            //Draw the Strings
            spriteBatch.DrawString(font, "Press A for Transporter 1", new Vector2(5, 20), Color.Black);
            spriteBatch.DrawString(font, "Press B for Tricorder 10", new Vector2(5, 120), Color.Black);
            spriteBatch.DrawString(font, "Press C for Phaser Ricochet", new Vector2(5, 220), Color.Black);
            spriteBatch.DrawString(font, "Press D for Phaser Stun", new Vector2(5, 320), Color.Black);
            spriteBatch.DrawString(font, "Press E for Red Alert 3", new Vector2(5, 420), Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
