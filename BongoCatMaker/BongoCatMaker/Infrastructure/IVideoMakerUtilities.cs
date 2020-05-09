namespace BongoCatMaker.Infrastructure
{
    public interface IVideoMakerUtilities
    {
        double ReturnFrameTimeBasedOnBPM(double BPM, double BPM_Multiplier);
        int ReturnNumberOfFrames(double videoDuration, double offset, double frametime);
    }
}