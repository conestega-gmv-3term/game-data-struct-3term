using FinalProject_GameDataStruct.Class.GameUI.Screens.Buttons;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace FinalProject_GameDataStruct.Class.GameUI.Screens
{
    public class MenuScreen : UIScreen
    {
        private List<Component> gameComponents;

        public override void Draw1(SpriteBatch spriteBatch, ContentManager gameManager) //Store the buttons
        {
            var Button1 = new Button(gameManager.Load<Texture2D>("Rectangle"), gameManager.Load<SpriteFont>("timerFont"))
            {
                text = "Start Game",
                Rectangle = new Microsoft.Xna.Framework.Rectangle(1088 / 2 - 300 / 2, 1152 / 2 - 300 / 2, 300, 100)
            };
            Button1.click += Button1_click;

            var Button2 = new Button(gameManager.Load<Texture2D>("Rectangle"), gameManager.Load<SpriteFont>("timerFont"))
            {
                text = "Controls",
                Rectangle = new Microsoft.Xna.Framework.Rectangle(1088 / 2 - 300 / 2, 1152 / 2 - 50 / 2, 300, 100)
            };
            Button2.click += Button2_click;


            var Button3 = new Button(gameManager.Load<Texture2D>("Rectangle"), gameManager.Load<SpriteFont>("timerFont"))
            {
                text = "Exit",
                Rectangle = new Microsoft.Xna.Framework.Rectangle(1088 / 2 - 300 / 2, 1152 / 2 - 50 / 2+125, 300, 100)
            };
            Button3.click += Button3_click;

            gameComponents = new List<Component>()
            {
               Button1,Button2,Button3
            };
        }
        public override void Draw2(SpriteBatch spriteBatch, ContentManager gameManager) //Draw the buttons
        {
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
        private void Button3_click(object sender, EventArgs e)
        {
            GameManager.Status = Status.exitGame;
        }
    }
}
