using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_GameDataStruct.Class
{
    public static class SoundManager
    {
        public static SoundEffect explosion;

        public static SoundEffect playerMoving;
        private static SoundEffectInstance playerMovingInstance;

        public static Song gameplaySong;
        public static Song endgameSong;

        /// <summary>
        /// Method to load all the sound related files into their variables.
        /// </summary>
        /// <param name="explosionSound"></param>
        /// <param name="gameplay"></param>
        /// <param name="endgame"></param>
        /// <param name="playerMoveSound"></param>
        public static void LoadContent(SoundEffect explosionSound, Song gameplay, Song endgame, SoundEffect playerMoveSound)
        {
            explosion = explosionSound;
            gameplaySong = gameplay;
            endgameSong = endgame;
            playerMoving = playerMoveSound;
        }
        
        private static void PrepareMediaPlayer(bool isRepeating = false)
        {
            MediaPlayer.Stop();
            MediaPlayer.IsRepeating = isRepeating;
        }

        /// <summary>
        /// Method to play the explosion sound.
        /// </summary>
        public static void PlayExplosionSound()
        {
            explosion?.Play();
        }

        /// <summary>
        /// Method to play the gameplay song.
        /// </summary>
        public static void PlayGamePlaySong()
        {
            PrepareMediaPlayer(isRepeating: true);
            MediaPlayer.Play(gameplaySong);
        }

        /// <summary>
        /// Method to play the gameend song.
        /// </summary>
        public static void PlayEndGameSong()
        {
            PrepareMediaPlayer();
            MediaPlayer.Play(endgameSong);
        }

        /// <summary>
        /// Method to play the player moving sound effect.
        /// </summary>
        public static void PlayPlayerMovingSound()
        {
            if (playerMovingInstance == null || playerMovingInstance.State != SoundState.Playing)
            {
                playerMovingInstance = playerMoving.CreateInstance();
                playerMovingInstance.IsLooped = true;
                playerMovingInstance.Play();
            }
        }

        /// <summary>
        /// Method to stop the player moving sound effect.
        /// </summary>
        public static void StopPlayerMovingSound()
        {
            playerMovingInstance?.Stop();
        }

        /// <summary>
        /// Method to update the music volume.
        /// </summary>
        /// <param name="volume"></param>
        public static void SetMusicVolume(float volume)
        {
            MediaPlayer.Volume = MathHelper.Clamp(volume, 0f, 1f);
        }

        /// <summary>
        /// Method to update the sound effect volume.
        /// </summary>
        /// <param name="volume"></param>
        public static void SetSoundEffectVolume(float volume)
        {
            if (playerMovingInstance != null) playerMovingInstance.Volume = MathHelper.Clamp(volume, 0f, 1f);
        }

        /// <summary>
        /// Method to stop all sounds.
        /// </summary>
        public static void StopAllSounds()
        {
            MediaPlayer.Stop();
            playerMovingInstance?.Stop();
        }
    }
}
