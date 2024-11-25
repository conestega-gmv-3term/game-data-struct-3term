using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace FinalProject_GameDataStruct.Class.Maps
{
    public class MissileManager
    {
        private List<Missile> missiles = new List<Missile>();
        private Random random = new Random();

        private float spawnTimer = 0f;
        private float spawnInterval = 1f; // Initial spawn interval
        private float difficultyTimer = 0f;
        private float difficultyIncreaseInterval = 10f; // Every 10 seconds

        private Animation explosionAnimation;

        private Texture2D MissileTexture;
        private Texture2D ExplosionTexture;


        public MissileManager(Texture2D missileTexture, Texture2D explosionTexture)
        {
            MissileTexture = missileTexture;
            ExplosionTexture = explosionTexture;
        }

        public void Update(GameTime gameTime)
        {
            spawnTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            difficultyTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Increase difficulty every few seconds
            if (difficultyTimer >= difficultyIncreaseInterval)
            {
                spawnInterval = Math.Max(0.2f, spawnInterval - 0.1f); // Decrease spawn interval
                difficultyTimer = 0f;
            }

            // Spawn new blocks at intervals
            if (spawnTimer >= spawnInterval)
            {
                SpawnMissile();
                spawnTimer = 0f;
            }

            // Update all blocks
            foreach (var missile in missiles)
            {
                missile.Update(gameTime);
            }

            // Remove missiles that are done exploding
            missiles.RemoveAll(missile => missile.State == Missile.MissileState.Finished);
        }

        private void SpawnMissile()
        {
            float x = random.Next(64, Game1.ScreenWidth - 64);
            float speed = random.Next(100, 300);
            float targetY = random.Next(192, Game1.ScreenHeight - 64);

            missiles.Add(new Missile(targetY, MissileTexture, ExplosionTexture)
            {
                Position = new Vector2(x, -32),
                Speed = speed
            });
        }

        public bool CheckCollision(Rectangle playerBox)
        {
            // Check if the player intersects any block
            foreach (var missile in missiles)
            {
                if (missile.CollisionBox.Intersects(playerBox))
                {
                    return true; // Collision detected
                }
            }

            return false; // No collision
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var missile in missiles)
            {
                missile.Draw(spriteBatch);
            }
        }
    }

}
