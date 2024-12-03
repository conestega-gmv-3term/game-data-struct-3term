using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Drawing;

namespace FinalProject_GameDataStruct.Class.GameUI.Screens.Buttons
{
    public class Button : Component
    {
        private MouseState currentMouse; //Current Mouse Position
        private SpriteFont Font; //Font of the text
        private bool isMovering; //For hovering
        private Texture2D texture; //Texture

        public event EventHandler click; //Action
        public Microsoft.Xna.Framework.Color penColor; //Color of the text
        public Microsoft.Xna.Framework.Rectangle Rectangle; //For positon and size
        Microsoft.Xna.Framework.Color colour; //Help with hovering
        public string text { get; set; } //Text

        public Button(Texture2D texture2D, SpriteFont spriteFont)
        {
            texture = texture2D;
            Font = spriteFont;
            penColor = Microsoft.Xna.Framework.Color.White;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            colour = Microsoft.Xna.Framework.Color.White;

            if (isMovering) //When the user hovers over the button
            {
                colour = Microsoft.Xna.Framework.Color.Blue;
            }
            spriteBatch.Draw(texture, Rectangle, colour);

            if (!string.IsNullOrEmpty(text)) //If the button has text
            {
                var x = Rectangle.X + Rectangle.Width / 2 - Font.MeasureString(text).X / 2;
                var y = Rectangle.Y + Rectangle.Height / 2 - Font.MeasureString(text).Y / 2;

                spriteBatch.DrawString(Font, text, new Microsoft.Xna.Framework.Vector2(x, y), penColor);
            }
        }

        public override void Update() //Update the button
        {
            currentMouse = Mouse.GetState();
            var mouseRectangle = new Microsoft.Xna.Framework.Rectangle(currentMouse.X, currentMouse.Y, 1, 1);
            isMovering = false;

            if (mouseRectangle.Intersects(Rectangle))
            {
                isMovering = true;

                if (currentMouse.LeftButton == ButtonState.Pressed)
                {
                    if (click != null)
                    {
                        click(this, new EventArgs()); //The action of the button
                    }
                }
            }
        }
    }
}
