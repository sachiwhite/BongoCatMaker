namespace BongoCatMaker.Infrastructure
{
    public interface IVideoMakerTimingUtilities
    {
        double ReturnFrameTimeBasedOnBPM(double BPM, double BPM_Multiplier);
        int ReturnNumberOfFrames(double videoDuration, double offset, double frametime);
    }
}