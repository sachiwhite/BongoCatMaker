using BongoCatMaker.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BongoCatMaker.Model
{
    public class SongInfo
    {
        public double BPM;
        public double BPM_Multiplier;
        public double Offset;
        public string VideoFileName;
        public double VideoDuration;
        
        
        public string AudioPath;
        private IVideoMaker videoMaker;
        public SongInfo(IVideoMaker videoMaker)
        {
            this.videoMaker=videoMaker;
        }
        public void MakeVideo()
        {
            videoMaker.MakeVideo(BPM,BPM_Multiplier,Offset,VideoFileName,AudioPath, VideoDuration);
        }

    }
}
