using FinalProject_GameDataStruct.Class.Maps;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;

namespace FinalProject_GameDataStruct
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        GameMap _map;

        Texture2D mapTexture;

        private Dictionary<Vector2, int> floorMap;
        private Dictionary<Vector2, int> topMap;
        private Dictionary<Vector2, int> collisionsMap;
        private Texture2D textureAtlas;
        private Texture2D hitboxTexture;

        //Screen variables
        int screenWidth = 1088;
        int screenHeight = 1152;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.PreferredBackBufferHeight = screenHeight;
            _graphics.ApplyChanges();

            floorMap = LoadMap("../../../Data/Map01_Floor_Layer.csv");
            topMap = LoadMap("../../../Data/Map01_Top_Layer.csv");
            collisionsMap = LoadMap("../../../Data/Map01_Collision.csv");
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            textureAtlas = Content.Load<Texture2D>("Tilemap_Tiles");
            hitboxTexture = Content.Load<Texture2D>("Tilemap_Collision");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            

            DrawTileMap(floorMap, textureAtlas);
            //DrawTileMap(collisionsMap, hitboxTexture);
            DrawTileMap(topMap, textureAtlas);

            _spriteBatch.End();

            base.Draw(gameTime);
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

                for (int x = 0; x < items.Length; x++)
                {
                    if (int.TryParse(items[x], out int value))
                    {
                        result[new Vector2(x, y)] = value;
                    }
                }

                y++;
            }

            return result;
        }

        private void DrawTileMap(Dictionary<Vector2, int> mapToDraw , Texture2D mapTexture)
        {
            int display_tilesize = 64;
            int num_tiles_per_row = 8;
            int pixel_tilesize = 8;

            foreach (var item in mapToDraw)
            {
                if(item.Value > -1)
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

                    _spriteBatch.Draw(mapTexture, destRect, src, Color.White);
                }
                
            }
        }
    }
}
