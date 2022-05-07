using BowlingBall.Components;
using BowlingBall.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameComponentTests
    {
        
        IGameComponent gameComponent;

        [TestInitialize]
        public void Initialize()
        {
            gameComponent = new GameComponent();
        }

        [TestMethod]
        public void TestGameScoreForMixFrames()
        {
            var frames = GetMixFrames();
            Assert.AreEqual(gameComponent.GetScore(frames), 187);
        }

        [TestMethod]
        public void TestGameScoreForAllStrikeFrames()
        {
            var frames = GetStrikeFrames();
            Assert.AreEqual(gameComponent.GetScore(frames), 290);
        }

        [TestMethod]
        public void TestGameScoreForAllSpareFrames()
        {
            var frames = GetSpareFrames();
            Assert.AreEqual(gameComponent.GetScore(frames), 162);
        }

        [TestMethod]
        public void TestGameScoreForNonStrikeAndNonSpareFrames()
        {
            var frames = GetNonStrikeAndNonSpareFrames();
            Assert.AreEqual(gameComponent.GetScore(frames), 10);
        }

        private List<IFrameComponent> GetNonStrikeAndNonSpareFrames()
        {
            var frames = new List<IFrameComponent>
            {
                GetFrame( 1 ),
                GetFrame( 1 ),
                GetFrame( 1 ),
                GetFrame( 1 ),
                GetFrame( 1 ),
                GetFrame( 1 ),
                GetFrame( 1 ),
                GetFrame( 1 ),
                GetFrame( 1 ),
                GetFrame( 1 )
            };
            return frames;
        }

        private List<IFrameComponent> GetStrikeFrames()
        {
            var frames = new List<IFrameComponent>
            {
                GetFrame( 10 ),
                GetFrame( 10 ),
                GetFrame( 10 ),
                GetFrame( 10 ),
                GetFrame( 10 ),
                GetFrame( 10 ),
                GetFrame( 10 ),
                GetFrame( 10 ),
                GetFrame( 10 ),
                GetFrame( 10, 10 )
            };
            return frames;
        }

        private List<IFrameComponent> GetSpareFrames()
        {
            var frames = new List<IFrameComponent>
            {
                GetFrame( 9, 1 ),
                GetFrame( 5, 5 ),
                GetFrame( 9, 1 ),
                GetFrame( 1, 9 ),
                GetFrame( 7, 3 ),
                GetFrame( 8, 2 ),
                GetFrame( 4, 6 ),
                GetFrame( 9, 1 ),
                GetFrame( 9, 1 ),
                GetFrame( 5, 5, 5 )
            };
            return frames;
        }

        private List<IFrameComponent> GetMixFrames()
        {
            var frames = new List<IFrameComponent>
            {
                GetFrame( 10 ),
                GetFrame( 9, 1 ),
                GetFrame( 5, 5 ),
                GetFrame( 7, 2 ),
                GetFrame( 10 ),
                GetFrame( 10 ),
                GetFrame( 10, 0),
                GetFrame( 9, 0 ),
                GetFrame( 8, 2 ),
                GetFrame( 9, 1, 10 )
            };
            return frames;
        }

        private FrameComponent GetFrame(int firstRoll, int secondRoll = 0, int thirdRoll = 0)
        {
            FrameComponent frame = new FrameComponent();
            frame.Roll(firstRoll);
            if( secondRoll > 0 )
                frame.Roll(secondRoll);
            if( thirdRoll > 0 )
                frame.Roll(thirdRoll);
            return frame;

        }
    }
}
