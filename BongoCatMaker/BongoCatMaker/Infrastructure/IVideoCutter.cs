namespace BongoCatMaker.Infrastructure
{
    public interface IVideoCutter
    {
        void CutVideo(string output, double videoDuration);
    }
}