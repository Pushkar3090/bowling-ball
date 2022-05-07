using BowlingBall.Helpers;
using BowlingBall.Interfaces;
using System.Collections.Generic;
using System.Linq;
using static BowlingBall.Helpers.Enumerations;

namespace BowlingBall.Components
{
    public class FrameComponent : IFrameComponent
    {
        public FrameComponent()
        {
            pins = new List<int>();
        }

        private List<int> pins;

        public IReadOnlyList<int> Pins => pins;

        public int FrameScore => Pins.Sum();

        public State FrameState => GetState();

        public void Roll(int pin)
        {
            pins.Add(pin);
        }

        private State GetState()
        {
            if (Pins.Count == Constants.StrikeTurns && Pins[0] == Constants.MaxScore)
                return State.Strike;
            else if (Pins.Count == Constants.SpareTurns && FrameScore == Constants.MaxScore)
                return State.Spare;
            else
                return State.Normal;
        }
    }
}
