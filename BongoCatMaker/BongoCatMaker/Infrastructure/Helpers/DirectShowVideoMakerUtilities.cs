using System;

namespace BongoCatMaker.Infrastructure
{
    public class DirectShowVideoMakerUtilities :IVideoMakerTimingUtilities
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
            if (videoDuration<=0)
                throw new InvalidOperationException("video duration was set to less than 0 s.");
            else if(offset<0)
                throw new InvalidOperationException("offset can't be a negative number!");
            else if(frametime<=0)
                throw new InvalidOperationException("frametime can't be less than 0.");
            else
            {
            var rawNumberOfFrames = (videoDuration-offset)/frametime;
            var numberOfFrames = Math.Ceiling(rawNumberOfFrames);
            return (int)numberOfFrames;
            }
        }
    }
}