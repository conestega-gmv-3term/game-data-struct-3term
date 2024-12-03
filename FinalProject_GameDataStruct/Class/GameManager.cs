using System;
using Microsoft.Xna.Framework;
using FinalProject_GameDataStruct.Class.GameUI.Screens;

namespace FinalProject_GameDataStruct.Class
{
    internal class GameManager
    {
        //For the time of the Game
        private TimeSpan elapsedTime;
        static public int secondsElapsed;

        static public Status previousStatus = new Status(); //Previous status of the Game
        static public Status Status = Status.gameStarted; //Manager the status of the game
        static public GameUI.GameUI gameUI; //Manager the pages
        static public int score; //Score of the Game

        //Screens
        static public GameUI.Screens.MenuScreen menuScreen = new GameUI.Screens.MenuScreen();
        static public GameUI.Screens.PauseScreen pauseScreen = new GameUI.Screens.PauseScreen();
        static public GameUI.Screens.FinalScreen FinalScreen = new GameUI.Screens.FinalScreen();
        static public GameUI.Screens.ControlsScreen controlsScreen = new GameUI.Screens.ControlsScreen();
        static public GameUI.Screens.GameScreen gameScreen = new GameUI.Screens.GameScreen();

        //Manager the sounds in the game
        static public bool isPlayingSong = false;

        //Help to make the buttons in the PauseScreen
        static public bool isPaused = false;

        public GameManager()
        {
            elapsedTime = TimeSpan.Zero;
            secondsElapsed = 0;
        }

        public void Update()
        {
            if (Status == Status.gameStarted) //MenuScreen
            {
                previousStatus = Status.gameStarted;
                menuScreen.Update();
            }
            if (Status == Status.gameIsPlayed) //GameScreen
            {
                if (!isPlayingSong)
                {
                    SoundManager.PlayGamePlaySong();
                    isPlayingSong = true;
                }
            }
            if (Status == Status.gamePaused) //PauseScreen
            {
                previousStatus = Status.gamePaused;
                SoundManager.StopAllSounds();
                pauseScreen.Update();
                isPlayingSong = false;
            }
            if (Status == Status.gameEnded) //FinalScreen
            {
                if (!isPlayingSong)
                {
                    SoundManager.PlayEndGameSong();
                    isPlayingSong = true;
                }
            }
        }
        public void DrawScreen() //Draw all screens
        {
            if (Status == Status.gameStarted) //MenuScreen
            {
                gameUI.DrawScreen(menuScreen);
            }
            if (Status==Status.gameIsPlayed) //GameScreen
            {
                gameUI.DrawScreen(gameScreen);
            }
            if (Status == Status.gamePaused) //PauseScreen
            {
                if (!isPaused)
                {
                    GameUI.GameUI.SecondDraw = false;
                    isPaused = true;
                }
                gameUI.DrawScreen(pauseScreen);
            }
            if (Status == Status.gameControls) //ControlsScreen
            {
                gameUI.DrawScreen(controlsScreen);
            }
            if (Status == Status.gameEnded) //FinalScreen
            {
                gameUI.DrawScreen(FinalScreen);
            }
        }
        public int updateTime(GameTime gameTime) //Update time
        {
            elapsedTime += gameTime.ElapsedGameTime;

            if (elapsedTime.TotalSeconds >= 1 && Status == Status.gameIsPlayed)
            {
                secondsElapsed++;
                elapsedTime = TimeSpan.Zero;
            }
            return secondsElapsed;
        }

    }
}
