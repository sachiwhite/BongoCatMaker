using System;
using System.Diagnostics;

namespace BongoCatMaker.Infrastructure
{
    internal class ConsoleFFMpegVideoCutter :IVideoCutter
    {
        public ConsoleFFMpegVideoCutter() 
        {
        }

        public void CutVideo(string output, double videoDuration)
        {
            Process.Start(@"C:\Users\lewon\source\repos\FFMpegSharp-master\FFMpegSharp\FFMPEG\bin\x64\ffmpeg.exe", $"-ss 0 -i {output} -c copy -t {videoDuration} output.wmv");
        }
    }
}