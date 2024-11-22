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

        Vector2 PlayerPosition;
        private float speed;

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
        public void UpdatePlayerLocation(KeyboardState keystate, GameTime gameTime)
        {
            velocity = Vector2.Zero;
            bool isMoving = false;

            if (keystate.IsKeyDown(Keys.Right) || keystate.IsKeyDown(Keys.D))
            {
                velocity.X = 1;
                currentAnimation = animations["WalkingRight"];
                lastDirection = Direction.Right;
                isMoving = true;
            }
            if (keystate.IsKeyDown(Keys.Left) || keystate.IsKeyDown(Keys.A))
            {
                velocity.X = -1;
                currentAnimation = animations["WalkingLeft"];
                lastDirection = Direction.Left;
                isMoving = true;
            }
            if (keystate.IsKeyDown(Keys.Up) || keystate.IsKeyDown(Keys.W))
            {
                velocity.Y = -1;
                currentAnimation = animations["WalkingUp"];
                lastDirection = Direction.Up;
                isMoving = true;
            }
            if (keystate.IsKeyDown(Keys.Down) || keystate.IsKeyDown(Keys.S))
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
                switch (lastDirection)
                {
                    case Direction.Right:
                        currentAnimation = animations["IdleRight"];
                        break;
                    case Direction.Left:
                        currentAnimation = animations["IdleLeft"];
                        break;
                    case Direction.Up:
                        currentAnimation = animations["IdleUp"];
                        break;
                    case Direction.Down:
                    default:
                        currentAnimation = animations["Idle"];
                        break;
                }
            }

            currentAnimation.Update(gameTime);
        }

        public void DrawPlayer(SpriteBatch spriteBatch)
        {
            int display_tilesize = 64;

            Rectangle destRect = new(
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

        public void SetAnimations()
        {
            animations["Idle"] = new Animation(new List<Rectangle>
            {
                new Rectangle(0 * tileSize, 0 * tileSize, tileSize, tileSize),
                new Rectangle(0 * tileSize, 0 * tileSize, tileSize, tileSize),
                new Rectangle(1 * tileSize, 0 * tileSize, tileSize, tileSize),
                new Rectangle(0 * tileSize, 0 * tileSize, tileSize, tileSize),
                new Rectangle(0 * tileSize, 0 * tileSize, tileSize, tileSize)
            }, 0.2f);
            animations["IdleRight"] = new Animation(new List<Rectangle>
            {
                new Rectangle(0 * tileSize, 2 * tileSize, tileSize, tileSize),
                new Rectangle(0 * tileSize, 2 * tileSize, tileSize, tileSize),
                new Rectangle(1 * tileSize, 2 * tileSize, tileSize, tileSize),
                new Rectangle(0 * tileSize, 2 * tileSize, tileSize, tileSize),
                new Rectangle(0 * tileSize, 2 * tileSize, tileSize, tileSize)
            }, 0.2f);
            animations["IdleLeft"] = new Animation(new List<Rectangle>
            {
                new Rectangle(0 * tileSize, 1 * tileSize, tileSize, tileSize),
                new Rectangle(0 * tileSize, 1 * tileSize, tileSize, tileSize),
                new Rectangle(1 * tileSize, 1 * tileSize, tileSize, tileSize),
                new Rectangle(0 * tileSize, 1 * tileSize, tileSize, tileSize),
                new Rectangle(0 * tileSize, 1 * tileSize, tileSize, tileSize)
            }, 0.2f);
            animations["IdleUp"] = new Animation(new List<Rectangle>
            {
                new Rectangle(0 * tileSize, 3 * tileSize, tileSize, tileSize),
                new Rectangle(0 * tileSize, 3 * tileSize, tileSize, tileSize),
                new Rectangle(1 * tileSize, 3 * tileSize, tileSize, tileSize),
                new Rectangle(0 * tileSize, 3 * tileSize, tileSize, tileSize),
                new Rectangle(0 * tileSize, 3 * tileSize, tileSize, tileSize)
            }, 0.2f);

            animations["WalkingDown"] = new Animation(new List<Rectangle>
            {
                new Rectangle(2 * tileSize, 0 * tileSize, tileSize, tileSize),
                new Rectangle(3 * tileSize, 0 * tileSize, tileSize, tileSize),
                new Rectangle(4 * tileSize, 0 * tileSize, tileSize, tileSize)
            }, 0.2f);

            animations["WalkingUp"] = new Animation(new List<Rectangle>
            {
                new Rectangle(4 * tileSize, 3 * tileSize, tileSize, tileSize),
                new Rectangle(3 * tileSize, 3 * tileSize, tileSize, tileSize),
                new Rectangle(2 * tileSize, 3 * tileSize, tileSize, tileSize)
            }, 0.2f);

            animations["WalkingRight"] = new Animation(new List<Rectangle>
            {
                new Rectangle(2 * tileSize, 2 * tileSize, tileSize, tileSize),
                new Rectangle(3 * tileSize, 2 * tileSize, tileSize, tileSize),
                new Rectangle(4 * tileSize, 2 * tileSize, tileSize, tileSize)
            }, 0.2f);

            animations["WalkingLeft"] = new Animation(new List<Rectangle>
            {
                new Rectangle(2 * tileSize, 1 * tileSize, tileSize, tileSize),
                new Rectangle(3 * tileSize, 1 * tileSize, tileSize, tileSize),
                new Rectangle(4 * tileSize, 1 * tileSize, tileSize, tileSize)
            }, 0.2f);

            animations["Happy"] = new Animation(new List<Rectangle>
            {
                new Rectangle(0 * tileSize, 4 * tileSize, tileSize, tileSize),
            }, 0.2f);

            animations["Dead"] = new Animation(new List<Rectangle>
            {
                new Rectangle(1 * tileSize, 4 * tileSize, tileSize, tileSize)
            }, 0.2f);

            // Set default animation
            currentAnimation = animations["Idle"];
        }

        public void PlayerWonAnimation()
        {
            currentAnimation = animations["Happy"];
        }

        public void PlayerLostAnimation()
        {
            currentAnimation = animations["Dead"];
        }

        public void ShootBomb()
        {
            throw new NotImplementedException();
        }
    }
}
