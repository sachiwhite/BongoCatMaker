namespace BongoCatMaker.Infrastructure
{
    public interface IVideoCutter
    {
        void SetVideoCutterPath(string path);
        bool CheckIfVideoCutterExists();
        bool CutVideo(string input, string output, double videoDuration);
    }
}