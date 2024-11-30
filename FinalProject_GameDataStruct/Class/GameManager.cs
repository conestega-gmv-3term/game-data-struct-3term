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
using FinalProject_GameDataStruct.Class.GameUI;
using FinalProject_GameDataStruct.Class.GameUI.Screens;

namespace FinalProject_GameDataStruct.Class
{
    internal class GameManager
    {
        static public Status Status = Status.gameStarted; //Manager the status of the game
        static public GameUI.GameUI gameUI; //Manager the pages

        //Screens
        static public GameUI.Screens.MenuScreen menuScreen = new GameUI.Screens.MenuScreen();
        static public GameUI.Screens.PauseScreen pauseScreen = new GameUI.Screens.PauseScreen();
        static public GameUI.Screens.FinalScreen FinalScreen = new GameUI.Screens.FinalScreen();

        //Manager the background and sounds in the game
        static public bool isPlayingSong= false;

        public GameManager()
        {

        }

        public void Update()
        {
            if (Status == Status.gameStarted) 
            {
                menuScreen.Update();
            }
            if (Status == Status.gameIsPlayed) 
            {
                if (!isPlayingSong)
                {
                    SoundManager.PlayGamePlaySong();
                    isPlayingSong = true;
                }
            }
            if (Status == Status.gamePaused)
            {
                SoundManager.StopAllSounds();
                isPlayingSong = false;
            }
            if (Status == Status.gameEnded && !isPlayingSong)
            {
                SoundManager.StopAllSounds();
                SoundManager.PlayEndGameSong();
                isPlayingSong = true;
            }
        }
        public void DrawScreen() //Draw all screens
        {
            if (Status == Status.gameStarted)
            {
                gameUI.DrawScreen(menuScreen);
            }
            if (Status == Status.gamePaused)
            {
                gameUI.DrawScreen(pauseScreen);
            }
            if (Status == Status.gameEnded)
            {
                gameUI.DrawScreen(FinalScreen);
            }
        }

    }
}
