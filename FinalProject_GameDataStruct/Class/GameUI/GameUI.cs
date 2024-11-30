using Microsoft.Xna.Framework.Graphics;
using FinalProject_GameDataStruct.Class.GameUI.Screens;
using Microsoft.Xna.Framework.Content;

namespace FinalProject_GameDataStruct.Class.GameUI
{
    internal class GameUI
    {
        static SpriteBatch _spriteBatch;
        static ContentManager _contentManager;
        bool SecondDraw = false;

        public GameUI(SpriteBatch spriteBatch, ContentManager Content)
        {
            _spriteBatch = spriteBatch;
            _contentManager = Content;
        }
        public void DrawScreen(UIScreen Screen)
        {
            if (SecondDraw == true)
            {
                Screen.Draw2(_spriteBatch, _contentManager);
            }
            else
            {
                Screen.Draw1(_spriteBatch, _contentManager);
                SecondDraw = true;
            }
        }
    }
}
