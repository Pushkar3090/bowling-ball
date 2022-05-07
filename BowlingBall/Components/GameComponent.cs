using BowlingBall.Helpers;
using BowlingBall.Interfaces;
using System.Collections.Generic;

namespace BowlingBall.Components
{
    public class GameComponent : IGameComponent
    {
        public int GetScore(List<IFrameComponent> frames)
        {
            return frames.CalculateFinalScore();
        }
    }
}
