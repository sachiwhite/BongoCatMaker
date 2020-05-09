using FFMpegSharp;
using FFMpegSharp.FFMPEG;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BongoCatMaker.Infrastructure
{
    public class AnimationMaker
    {
        public void GenerateAnimation()
        {
            ImageInfo[] videoParameters = ReturnVideoParameters();
            FFMpeg encoder = new FFMpeg();
             
            encoder.JoinImageSequence(
             new FileInfo(@"..\test_video.mp4"),
             14.28, // FPS
             videoParameters

    );
        }

        private ImageInfo[] ReturnVideoParameters()
        {
            var root = @"C:\Users\lewon\source\repos\BongoCatMaker\BongoCatMaker\BongoCatMaker.Infrastructure\bin\Debug\frames";
            ImageInfo[] videoParamaters = new ImageInfo[93];
            for (int i = 0; i < videoParamaters.Length; i++)
            {
                string path = $@"{root}\{i+1}.png";
                videoParamaters[i] = ImageInfo.FromPath(path);

            }
            return videoParamaters;
        }
    }
}
