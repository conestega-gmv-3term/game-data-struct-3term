using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_GameDataStruct.Class.Maps
{
    internal class Map01 : GameMap
    {
        public Map01(string mapFilePath, string propsFilePath, string collistionFilePath, Texture2D mapTexture) : base(mapFilePath, propsFilePath, collistionFilePath, mapTexture)
        {
        }
    }
}
