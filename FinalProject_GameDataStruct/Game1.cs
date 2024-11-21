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

        Dictionary<string ,GameMap> _maps;
        GameMap _currentMap;
        Texture2D _mapTexture;

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

            _maps = new Dictionary<string, GameMap>();
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _mapTexture = Content.Load<Texture2D>("Tilemap_Tiles");

            _maps.Add("map01", new GameMap(
                "../../../Data/Map01_Floor_Layer.csv",
                "../../../Data/Map01_Top_Layer.csv",
                "../../../Data/Map01_Collision.csv",
                _mapTexture
            ));

            _currentMap = _maps["map01"];

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

            _currentMap.DrawCompleteMap(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
