using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_GameDataStruct.Class.EnemyClasses
{
    public class EnemyManager
    {
        public List<EnemyBase> enemies; // List of all enemies
        private Texture2D enemyTexture;  // Texture for enemies
        private System.Numerics.Vector2 spawnArea;       // Defines the spawn area for random positioning
        private Random random;
        private float spawnTimer;        // Timer to control spawn frequency
        private float spawnInterval = 3f;
        private List<Microsoft.Xna.Framework.Vector2> enemySpawns;

        public EnemyManager(Texture2D enemyTexture)
        {
            this.enemyTexture = enemyTexture;
            this.enemies = new List<EnemyBase>();
            this.random = new Random((int)DateTime.Now.Ticks);
            this.spawnTimer = 0f; // Start with a timer at 0
            enemySpawns = new List<Microsoft.Xna.Framework.Vector2>
            {
                new Microsoft.Xna.Framework.Vector2(128,256), // Left top

                new Microsoft.Xna.Framework.Vector2(128,960), // Left bottom               

                new Microsoft.Xna.Framework.Vector2(896,256), // Right Top        
            
                new Microsoft.Xna.Framework.Vector2(896,960) // Right Bottom
            };
        }

        public void Update(GameTime gameTime, Microsoft.Xna.Framework.Vector2 playerPosition)
        {

            if (enemies == null)
            {
                Console.WriteLine("enemies list is null!");
                enemies = new List<EnemyBase>(); // Re-initialize the list if needed
            }

            // Update the spawn timer
            spawnTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // If the timer exceeds the spawn interval, spawn a new enemy
            if (spawnTimer >= spawnInterval)
            {
                int randomIndex = random.Next(enemySpawns.Count);
                Microsoft.Xna.Framework.Vector2 spawnArea = enemySpawns[randomIndex];

                // Create a new enemy with random spawn position
                EnemyBase newEnemy = new EnemyBase(enemyTexture, spawnArea, 80, 100);
                enemies.Add(newEnemy);

                // Reset the spawn timer
                spawnTimer = 0f;
            }

            // Update each enemy's location towards the player
            foreach (var enemy in enemies.ToList())
            {
                enemy.UpdateEnemyLocation(playerPosition, gameTime);
            }

            // Remove dead enemies
            enemies.RemoveAll(e => !e.IsAlive);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var enemy in enemies)
            {
                enemy.DrawEnemy(spriteBatch);
            }
        }

        public List<EnemyBase> GetEnemies()
        {
            return enemies;
        }
    }
}
