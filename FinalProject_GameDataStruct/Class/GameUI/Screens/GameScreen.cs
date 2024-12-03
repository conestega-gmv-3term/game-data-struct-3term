using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace FinalProject_GameDataStruct.Class.GameUI.Screens
{
    internal class GameScreen : UIScreen
    {
        public override void Draw1(SpriteBatch spriteBatch, ContentManager gameManager)
        {
            throw new NotImplementedException();
        }

        public override void Draw2(SpriteBatch spriteBatch, ContentManager gameManager)
        {
            string message = $"Score: {GameManager.score}";
            var font = gameManager.Load<SpriteFont>("timerFont");
            spriteBatch.DrawString(font, message, new Microsoft.Xna.Framework.Vector2(1088 / 2 - font.MeasureString(message).X / 2-200, 1152 / 2 - font.MeasureString(message).Y / 2-480), Microsoft.Xna.Framework.Color.White);
            string message2 = $"Time: {GameManager.secondsElapsed}";
            spriteBatch.DrawString(font, message2, new Microsoft.Xna.Framework.Vector2(1088 / 2 - font.MeasureString(message).X / 2+200, 1152 / 2 - font.MeasureString(message).Y / 2 - 480), Microsoft.Xna.Framework.Color.White);
        }
    }
}
