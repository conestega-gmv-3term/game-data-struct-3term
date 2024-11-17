using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_GameDataStruct.Class.EnemyClasses.Enemy
{
    internal class BasicEnemy : Enemy
    {
        public BasicEnemy(Texture2D enemyImage, Vector2 enemyPosition) : base(enemyImage, enemyPosition)
        {
            this.speed = 2;
        }
    }
}
