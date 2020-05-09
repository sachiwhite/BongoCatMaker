using System;

namespace BongoCatMaker.Infrastructure
{
    public class DirectShowVideoMakerUtilities :IVideoMakerUtilities
    {
        public DirectShowVideoMakerUtilities()
        {
        }

        public double ReturnFrameTimeBasedOnBPM(double BPM, double BPM_Multiplier)
        {
            if (BPM<=0 || BPM_Multiplier<=0)
            {
                throw new InvalidOperationException();
            }
            else return 1 / (BPM * BPM_Multiplier / 60);
        }

        public int ReturnNumberOfFrames(double videoDuration, double offset, double frametime)
        {
            var rawNumberOfFrames = (videoDuration-offset)/frametime;
            var numberOfFrames = Math.Ceiling(rawNumberOfFrames);
            return (int)numberOfFrames;
        }
    }
}