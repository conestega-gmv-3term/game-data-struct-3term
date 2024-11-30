using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_GameDataStruct.Class.EnemyClasses
{
    internal class EnemyBase
    {
        Texture2D EnemyImage;
        Vector2 EnemyPosition;
        protected int speed;
        protected int health;

        public EnemyBase(Texture2D enemyImage, Vector2 enemyPosition)
        {
            EnemyImage = enemyImage;
            EnemyPosition = enemyPosition;
            speed = 2;
            health = 1;
        }

        public void UpdateEnemyLocation() { }
        public void DrawEnemy() { }
        public void UpdateHealth() { }
        public void DestroyEnemy() { }
    }
}
