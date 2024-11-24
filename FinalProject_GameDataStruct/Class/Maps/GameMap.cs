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
        protected Dictionary<Vector2, int> TileMap { get; private set; }
        protected Dictionary<Vector2, int> PropsMap { get; private set; }
        public Dictionary<Vector2, int> CollisionMap { get; private set; }
        protected Texture2D MapTexture { get; private set; }

        public GameMap(string mapFilePath,string propsFilePath,string collistionFilePath, Texture2D mapTexture)
        {
            MapTexture = mapTexture;
            TileMap = LoadMap(mapFilePath);
            PropsMap = LoadMap(propsFilePath);
            CollisionMap = LoadMap(collistionFilePath);
        }

        //Method to extract the map from the csv file
        private Dictionary<Vector2, int> LoadMap(string filepath)
        {
            Dictionary<Vector2, int> result = new();

            StreamReader reader = new(filepath);

            string line;
            int y = 0;

            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Split(',');

                //After spliting every line from the file
                //We set every position with a value for the key, and an Integer that represents the type of image we are extracting from the tilemap
                //Something like this: key(Vector2(0,0) value=0, or key(Vector2(0,1) value=1
                for (int x = 0; x < items.Length; x++) {
                    if (int.TryParse(items[x], out int value)) {
                        result[new Vector2(x, y)] = value;
                    }
                }

                y++;
            }

            return result;
        }

        public void DrawCompleteMap(SpriteBatch spriteBatch)
        {
            
            DrawTileMap(spriteBatch, TileMap);
            DrawTileMap(spriteBatch, PropsMap);

        }
        private void DrawTileMap(SpriteBatch spriteBatch, Dictionary<Vector2, int> map)
        {
            int display_tilesize = 64;
            int num_tiles_per_row = 8;
            int pixel_tilesize = 8;

            foreach (var item in map)
            {
                if (item.Value > -1)
                {
                    Rectangle destRect = new(
                (int)item.Key.X * display_tilesize,
                (int)item.Key.Y * display_tilesize,
                    display_tilesize,
                    display_tilesize);

                    int x = item.Value % num_tiles_per_row;
                    int y = item.Value / num_tiles_per_row;

                    Rectangle src = new(
                        x * pixel_tilesize,
                        y * pixel_tilesize,
                        pixel_tilesize,
                        pixel_tilesize
                        );

                    spriteBatch.Draw(MapTexture, destRect, src, Color.White);
                }

            }
        }

        public Dictionary<Vector2, int> GetCollisionMap()
        {
            return CollisionMap;
        }
        public void SpawnEnemies() { }
    }
}
