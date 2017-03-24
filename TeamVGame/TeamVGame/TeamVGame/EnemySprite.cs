﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;   //   for Texture2D
using Microsoft.Xna.Framework;  //  for Vector2

namespace TeamVGame
{
    class MediumEnemy
    {
        public Texture2D texture { get; set; } //  Sprite texture, read-only property

        public Vector2 position { get; set; }  //  Sprite position on screen

        public Vector2 size { get; set; }      //  Sprite size in pixels

        public Vector2 velocity { get; set; }  //  Sprite velocity

        private Vector2 screenSize { get; set; } //  screen size

        public float time { get; set; }
        public int frames { get; set; }
       
        public const int E_HEALTH = 100;

        public const int E_POWER = 10;

        public bool E_Die = false;

        // public bool E_Shot = false;

        Random rnd = new Random();


        public int E_GetPower()
        {
            return E_POWER;
        }

        public MediumEnemy(Texture2D newTexture, Vector2 newPosition, Vector2 newSize, int ScreenWidth, int ScreenHeight)
        {
            texture = newTexture;   //Picture "name"
            position = newPosition;
            size = newSize;
            screenSize = new Vector2(ScreenWidth, ScreenHeight);

        }
        public void E_BeAttacked(ProtectSprite ProtectSprite, int CurrentHealth, FireSprite Fire)
        {
            if ((Fire.position.X + Fire.size.X) >= this.position.X)  // if the fire touch the enemy
            {
                //E_Shot = true;
                CurrentHealth -= ProtectSprite.P_GetPower();
            }
            
            if (CurrentHealth == 0)
            {
                E_Die = true;
            }
          
        }

    

        public void E_Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, new Rectangle(200 * frames, 0, 200, 200), Color.White); //Adding the sprite to the batch with the rendured properties of the sprite

        }

        public void Populate()
        {

            position = new Vector2(0f, rnd.Next(1, 6)*200);
            velocity = new Vector2(1,0);
        }


        public void Move()
        {
            position += velocity;

            if (E_Die == false)
            {
                velocity *= 1;
            }
            else if (E_Die ==true)
            {
                position = new Vector2(-1000, 0);
                velocity = new Vector2(0,0);
            }


        }

    }
}
