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
using FinalProject_GameDataStruct.Class.EnemyClasses.Enemy;
using FinalProject_GameDataStruct.Class.EnemyClasses;

namespace FinalProject_GameDataStruct.Class.Maps
{
    internal class GameMap
    {
        Texture2D BackGroundSprite;
        Vector2 MapPosition;
        List<EnemyBase> MapEnemies;

        public GameMap(Texture2D backGroundSprite, Vector2 mapPosition) 
        { 
            BackGroundSprite = backGroundSprite;
            MapPosition = mapPosition;
            MapEnemies = new List<EnemyBase>();
        }

        public void DrawMap() { }
        public void SpawnEnemies() { }
    }
}
