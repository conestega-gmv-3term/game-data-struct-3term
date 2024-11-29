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

        public static void PlayExplosionSound()
        {
            explosion?.Play();
        }

        public static void PlayGamePlaySong()
        {
            PrepareMediaPlayer(isRepeating: true);
            MediaPlayer.Play(gameplaySong);
        }

        public static void PlayEndGameSong()
        {
            PrepareMediaPlayer();
            MediaPlayer.Play(endgameSong);
        }

        public static void PlayPlayerMovingSound()
        {
            if (playerMovingInstance == null || playerMovingInstance.State != SoundState.Playing)
            {
                playerMovingInstance = playerMoving.CreateInstance();
                playerMovingInstance.IsLooped = true;
                playerMovingInstance.Play();
            }
        }

        public static void StopPlayerMovingSound()
        {
            playerMovingInstance?.Stop();
        }

        public static void SetMusicVolume(float volume)
        {
            MediaPlayer.Volume = MathHelper.Clamp(volume, 0f, 1f);
        }

        public static void SetSoundEffectVolume(float volume)
        {
            if (playerMovingInstance != null) playerMovingInstance.Volume = MathHelper.Clamp(volume, 0f, 1f);
        }

        public static void StopAllSounds()
        {
            MediaPlayer.Stop();
            playerMovingInstance?.Stop();
        }
    }
}
