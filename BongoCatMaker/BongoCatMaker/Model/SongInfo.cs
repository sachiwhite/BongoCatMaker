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
        public async Task MakeVideo()
        {
            if(CheckParameters())
            await videoMaker.MakeVideo(BPM,BPM_Multiplier,Offset,VideoFileName,AudioPath, VideoDuration);
        }

        private bool CheckParameters()
        {
            bool audioPathProperState = !String.IsNullOrEmpty(AudioPath);
            bool offsetProperState= !(Offset==0);
            bool videoDurationProperState= !(VideoDuration==0);

             
             if(!offsetProperState)
                offsetProperState = Messaging.ShowMessageYesNo("You didn't specify the offset, which means it would be set to 0. Proceed?");
             if(!videoDurationProperState)
                videoDurationProperState=Messaging.ShowMessageYesNo("You didn't specify the length of video, which means it would last for 30 s. Proceed?");
             if (!audioPathProperState)
                Messaging.ShowMessage("You didn't choose any audio file!");
           
            return audioPathProperState&&offsetProperState&&videoDurationProperState;
        }
    }
}
