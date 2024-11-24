using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_GameDataStruct.Class.Maps
{
    public class Missile
    {
        public Vector2 Position;
        public float Speed { get; set; }
        public int Width { get; set; } = 32;
        public int Height { get; set; } = 32;

        public Rectangle CollisionBox => new Rectangle((int)Position.X, (int)Position.Y, Width, Height);

        public void Update(GameTime gameTime)
        {
            // Move the block downward
            Position.Y += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Optionally, add logic to remove the block if it goes off-screen
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture)
        {
            spriteBatch.Draw(texture, CollisionBox, Color.Red); // Use Red for blocks
        }
    }
}
