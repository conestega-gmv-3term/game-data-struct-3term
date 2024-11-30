using FinalProject_GameDataStruct.Class.GameUI.Screens.Buttons;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_GameDataStruct.Class.GameUI.Screens
{
    public class MenuScreen : UIScreen
    {
        private List<Component> gameComponents;

        public override void Draw1(SpriteBatch spriteBatch, ContentManager gameManager) //Draw the list of buttons
        {
            var Button1 = new Button(gameManager.Load<Texture2D>("Rectangle"), gameManager.Load<SpriteFont>("timerFont"))
            {
                text = "Start Game",
                Rectangle = new Microsoft.Xna.Framework.Rectangle(1088 / 2 - 300 / 2, 1152 / 2 - 300 / 2, 300, 100)
            };
            Button1.click += Button1_click;

            var Button2 = new Button(gameManager.Load<Texture2D>("Rectangle"), gameManager.Load<SpriteFont>("timerFont"))
            {
                text = "Exit",
                Rectangle = new Microsoft.Xna.Framework.Rectangle(1088 / 2 - 300 / 2, 1152 / 2 - 50 / 2, 300, 100)
            };
            Button2.click += Button2_click;

            gameComponents = new List<Component>()
            {
               Button1,Button2
            };

            foreach (var component in gameComponents)
            {
                component.Draw(spriteBatch);
            }
        }

        private void Button2_click(object sender, EventArgs e)
        {
            
        }

        public override void Draw2(SpriteBatch spriteBatch, ContentManager gameManager) //Hovering and click
        {
            foreach (var component in gameComponents)
            {
                component.Draw(spriteBatch);
            }
        }

        private void Button1_click(object sender, EventArgs e)
        {
            GameManager.Status = Status.gameIsPlayed;
        }

        public void Update()
        {
            if (gameComponents != null)
            {
                foreach (var component in gameComponents)
                {
                    component.Update();
                }
            }
        }
    }
}
