using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_GameDataStruct.Class.Maps
{
    public class MissileManager
    {
        private List<Missile> blocks = new List<Missile>();
        private Random random = new Random();

        private float spawnTimer = 0f;
        private float spawnInterval = 1f; // Initial spawn interval
        private float difficultyTimer = 0f;
        private float difficultyIncreaseInterval = 10f; // Every 10 seconds

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
                SpawnBlock();
                spawnTimer = 0f;
            }

            // Update all blocks
            foreach (var block in blocks)
            {
                block.Update(gameTime);
            }

            // Remove blocks that have gone off-screen
            blocks.RemoveAll(block =>
            {
                if (block.Position.Y > Game1.ScreenHeight)
                {
                    // Placeholder for increasing the score
                    // GameManager.Instance.IncreaseScore(); // Uncomment once GameManager is implemented
                    return true; // Remove block
                }
                return false;
            });
        }

        private void SpawnBlock()
        {
            float x = random.Next(0, Game1.ScreenWidth - 32); // Random X position
            float speed = random.Next(100, 300); // Random speed

            blocks.Add(new Missile
            {
                Position = new Vector2(x, -32), // Start above the screen
                Speed = speed
            });
        }

        public bool CheckCollision(Rectangle playerBox)
        {
            // Check if the player intersects any block
            foreach (var block in blocks)
            {
                if (block.CollisionBox.Intersects(playerBox))
                {
                    return true; // Collision detected
                }
            }

            return false; // No collision
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D blockTexture)
        {
            foreach (var block in blocks)
            {
                block.Draw(spriteBatch, blockTexture);
            }
        }
    }

}
