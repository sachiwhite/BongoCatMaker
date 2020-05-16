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
using System.Threading;
using System.Threading.Tasks;

namespace BongoCatMaker.Infrastructure
{
    public class VideoMakerUsingDirectShow : IVideoMaker
    {
        private readonly string tempFilesPath = @"TemporaryVideos\";
        private readonly string finalFilesPath = @"CreatedVideos\";
        private IVideoMakerTimingUtilities videoMakerTimingUtilities;
        private IVideoCutter videoCutter;
        private IVideoMakerIOUtilities videoMakerIOUtilities;

        public VideoMakerUsingDirectShow(IVideoMakerTimingUtilities videoMakerUtilities, IVideoCutter videoCutter, IVideoMakerIOUtilities videoMakerIOUtilities)
        {
            this.videoMakerTimingUtilities = videoMakerUtilities;
            this.videoCutter = videoCutter;
            this.videoMakerIOUtilities = videoMakerIOUtilities;
        }
        public async Task MakeVideo(double BPM, double BPM_Multiplier, double offset, string videoTitle, string audioFilePath, double videoDuration = 30)
        {
            string temporaryVideoFileName = tempFilesPath + videoMakerIOUtilities.ReturnNameWithExtension(videoTitle, true);
            string VideoFileName = finalFilesPath + videoMakerIOUtilities.ReturnNameWithExtension(videoTitle, false);
            double FrameTimeFromBPM = videoMakerTimingUtilities.ReturnFrameTimeBasedOnBPM(BPM, BPM_Multiplier);
            await Task.Run(() =>
            {
                if (videoMakerIOUtilities.CheckIfImageFilesExist(imageFilesPath: $@"jpg2\", 19))
                {
                    using (ITimeline timeline = new DefaultTimeline())
                    {
                        IGroup group = timeline.AddVideoGroup(32, 738, 650);
                        ITrack videoTrack = group.AddTrack();
                        videoTrack.AddImage($@"jpg2\1.jpg", 0, offset);
                        int framesNumber = videoMakerTimingUtilities.ReturnNumberOfFrames(videoDuration, offset, FrameTimeFromBPM);
                        for (int i = 1; i <= framesNumber; i++)
                        {
                            int picNumber = i % 18;
                            videoTrack.AddImage($@"jpg2\{picNumber + 1}.jpg", 0, FrameTimeFromBPM);
                        }
                        ITrack audioTrack = timeline.AddAudioGroup().AddTrack();
                        audioTrack.AddAudio(audioFilePath, 0, videoTrack.Duration + 2.75);
                        using (WindowsMediaRenderer renderer = new WindowsMediaRenderer(timeline,temporaryVideoFileName, WindowsMediaProfiles.HighQualityVideo))
                        {
                         renderer.Render();
                        }
                    }
                }
            }
            );
            if(CutVideo(temporaryVideoFileName,VideoFileName,videoDuration))
             Messaging.ShowMessage($"Your video was generated successfully. Look for your {VideoFileName} file in app folder.", "Success");
            }

        private bool CutVideo(string input, string output, double videoDuration)
        {
            return videoCutter.CutVideo(input, output, videoDuration);

        }
    }
}
