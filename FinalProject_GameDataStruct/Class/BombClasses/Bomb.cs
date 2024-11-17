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

namespace FinalProject_GameDataStruct.Class.Bomb
{    
    internal class Bomb : IBombHandler
    {
        Texture2D BombImage;
        Vector2 BombPosition;
        TimeSpan timeToExplose;

        public Bomb(Texture2D bombImage, Vector2 bombPosition)
        {
            BombImage = bombImage;
            BombPosition = bombPosition;

            timeToExplose = TimeSpan.FromSeconds(3);
        }

        public void DrawBomb() { }
        public void DrawExplosion() { }
        public void DisposeBomb() { }

        public void ShootBomb()
        {
            throw new NotImplementedException();
        }
    }
}
