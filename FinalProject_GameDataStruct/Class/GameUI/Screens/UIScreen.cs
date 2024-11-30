using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_GameDataStruct.Class.GameUI.Screens
{
    public abstract class UIScreen
    {
        public abstract void Draw1(SpriteBatch spriteBatch, ContentManager gameManager);
        public abstract void Draw2(SpriteBatch spriteBatch, ContentManager gameManager);
    }
}
