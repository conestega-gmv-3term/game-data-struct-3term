using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace FinalProject_GameDataStruct.Class.GameUI.Screens
{
    internal class ControlsScreen : UIScreen
    {
        public override void Draw1(SpriteBatch spriteBatch, ContentManager gameManager)
        {
            throw new NotImplementedException();
        }

        public override void Draw2(SpriteBatch spriteBatch, ContentManager gameManager)
        {
            string message = "Controls";
            string message1 = "Movement";
            string message2 = "Start";
            string message3 = "Press Z to return to the last page";

            var font = gameManager.Load<SpriteFont>("timerFont");
            Texture2D background = gameManager.Load<Texture2D>("Black Rectangle");
            Texture2D keyboard = gameManager.Load<Texture2D>("Keyboard-removebg-preview");
            Texture2D LetterZ = gameManager.Load<Texture2D>("Z_-_Letter-removebg-preview");

            spriteBatch.Draw(background, new Microsoft.Xna.Framework.Rectangle(0, 0, 1088, 1152), Microsoft.Xna.Framework.Color.White * 0.5f);
            spriteBatch.DrawString(font, message, new Microsoft.Xna.Framework.Vector2(1088 / 2 - font.MeasureString(message).X / 2, 300), Microsoft.Xna.Framework.Color.White);
            spriteBatch.Draw(keyboard, new Microsoft.Xna.Framework.Rectangle(1088 / 2 - 350 / 2 - 300, 1152 / 2 - 200 / 2 - 100, 350, 200), Microsoft.Xna.Framework.Color.White);
            spriteBatch.DrawString(font, message1, new Microsoft.Xna.Framework.Vector2(1088 / 2 - font.MeasureString(message1).X / 2-80, 520), Microsoft.Xna.Framework.Color.White);
            spriteBatch.DrawString(font, message2, new Microsoft.Xna.Framework.Vector2(1088 / 2 - font.MeasureString(message2).X / 2- 80, 710), Microsoft.Xna.Framework.Color.White);
            spriteBatch.Draw(LetterZ, new Microsoft.Xna.Framework.Rectangle(1088 / 2 - 150 / 2-300, 1152 / 2 - 110 / 2+160, 150, 100), Microsoft.Xna.Framework.Color.White);
            spriteBatch.DrawString(font, message3, new Microsoft.Xna.Framework.Vector2(1088 / 2 - font.MeasureString(message3).X / 2, 1152/2- font.MeasureString(message3).Y+400), Microsoft.Xna.Framework.Color.White);


        }
    }
}
