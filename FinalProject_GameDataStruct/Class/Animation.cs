using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public bool IsFinished { get; private set; }

        public Animation(List<Rectangle> frames, float frameTime, bool isLooping)
        {
            Frames = frames;
            this.frameTime = frameTime;
            IsLooping = isLooping;
            currentFrameIndex = 0;
            elapsedTime = 0f;
            IsFinished = false;
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
                    if (IsLooping)
                    {

                        currentFrameIndex = 0;
                    }
                    else
                    {
                        currentFrameIndex = Frames.Count - 1; // Stop at the last frame
                        IsFinished = true; // Mark animation as finished                        
                    }
                }
            }
        }

        public Rectangle GetCurrentFrame()
        {
            return Frames[currentFrameIndex];
        }
    }
}
