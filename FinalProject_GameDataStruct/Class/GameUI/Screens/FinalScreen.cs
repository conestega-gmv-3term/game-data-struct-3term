using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_GameDataStruct.Class.GameUI.Screens
{
    internal class FinalScreen : UIScreen
    {
        public override void Draw1(SpriteBatch spriteBatch, ContentManager gameManager)
        {
            throw new NotImplementedException();
        }

        public override void Draw2(SpriteBatch spriteBatch, ContentManager gameManager)
        {
            string message = "End Game, Please click on button ESC";
            var font = gameManager.Load<SpriteFont>("timerFont");
            spriteBatch.DrawString(font, message, new Microsoft.Xna.Framework.Vector2(1088 / 2 - font.MeasureString(message).X / 2, 1152 / 2 - font.MeasureString(message).Y / 2), Microsoft.Xna.Framework.Color.White);
        }
    }
}
