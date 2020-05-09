using FFMpegSharp;
using FFMpegSharp.FFMPEG;
using FFMpegSharp.FFMPEG.Arguments;
using Splicer.Renderer;
using Splicer.Timeline;
using Splicer.WindowsMedia;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BongoCatMaker.Infrastructure
{
    public class VideoMakerUsingDirectShow : IVideoMaker
    {
        private IVideoMakerUtilities videoMakerUtilities;
        private IVideoCutter videoCutter;

        public VideoMakerUsingDirectShow(IVideoMakerUtilities videoMakerUtilities, IVideoCutter videoCutter)
        {
            this.videoMakerUtilities = videoMakerUtilities;
            this.videoCutter =videoCutter;
        }
        public void MakeVideo(double BPM, double BPM_Multiplier, double offset,string output, double videoDuration=30 )
        {
            double FrameTimeFromBPM = videoMakerUtilities.ReturnFrameTimeBasedOnBPM(BPM, BPM_Multiplier);
            using (ITimeline timeline = new DefaultTimeline())
            {
                IGroup group = timeline.AddVideoGroup(32, 738, 650);
                ITrack videoTrack = group.AddTrack();
                videoTrack.AddImage($@"jpg2\1.jpg", 0, offset);
                int framesNumber = videoMakerUtilities.ReturnNumberOfFrames(videoDuration,offset,FrameTimeFromBPM);
                for (int i = 1; i <= framesNumber; i++)
                {
                    int picNumber = i % 18;
                    videoTrack.AddImage($@"jpg2\{picNumber + 1}.jpg", 0, FrameTimeFromBPM);
                }
                ITrack audioTrack = timeline.AddAudioGroup().AddTrack();
                audioTrack.AddAudio("testinput.mp3", 0, videoTrack.Duration + 2.75);
                IRenderer renderer = new WindowsMediaRenderer(timeline, output, WindowsMediaProfiles.HighQualityVideo);
                renderer.Render();
                videoCutter.CutVideo(output, videoDuration);

            }
        }
       
    }
}
