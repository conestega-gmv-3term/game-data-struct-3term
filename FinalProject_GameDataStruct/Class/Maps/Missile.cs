using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace FinalProject_GameDataStruct.Class.Maps
{
    public class Missile
    {
        public Vector2 Position;
        public float Speed { get; set; }
        public int Width { get; set; } = 32;
        public int Height { get; set; } = 32;

        public enum MissileState { Falling, Exploding, Finished }
        public MissileState State { get; private set; } = MissileState.Falling;

        private Texture2D MissileTexture;
        private Texture2D ExplosionTexture;

        private Dictionary<string, Animation> animations;
        private Animation currentAnimation;
        int tileSize = 16;
        int tileSizeExplosion = 64;
        private float targetY;

        public Rectangle CollisionBox => new Rectangle((int)Position.X, (int)Position.Y, Width, Height);

        public Missile(float targetY, Texture2D missileTexture, Texture2D explosionTexture)
        {
            animations = new Dictionary<string, Animation>();

            this.targetY = targetY;
            MissileTexture = missileTexture;
            ExplosionTexture = explosionTexture;

            SetAnimations();
        }

        /// <summary>
        /// This method will update the missile position.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (State == MissileState.Falling)
            {
                Position.Y += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (Position.Y >= targetY)
                {
<<<<<<< HEAD
                    SetExplodingState(); // Use ChangeState to transition
=======
                    State = MissileState.Exploding; // Use ChangeState to transition
                    SoundManager.PlayExplosionSound();
>>>>>>> 35a684729093e93c434de40aac638c6ad54d1796
                }
            }
            else if (State == MissileState.Exploding)
            {
                currentAnimation.Update(gameTime);

                if (currentAnimation.IsFinished)
                {
                    State = MissileState.Finished;
                }
            }
        }
        /// <summary>
        /// Method to set the animations for the missile.
        /// </summary>
        public void SetAnimations()
        {
            animations["Falling"] = new Animation(new List<Rectangle>
            {
                new Rectangle(2 * tileSize, 4 * tileSize, tileSize, tileSize),
            }, 0.2f, true);
            animations["Exploding"] = new Animation(new List<Rectangle>
            {
                new Rectangle(0 * tileSizeExplosion, 0 * tileSizeExplosion, tileSizeExplosion, tileSizeExplosion),
                new Rectangle(0 * tileSizeExplosion, 1 * tileSizeExplosion, tileSizeExplosion, tileSizeExplosion),
                new Rectangle(0 * tileSizeExplosion, 2 * tileSizeExplosion, tileSizeExplosion, tileSizeExplosion),
                new Rectangle(0 * tileSizeExplosion, 3 * tileSizeExplosion, tileSizeExplosion, tileSizeExplosion),
                new Rectangle(0 * tileSizeExplosion, 4 * tileSizeExplosion, tileSizeExplosion, tileSizeExplosion)
            }, 0.2f, false);

            currentAnimation = animations["Falling"];
        }

        /// <summary>
        /// Method to draw the missile based on its state.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (State == MissileState.Falling)
            {
                currentAnimation = animations["Falling"];
                spriteBatch.Draw(MissileTexture, CollisionBox, currentAnimation.GetCurrentFrame(), Color.White);
                
            }
            else if (State == MissileState.Exploding)
            {
                currentAnimation = animations["Exploding"];
                spriteBatch.Draw(ExplosionTexture, CollisionBox, currentAnimation.GetCurrentFrame(), Color.White);
            }            
        }

        public void SetExplodingState()
        {
            State = MissileState.Exploding;
        }

    }
}
