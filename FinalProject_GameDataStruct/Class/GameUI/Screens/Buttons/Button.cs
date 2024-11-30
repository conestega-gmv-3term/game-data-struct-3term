using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Drawing;

namespace FinalProject_GameDataStruct.Class.GameUI.Screens.Buttons
{
    public class Button : Component
    {
        private MouseState currentMouse;
        private SpriteFont Font;
        private bool isMovering;
        private MouseState previousMouse;
        private Texture2D texture;

        public event EventHandler click;
        public Microsoft.Xna.Framework.Color penColor;
        public Microsoft.Xna.Framework.Rectangle Rectangle;
        Microsoft.Xna.Framework.Color colour;
        public string text { get; set; }

        public Button(Texture2D texture2D, SpriteFont spriteFont)
        {
            texture = texture2D;
            Font = spriteFont;
            penColor = Microsoft.Xna.Framework.Color.White;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            colour = Microsoft.Xna.Framework.Color.White;

            if (isMovering)
            {
                colour = Microsoft.Xna.Framework.Color.Gray;
            }
            spriteBatch.Draw(texture, Rectangle, colour);

            if (!string.IsNullOrEmpty(text))
            {
                var x = Rectangle.X + Rectangle.Width / 2 - Font.MeasureString(text).X / 2;
                var y = Rectangle.Y + Rectangle.Height / 2 - Font.MeasureString(text).Y / 2;

                spriteBatch.DrawString(Font, text, new Microsoft.Xna.Framework.Vector2(x, y), penColor);
            }
        }

        public override void Update()
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();

            var mouseRectangle = new Microsoft.Xna.Framework.Rectangle(currentMouse.X, currentMouse.Y, 1, 1);

            isMovering = false;

            if (mouseRectangle.Intersects(Rectangle))
            {
                isMovering = true;
                colour = Microsoft.Xna.Framework.Color.Red;

                if (currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed)
                {
                    if (click != null)
                    {
                        click(this, new EventArgs());
                    }
                }
            }
        }
    }
}
