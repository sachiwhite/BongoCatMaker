using System;
using BongoCatMaker.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BongoCatMaker.Tests
{
    [TestClass]
    public class DirectShowVideoMakerUtilities_Tests
    {
        [TestMethod]
        public void DirectShowVideoMakerUtilities_ReturnsCorrectFrameTime()
        {
            var utils = new DirectShowVideoMakerUtilities();
            var actual = utils.ReturnFrameTimeBasedOnBPM(164.5,2);
            Assert.AreEqual(0.182370820668693,actual);
        }
        [TestMethod]
        public void DirectShowVideoMakerUtilities_ThrowsExceptionForNonPositiveBPM()
        {
            var utils = new DirectShowVideoMakerUtilities();
            Assert.ThrowsException<InvalidOperationException>(()=>utils.ReturnFrameTimeBasedOnBPM(0,2));
        }
        [TestMethod]
        public void DirectShowVideoMakerUtilities_ThrowsExceptionForNonPositiveBPM_Multiplier()
        {
             var utils = new DirectShowVideoMakerUtilities();
            Assert.ThrowsException<InvalidOperationException>(()=>utils.ReturnFrameTimeBasedOnBPM(164.5,0));
        }
        [TestMethod]
        public void DirectShowVideoMakerUtilities_ReturnsCorrectFrameNumber()
        {
             var utils = new DirectShowVideoMakerUtilities();
             var actual = utils.ReturnNumberOfFrames(8.5443486,1.979,0.182370820668693);
            Assert.AreEqual(36,actual);
        }
        [TestMethod]
        public void DirectShowVideoMakerUtilities_ThrowsExceptionForNonPositiveLength()
        {
            var utils = new DirectShowVideoMakerUtilities();
            Assert.ThrowsException<InvalidOperationException>(()=>utils.ReturnNumberOfFrames(0,1.979,0.182370820668693));
        }

    }
}
