using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_GameDataStruct.Class.EnemyClasses
{
    public class EnemyBase
    {
        private Texture2D EnemyImage;
        private Vector2 EnemyPosition;
        private Vector2 TargetPosition;
        public Rectangle destRect;
        public bool IsAlive { get; set; } = true;

        //Animations
        private Dictionary<string, Animation> animations;
        private Animation currentAnimation;
        int tileSize = 16;

        //protected properties
        protected int speed;
        protected int health;

        private Random random;

        // Constructor

        public EnemyBase(Texture2D enemyImage, Microsoft.Xna.Framework.Vector2 enemyPosition)
        {
            EnemyImage = enemyImage;
            EnemyPosition = enemyPosition;
        }
        public EnemyBase(Texture2D enemyImage, Vector2 spawnArea, int speed, int health)
        {
            this.EnemyImage = enemyImage;
            this.speed = speed;
            this.health = health;

            random = new Random();

            EnemyPosition = spawnArea;

            animations = new Dictionary<string, Animation>();

            //Animation Setup
            SetAnimations();
        }

        public void UpdateEnemyLocation(Vector2 PlayerPosition, GameTime gameTime)
        {
            TargetPosition = PlayerPosition;

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
            if (IsAlive)
            {
                //spriteBatch.Draw(EnemyImage, EnemyPosition, Color.White);
                //spriteBatch.Draw(EnemyImage, new Rectangle((int)EnemyPosition.X, (int)EnemyPosition.Y, 1, EnemyImage.Height), Color.Red);
                //spriteBatch.Draw(EnemyImage, new Rectangle((int)EnemyPosition.X, (int)EnemyPosition.Y, EnemyImage.Width, 1), Color.Red);
                int display_tilesize = 64;

                destRect = new(
                    (int)EnemyPosition.X,
                    (int)EnemyPosition.Y,
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

                spriteBatch.Draw(EnemyImage, destRect, currentAnimation.GetCurrentFrame(), Color.White);
            }
        }

        public Rectangle GetEnemyBounds()
        {
            return new Rectangle((int)EnemyPosition.X, (int)EnemyPosition.Y, EnemyImage.Width -30, EnemyImage.Height -30);
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
            }, 0.2f, true);
            currentAnimation = animations["Idle"];
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
