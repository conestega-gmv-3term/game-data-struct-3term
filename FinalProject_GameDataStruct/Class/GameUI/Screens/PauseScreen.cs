using FinalProject_GameDataStruct.Class.GameUI.Screens.Buttons;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace FinalProject_GameDataStruct.Class.GameUI.Screens
{
    internal class PauseScreen : UIScreen
    {
        private List<FinalProject_GameDataStruct.Class.GameUI.Screens.Buttons.Component> gameComponents;
        public override void Draw1(SpriteBatch spriteBatch, ContentManager gameManager) //Store the buttons
        {
            var Button1 = new Button(gameManager.Load<Texture2D>("Rectangle"), gameManager.Load<SpriteFont>("timerFont"))
            {
                text = "Resume Game",
                Rectangle = new Microsoft.Xna.Framework.Rectangle(1088 / 2 - 300 / 2, 1152 / 2 - 300 / 2, 300, 100)
            };
            Button1.click += Button1_click;

            var Button2 = new Button(gameManager.Load<Texture2D>("Rectangle"), gameManager.Load<SpriteFont>("timerFont"))
            {
                text = "Controls",
                Rectangle = new Microsoft.Xna.Framework.Rectangle(1088 / 2 - 300 / 2, 1152 / 2 - 50 / 2, 300, 100)
            };
            Button2.click += Button2_click;

            gameComponents = new List<Component>()
            {
               Button1,Button2
            };
        }

        public override void Draw2(SpriteBatch spriteBatch, ContentManager gameManager) //Draw the buttons
        {
            string message = "Pause";
            var font = gameManager.Load<SpriteFont>("timerFont");
            Texture2D background = gameManager.Load<Texture2D>("Black Rectangle");
            spriteBatch.Draw(background, new Microsoft.Xna.Framework.Rectangle(0, 0, 1088, 1152), Microsoft.Xna.Framework.Color.White * 0.5f);
            spriteBatch.DrawString(font, message, new Microsoft.Xna.Framework.Vector2(1088 / 2 - font.MeasureString(message).X / 2, 300), Microsoft.Xna.Framework.Color.White);

            foreach (var component in gameComponents)
            {
                component.Draw(spriteBatch);
            }
        }
        public void Update() //Update the buttons
        {
            if (gameComponents != null)
            {
                foreach (var component in gameComponents)
                {
                    component.Update();
                }
            }
        }

        private void Button1_click(object sender, EventArgs e)
        {
            GameManager.Status = Status.gameIsPlayed;
        }
        private void Button2_click(object sender, EventArgs e)
        {
            GameManager.Status = Status.gameControls;
        }

    }
}
