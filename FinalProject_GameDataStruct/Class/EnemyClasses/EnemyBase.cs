using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_GameDataStruct.Class.EnemyClasses
{
    internal class EnemyBase
    {
        private Texture2D EnemyImage;
        private Vector2 EnemyPosition;
        private Vector2 TargetPosition;

        //protected properties
        protected int speed;
        protected int health;

        private Random random;

        // Constructor
        public EnemyBase(Texture2D enemyImage, Vector2 spawnArea, int speed, int health)
        {
            this.EnemyImage = enemyImage;
            this.speed = speed;
            this.health = health;

            random = new Random();

            // Randomly spawn the enemy within the given spawn area
            EnemyPosition = new Vector2(random.Next(0, (int)spawnArea.X), random.Next(0, (int)spawnArea.Y));
        }

        public EnemyBase(Texture2D enemyImage, System.Numerics.Vector2 enemyPosition)
        {
            EnemyImage = enemyImage;
            EnemyPosition = enemyPosition;
        }

        public void UpdateEnemyLocation(Vector2 playerPosition, GameTime gameTime) 
        {
            TargetPosition = playerPosition;

            // Calculate the direction vector from the enemy to the player
            Vector2 direction = TargetPosition - EnemyPosition;

            // Move the enemy towards the player if the distance is greater than 0
            if (direction.Length() > 0)
            {
                direction.Normalize(); // Normalize to get a unit direction vector
                EnemyPosition += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }
        public void DrawEnemy(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(EnemyImage, EnemyPosition, Color.White);
        }
        public void UpdateHealth(int damage) 
        {
            health -= damage;
            if (health <= 0)
            {
                DestroyEnemy();
            }
        }
        public void DestroyEnemy() 
        {
            // For now, we'll just print a message to the console
            Console.WriteLine("Enemy Destroyed!");
        }

        public Vector2 GetPosition()
        {
            return EnemyPosition;
        }

        public int GetHealth()
        {
            return health;
        }
    }
}
