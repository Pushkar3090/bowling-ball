using System.Collections.Generic;

namespace BowlingBall.Interfaces
{
    public interface IGameComponent
    {
        int GetScore(List<IFrameComponent> frames);
    }
}
