using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
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
            Texture2D background = gameManager.Load<Texture2D>("Black Rectangle");
            string message = $"End Game, Your score was {GameManager.score}. Please enter ESC to finish";
            var font = gameManager.Load<SpriteFont>("timerFont");
            spriteBatch.Draw(background, new Microsoft.Xna.Framework.Rectangle(0, 0, 1088, 1152), Microsoft.Xna.Framework.Color.White);
            spriteBatch.DrawString(font, message, new Microsoft.Xna.Framework.Vector2(1088 / 2 - font.MeasureString(message).X / 2, 1152 / 2 - font.MeasureString(message).Y / 2), Microsoft.Xna.Framework.Color.White);
        }
    }
}
