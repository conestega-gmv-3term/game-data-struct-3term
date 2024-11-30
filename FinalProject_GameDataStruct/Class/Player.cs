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
    internal class Player
    {
        public Texture2D PlayerTexture;
        public Rectangle destRect;
        public Rectangle srect;
        public Vector2 velocity;

        public Vector2 PlayerPosition;
        public float speed;

        //Animations
        private Dictionary<string, Animation> animations;
        private Animation currentAnimation;
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
        private Direction lastDirection = Direction.Down;

        int tileSize = 16;

        public Player(Texture2D playerTexture, Vector2 startingPosition)
        {
            PlayerTexture = playerTexture;
            PlayerPosition = startingPosition;          

            velocity = new Vector2(0, 0);
            speed = 200f;

            animations = new Dictionary<string, Animation>();

            //Animation Setup
            SetAnimations();            
        }

        /// <summary>
        /// Method to update the player location.
        /// </summary>
        /// <param name="keystate"></param>
        /// <param name="gameTime"></param>
        public void UpdatePlayerLocation(KeyboardState keystate, GameTime gameTime)
        {
            velocity = Vector2.Zero;
            bool isMoving = false;

            if ((keystate.IsKeyDown(Keys.Right) || keystate.IsKeyDown(Keys.D)))
            {
                velocity.X = 1;
                currentAnimation = animations["WalkingRight"];
                lastDirection = Direction.Right;
                isMoving = true;
            }
            if ((keystate.IsKeyDown(Keys.Left) || keystate.IsKeyDown(Keys.A)))
            {
                velocity.X = -1;
                currentAnimation = animations["WalkingLeft"];
                lastDirection = Direction.Left;
                isMoving = true;
            }
            if ((keystate.IsKeyDown(Keys.Up) || keystate.IsKeyDown(Keys.W)))
            {
                velocity.Y = -1;
                currentAnimation = animations["WalkingUp"];
                lastDirection = Direction.Up;
                isMoving = true;
            }
            if ((keystate.IsKeyDown(Keys.Down) || keystate.IsKeyDown(Keys.S)) 

             )
            {
                velocity.Y = 1;
                currentAnimation = animations["WalkingDown"];
                lastDirection = Direction.Down;
                isMoving = true;
            }

            // Normalize velocity to ensure diagonal movement isn't faster
            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }

            // Apply movement scaled by speed and elapsed time
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            PlayerPosition += velocity * speed * deltaTime;

            // Handle Idle animation based on last direction
            if (!isMoving)
            {
                currentAnimation = animations[GetIdleAnimationKey()];
            }

            currentAnimation.Update(gameTime);

            PlayerPosition.X = MathHelper.Clamp(PlayerPosition.X, 0 + 64, Game1.ScreenWidth - destRect.Width-64);
            PlayerPosition.Y = MathHelper.Clamp(PlayerPosition.Y, 0 + 192, Game1.ScreenHeight - destRect.Height-64);
        }

        /// <summary>
        /// Method to draw the player.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void DrawPlayer(SpriteBatch spriteBatch)
        {
            int display_tilesize = 64;

            destRect = new(
                (int)PlayerPosition.X,
                (int)PlayerPosition.Y,
                    display_tilesize,
                    display_tilesize);

            int x = 0;
            int y = 0;

            Rectangle src = new(
                x * tileSize,
                y * tileSize,
                tileSize,
                tileSize
                );

            spriteBatch.Draw(PlayerTexture, destRect, currentAnimation.GetCurrentFrame(), Color.White);
        }

        /// <summary>
        /// Method to set the player animations.
        /// 
        /// </summary>
        public void SetAnimations()
        {
            animations["Idle"] = new Animation(new List<Rectangle>
            {
                new Rectangle(0 * tileSize, 0 * tileSize, tileSize, tileSize),
                new Rectangle(0 * tileSize, 0 * tileSize, tileSize, tileSize),
                new Rectangle(1 * tileSize, 0 * tileSize, tileSize, tileSize),
                new Rectangle(0 * tileSize, 0 * tileSize, tileSize, tileSize),
                new Rectangle(0 * tileSize, 0 * tileSize, tileSize, tileSize)
            }, 0.2f, true);
            animations["IdleRight"] = new Animation(new List<Rectangle>
            {
                new Rectangle(0 * tileSize, 2 * tileSize, tileSize, tileSize),
                new Rectangle(0 * tileSize, 2 * tileSize, tileSize, tileSize),
                new Rectangle(1 * tileSize, 2 * tileSize, tileSize, tileSize),
                new Rectangle(0 * tileSize, 2 * tileSize, tileSize, tileSize),
                new Rectangle(0 * tileSize, 2 * tileSize, tileSize, tileSize)
            }, 0.2f, true);
            animations["IdleLeft"] = new Animation(new List<Rectangle>
            {
                new Rectangle(0 * tileSize, 1 * tileSize, tileSize, tileSize),
                new Rectangle(0 * tileSize, 1 * tileSize, tileSize, tileSize),
                new Rectangle(1 * tileSize, 1 * tileSize, tileSize, tileSize),
                new Rectangle(0 * tileSize, 1 * tileSize, tileSize, tileSize),
                new Rectangle(0 * tileSize, 1 * tileSize, tileSize, tileSize)
            }, 0.2f, true);
            animations["IdleUp"] = new Animation(new List<Rectangle>
            {
                new Rectangle(0 * tileSize, 3 * tileSize, tileSize, tileSize),
                new Rectangle(0 * tileSize, 3 * tileSize, tileSize, tileSize),
                new Rectangle(1 * tileSize, 3 * tileSize, tileSize, tileSize),
                new Rectangle(0 * tileSize, 3 * tileSize, tileSize, tileSize),
                new Rectangle(0 * tileSize, 3 * tileSize, tileSize, tileSize)
            }, 0.2f, true);

            animations["WalkingDown"] = new Animation(new List<Rectangle>
            {
                new Rectangle(2 * tileSize, 0 * tileSize, tileSize, tileSize),
                new Rectangle(3 * tileSize, 0 * tileSize, tileSize, tileSize),
                new Rectangle(4 * tileSize, 0 * tileSize, tileSize, tileSize)
            }, 0.2f, true);

            animations["WalkingUp"] = new Animation(new List<Rectangle>
            {
                new Rectangle(4 * tileSize, 3 * tileSize, tileSize, tileSize),
                new Rectangle(3 * tileSize, 3 * tileSize, tileSize, tileSize),
                new Rectangle(2 * tileSize, 3 * tileSize, tileSize, tileSize)
            }, 0.2f, true);

            animations["WalkingRight"] = new Animation(new List<Rectangle>
            {
                new Rectangle(2 * tileSize, 2 * tileSize, tileSize, tileSize),
                new Rectangle(3 * tileSize, 2 * tileSize, tileSize, tileSize),
                new Rectangle(4 * tileSize, 2 * tileSize, tileSize, tileSize)
            }, 0.2f, true);

            animations["WalkingLeft"] = new Animation(new List<Rectangle>
            {
                new Rectangle(2 * tileSize, 1 * tileSize, tileSize, tileSize),
                new Rectangle(3 * tileSize, 1 * tileSize, tileSize, tileSize),
                new Rectangle(4 * tileSize, 1 * tileSize, tileSize, tileSize)
            }, 0.2f, true);

            animations["Happy"] = new Animation(new List<Rectangle>
            {
                new Rectangle(0 * tileSize, 4 * tileSize, tileSize, tileSize),
            }, 0.2f, true);

            animations["Dead"] = new Animation(new List<Rectangle>
            {
                new Rectangle(1 * tileSize, 4 * tileSize, tileSize, tileSize)
            }, 0.2f, true);

            // Set default animation
            currentAnimation = animations["Idle"];
        }

        /// <summary>
        /// Method to set the current idle animation.
        /// </summary>
        /// <returns></returns>
        private string GetIdleAnimationKey()
        {
            return lastDirection switch
            {
                Direction.Right => "IdleRight",
                Direction.Left => "IdleLeft",
                Direction.Up => "IdleUp",
                Direction.Down or _ => "Idle"
            };
        }

        /// <summary>
        /// Method to set the Victory animation.
        /// </summary>
        public void PlayerWonAnimation()
        {
            currentAnimation = animations["Happy"];
        }

        /// <summary>
        /// Method to set the lost animation.
        /// </summary>
        public void PlayerLostAnimation()
        {
            currentAnimation = animations["Dead"];
        }

    }
}
