using FinalProject_GameDataStruct.Class;
using FinalProject_GameDataStruct.Class.GameUI;
using FinalProject_GameDataStruct.Class.GameUI.Screens;
using FinalProject_GameDataStruct.Class.Maps;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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
        private GameManager _gameManager;
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
        public static int ScreenHeight = 1152;

        private Texture2D rectangleTexture;

        //Blocks
        private MissileManager _missileManager;
        private Texture2D MissileTexture;
        private Texture2D ExplosionTexture;
        private Texture2D background;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = ScreenWidth;
            _graphics.PreferredBackBufferHeight = ScreenHeight;
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
            GameManager.gameUI = new GameUI(_spriteBatch, Content);
            _gameManager = new GameManager();

            //Textures

            //Map Related
            _mapTexture = Content.Load<Texture2D>("Tilemap");
            //Player Related
            _playerTexture = Content.Load<Texture2D>("Character_Chart");
            //Missile Related
            MissileTexture = Content.Load<Texture2D>("Enemy_Chart");
            ExplosionTexture = Content.Load<Texture2D>("explosion");

            //Objects
            //Map Related
            _maps.Add("map01", new GameMap("../../../Data/Map01_Complete_Ground.csv",_mapTexture));
            _currentMap = _maps["map01"];


            //Player Related
            _player = new Player(_playerTexture, new Vector2(ScreenWidth / 2 - 32, ScreenHeight / 2 - 32));

            //Missile Related            
            _missileManager = new MissileManager(MissileTexture, ExplosionTexture);

            //Sound Related
            SoundManager.LoadContent(
                explosionSound: Content.Load<SoundEffect>("explosion-sound-effectWAV"),
                gameplay: Content.Load<Song>("gameplay-music"),
                endgame: Content.Load<Song>("credits-music"),
                playerMoveSound: Content.Load<SoundEffect>("tank-track-rattelingWAV")
            );
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _gameManager.Update();


            if (GameManager.Status == Status.gameIsPlayed)
            {
                _player.UpdatePlayerLocation(Keyboard.GetState(), gameTime);

                //// Update missiles
                _missileManager.Update(gameTime);

                //// Check collisions
                if (_missileManager.CheckCollision(_player.destRect))
                {
                    Console.WriteLine("Game Over!");
                    GameManager.isPlayingSong = false;
                    GameManager.Status = Status.gameEnded;
                }
            }


            //Game Pause
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Z))
            {
                GameManager.Status = Status.gamePaused;
            }
            if (state.IsKeyDown(Keys.X))
            {
                GameManager.Status = Status.gameIsPlayed;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            if (GameManager.Status != Status.gameEnded && GameManager.Status != Status.gamePaused)
            {
                _currentMap.DrawCompleteMap(_spriteBatch);
            }
            _gameManager.DrawScreen();

            if (GameManager.Status == Status.gameIsPlayed)
            {
                _currentMap.DrawCompleteMap(_spriteBatch);

                _player.DrawPlayer(_spriteBatch);

                _missileManager.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }


        //This method we can use to draw rectangles (good for debugging)
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
