using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace BongoCatMaker.Infrastructure
{
    public class ConsoleFFMpegVideoCutter :IVideoCutter
    {
        private string ffMPEG_Path = @"C:\Users\lewon\source\repos\FFMpegSharp-master\FFMpegSharp\FFMPEG\bin\x64\ffmpeg.exe";

        public ConsoleFFMpegVideoCutter() 
        {
        }


        public bool CutVideo(string input, string output, double videoDuration)
        {
            try
            {
                if (CheckIfVideoCutterExists())
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName=ffMPEG_Path;
                    startInfo.CreateNoWindow=true;
                    string videoDurationInvariantCulture = videoDuration.ToString(CultureInfo.InvariantCulture);
                    startInfo.Arguments=$" -ss 0 -i {input} -c copy -t {videoDurationInvariantCulture} {output}";
                    Process.Start(startInfo);
                }
                
            }
            catch (Exception ex)
            {
                Messaging.ShowMessage($"An unexpected error while cutting the video occurred. Contact with the developer, so this app can be improved! \n" +
                    $"Boring dev info:\n" +
                    $"{ex.Message}\n{ex.StackTrace}");
                
                return false;
            }
            return true;
            
        }
          public bool CheckIfVideoCutterExists()
        {
           return File.Exists(ffMPEG_Path);
        }

        public void SetVideoCutterPath(string path)
        {
            ffMPEG_Path=path;
        }
    }
}