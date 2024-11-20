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
using System.IO;
using Microsoft.Xna.Framework.Content;
using System.Xml.Serialization;

namespace FinalProject_GameDataStruct.Class.Maps
{
    internal class GameMap
    {
        Texture2D BackGroundSprite;
        Vector2 MapPosition;
        List<EnemyBase> MapEnemies;

        private Dictionary<Vector2, int> tilemap;

        private List<Rectangle> textureStore;

        private Texture2D floorTexture;

        public GameMap(Texture2D backGroundSprite) 
        { 
            BackGroundSprite = backGroundSprite;
            //MapPosition = mapPosition;


            floorTexture = backGroundSprite;

            MapEnemies = new List<EnemyBase>();
            tilemap = LoadMap("../../../Data/Map01_Floor_Layer.csv");

            textureStore = new() { 
                new Rectangle(0,0,8,8),
                new Rectangle(0,8,8,8)
            };

        }
        private Dictionary<Vector2, int> LoadMap(string filepath)
        {
            Dictionary<Vector2, int> result = new();

            StreamReader reader = new(filepath);

            string line;
            int y = 0;

            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Split(',');

                for (int x = 0; x < items.Length; x++) {
                    if (int.TryParse(items[x], out int value)) {
                        result[new Vector2(x, y)] = value;
                    }
                }

                y++;
            }

            return result;
        }
        public void DrawMap(SpriteBatch spriteBatch) {

            foreach (var item in tilemap) {
                Rectangle dest = new(
                (int)item.Key.X * 64,
                (int)item.Key.Y * 64,
                    64, 64);



                Rectangle src = textureStore[item.Value - 1];

                spriteBatch.Draw(floorTexture, dest, src, Color.White);
            }

            
        }
        public void SpawnEnemies() { }
    }
}
