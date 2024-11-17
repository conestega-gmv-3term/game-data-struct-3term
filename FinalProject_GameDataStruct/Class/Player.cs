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
using FinalProject_GameDataStruct.Class.Bomb;

namespace FinalProject_GameDataStruct.Class
{
    internal class Player : IBombHandler
    {
        Texture2D PlayerImage;
        Vector2 PlayerPosition;
        int speed;
        double radius;

        public Player(Texture2D playerImage, Vector2 startingPosition)
        {
            PlayerImage = playerImage;
            PlayerPosition = startingPosition;

            speed = 4;
            radius = playerImage.Width / 2;
        }

        public void UpdatePlayerLocation() { }

        public void DrawPlayer() { }

        public void ShootBomb()
        {
            throw new NotImplementedException();
        }
    }
}
