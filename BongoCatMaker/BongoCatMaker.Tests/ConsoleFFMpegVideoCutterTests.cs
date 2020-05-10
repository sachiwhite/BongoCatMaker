using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BongoCatMaker.Infrastructure;

namespace BongoCatMaker.Tests
{
    [TestClass]
    public class ConsoleFFMpegVideoCutterTests
    {
        [TestMethod]
        public void ConsoleFFMpegVideoCutterThrowsExceptionForNoPathGiven()
        {
            var videoCutter = new ConsoleFFMpegVideoCutter();
            videoCutter.SetVideoCutterPath("");
            Assert.ThrowsException<InvalidOperationException>(()=>videoCutter.CutVideo("",1));
                
        }
    }
}
