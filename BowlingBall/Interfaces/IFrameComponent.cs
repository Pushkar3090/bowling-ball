using System.Collections.Generic;
using static BowlingBall.Helpers.Enumerations;

namespace BowlingBall.Interfaces
{
    public interface IFrameComponent
    {
        IReadOnlyList<int> Pins { get; }
        
        int FrameScore { get; }
        
        State FrameState { get; }

        void Roll(int pin);
    }
}
