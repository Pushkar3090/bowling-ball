using BowlingBall.Components;
using BowlingBall.Interfaces;
using System.Collections.Generic;
using static BowlingBall.Helpers.Enumerations;

namespace BowlingBall.Helpers
{
    public static class ExtensionMethods
    {
        public static bool IsNotNullOrEmpty<T>(this ICollection<T> collection)
        {
            return collection != null && collection.Count > 0;
        } 

        public static int CalculateFinalScore(this List<IFrameComponent> frameList)
        {
            int frameScore = 0;
            if (frameList.IsNotNullOrEmpty())
            {
                int totalBonus = 0;
                for (int frameIndex = 0; frameIndex < frameList.Count; frameIndex++)
                {
                    if (frameIndex != Constants.MaxFrames - 1)
                    {
                        totalBonus += CalculateCurrentFrameBonus(frameList, frameIndex);
                    }
                    frameScore += frameList[frameIndex].FrameScore;
                }
                frameScore += totalBonus;
            }
            return frameScore;
        }

        private static int CalculateCurrentFrameBonus(List<IFrameComponent> frames, int currentFrameIndex)
        {
            int bonus = 0;
            if (frames.IsNotNullOrEmpty())
            {
                IFrameComponent currentFrame = frames[currentFrameIndex];
                if (currentFrame.FrameState == State.Strike)
                {
                    IFrameComponent nextFrameToCurrent = frames[currentFrameIndex + 1];
                    bonus = nextFrameToCurrent.FrameScore;
                    if (nextFrameToCurrent.FrameState == State.Strike)
                    {
                        bonus += frames[currentFrameIndex + 2].Pins[0];
                    }
                }
                else if (currentFrame.FrameState == State.Spare)
                {
                    bonus = frames[currentFrameIndex + 1].Pins[0];
                }
            }
            return bonus;
        }
    }
}
