using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_GameDataStruct.Class
{
    public class Animation
    {
        public List<Rectangle> Frames { get; private set; }
        private int currentFrameIndex;
        private float frameTime; // Time per frame in seconds
        private float elapsedTime;
        public bool IsLooping { get; private set; }

        public Animation(List<Rectangle> frames, float frameTime, bool isLooping = true)
        {
            Frames = frames;
            this.frameTime = frameTime;
            IsLooping = isLooping;
            currentFrameIndex = 0;
            elapsedTime = 0f;
        }

        public void Update(GameTime gameTime)
        {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (elapsedTime >= frameTime)
            {
                elapsedTime = 0f;
                currentFrameIndex++;

                if (currentFrameIndex >= Frames.Count)
                {
                    currentFrameIndex = IsLooping ? 0 : Frames.Count - 1; // Loop or stop at the last frame
                }
            }
        }

        public Rectangle GetCurrentFrame()
        {
            return Frames[currentFrameIndex];
        }
    }
}
