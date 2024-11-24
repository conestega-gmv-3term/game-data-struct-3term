using FinalProject_GameDataStruct.Class;
using FinalProject_GameDataStruct.Class.Maps;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace FinalProject_GameDataStruct
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Map Related
        Dictionary<string ,GameMap> _maps;
        GameMap _currentMap;
        Texture2D _mapTexture;
        private Dictionary<Vector2, int> collisions;

        //Player Related
        Texture2D _playerTexture;
        Player _player;
        private List<Rectangle> intersections;

        //Screen variables
        public static int ScreenWidth = 1088;
        public static int ScreenHeight = 1088;

        private Texture2D rectangleTexture;

        //Blocks
        private MissileManager _missileManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = ScreenWidth;
            _graphics.PreferredBackBufferHeight = ScreenHeight;
            _graphics.ApplyChanges();

            _maps = new Dictionary<string, GameMap>();
            _missileManager = new MissileManager();

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //Map Related
            _mapTexture = Content.Load<Texture2D>("Tilemap_Tiles");

            _maps.Add("map01", new GameMap(
                "../../../Data/Map01_Floor_Layer.csv",
                "../../../Data/Map01_Top_Layer.csv",
                "../../../Data/Map01_Collision.csv",
                _mapTexture
            ));

            _currentMap = _maps["map01"];

            //Player Related
            _playerTexture = Content.Load<Texture2D>("Character_Chart");
            _player = new Player(_playerTexture, new Vector2 (128,192));            


            rectangleTexture = new Texture2D(GraphicsDevice, 1, 1);
            rectangleTexture.SetData(new Color[] { new(255, 0, 0, 255) });


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            _player.UpdatePlayerLocation(Keyboard.GetState(), gameTime);


            // Update blocks
            _missileManager.Update(gameTime);

            // Check collisions
            if (_missileManager.CheckCollision(_player.destRect))
            {
                Console.WriteLine("Game Over!");
                Exit(); // End the game on collision
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            _currentMap.DrawCompleteMap(_spriteBatch);


            _player.DrawPlayer(_spriteBatch);

            _missileManager.Draw(_spriteBatch, rectangleTexture);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void DrawRectHollow(SpriteBatch spriteBatch, Rectangle rect, int thickness)
        {
            spriteBatch.Draw(
                rectangleTexture,
                new Rectangle(
                    rect.X,
                    rect.Y,
                    rect.Width,
                    thickness
                ),
                Color.White
            );
            spriteBatch.Draw(
                rectangleTexture,
                new Rectangle(
                    rect.X,
                    rect.Bottom - thickness,
                    rect.Width,
                    thickness
                ),
                Color.White
            );
            spriteBatch.Draw(
                rectangleTexture,
                new Rectangle(
                    rect.X,
                    rect.Y,
                    thickness,
                    rect.Height
                ),
                Color.White
            );
            spriteBatch.Draw(
                rectangleTexture,
                new Rectangle(
                    rect.Right - thickness,
                    rect.Y,
                    thickness,
                    rect.Height
                ),
                Color.White
            );
        }

    }
}
