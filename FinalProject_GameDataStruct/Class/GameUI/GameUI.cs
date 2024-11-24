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

namespace FinalProject_GameDataStruct.Class.GameUI
{
    internal class GameUI
    {
        SpriteFont RegularFont;
        SpriteFont SpecialFont;
        int ScreenHeight;
        int ScreenWidth;

        public GameUI(SpriteFont regularFont, SpriteFont specialFont, int screenHeight, int screenWidth)
        {
            RegularFont = regularFont;
            SpecialFont = specialFont;
            ScreenHeight = screenHeight;
            ScreenWidth = screenWidth;
        }

        public void DrawStartMenuUI() { }
        public void DrawEndMenuUI() { }
        public void DrawGamePlayUI() { }
        public void DrawGamePauseUI() { }
    }
}
