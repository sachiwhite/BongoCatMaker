using System.Threading.Tasks;

namespace BongoCatMaker.Infrastructure
{
    public interface IVideoMaker
    {
        Task MakeVideo(double BPM, double BPM_Multiplier, double offset, string videoTitle, string audioFilePath, double videoDuration = 30);
       
    }
}