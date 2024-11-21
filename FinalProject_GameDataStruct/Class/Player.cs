using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Audio;
using FinalProject_GameDataStruct.Class.Bomb;

namespace FinalProject_GameDataStruct.Class
{
    internal class Player : IBombHandler
    {
        public Texture2D PlayerTexture;
        public Rectangle rect;
        public Rectangle srect;
        public Vector2 velocity;

        int display_tilesize;


        Vector2 PlayerPosition;
        private float speed;
        double radius;


        public Player(Texture2D playerTexture, Vector2 startingPosition)
        {
            PlayerTexture = playerTexture;
            PlayerPosition = startingPosition;          

            velocity = new Vector2(0, 0);
            speed = 200f;

        }
        public void UpdatePlayerLocation(KeyboardState keystate, GameTime gameTime)
        {
            velocity = Vector2.Zero;

            if (keystate.IsKeyDown(Keys.Right))
            {
                velocity.X = 1;
            }
            if (keystate.IsKeyDown(Keys.Left))
            {
                velocity.X = -1;
            }
            if (keystate.IsKeyDown(Keys.Up))
            {
                velocity.Y = -1;
            }
            if (keystate.IsKeyDown(Keys.Down))
            {
                velocity.Y = 1;
            }

            // Normalize velocity to ensure diagonal movement isn't faster
            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }

            // Apply movement scaled by speed and elapsed time
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            PlayerPosition += velocity * speed * deltaTime;
        }

        public void DrawPlayer(SpriteBatch spriteBatch)
        {
            int display_tilesize = 64;
            int num_tiles_per_row = 4;
            int pixel_tilesize = 16;

            Rectangle destRect = new(
                (int)PlayerPosition.X,
                (int)PlayerPosition.Y,
                    display_tilesize,
                    display_tilesize);

            int x = 0;
            int y = 0;

            Rectangle src = new(
                x * pixel_tilesize,
                y * pixel_tilesize,
                pixel_tilesize,
                pixel_tilesize
                );

            spriteBatch.Draw(PlayerTexture, destRect, src, Color.White);
        }

        public void ShootBomb()
        {
            throw new NotImplementedException();
        }
    }
}
