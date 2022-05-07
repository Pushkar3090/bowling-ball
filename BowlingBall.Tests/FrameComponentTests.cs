using BowlingBall.Interfaces;
using BowlingBall.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static BowlingBall.Helpers.Enumerations;
using BowlingBall.Helpers;

namespace BowlingBall.Tests
{
    [TestClass]
    public class FrameComponentTests
    {
        
        private IFrameComponent frame;

       
        [TestInitialize]
        public void Initialize()
        {
            frame = new FrameComponent();
        }

        [TestMethod]
        public void TestStrikeFramePinsLength()
        {
            frame.Roll(10);
            Assert.AreEqual(frame.Pins.Count, 1);
        }

        [TestMethod]
        public void TestSpareFramePinsLength()
        {
            frame.Roll(9);
            frame.Roll(1);
            Assert.AreEqual(frame.Pins.Count, 2);
        }

        [TestMethod]
        public void TestNormalFramePinsLength()
        {
            frame.Roll(1);
            frame.Roll(1);
            Assert.AreEqual(frame.Pins.Count, 2);
        }

        [TestMethod]
        public void TestStrikeFrameState()
        {
            frame.Roll(10);
            Assert.AreEqual(frame.FrameState, State.Strike);
        }

        [TestMethod]
        public void TestSpareFrameState()
        {
            frame.Roll(9);
            frame.Roll(1);
            Assert.AreEqual(frame.FrameState, State.Spare);
        }

        [TestMethod]
        public void TestNormalFrameState()
        {
            frame.Roll(1);
            frame.Roll(1);
            Assert.AreEqual(frame.FrameState, State.Normal);
        }

        [TestMethod]
        public void TestStrikeFrameScore()
        {
            frame.Roll(10);
            Assert.AreEqual(frame.FrameScore, Constants.MaxScore);
        }

        [TestMethod]
        public void TestSpareFrameScore()
        {
            frame.Roll(9);
            frame.Roll(1);
            Assert.AreEqual(frame.FrameScore, Constants.MaxScore);
        }

        [TestMethod]
        public void TestNormalFrameScore()
        {
            frame.Roll(1);
            frame.Roll(1);
            Assert.AreEqual(frame.FrameScore, 2);
        }

    }
}
