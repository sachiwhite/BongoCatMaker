using AsyncAwaitBestPractices.MVVM;
using BongoCatMaker.Infrastructure;
using BongoCatMaker.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BongoCatMaker.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        public double BpmValue
        {
            get => songInfo.BPM;
            set => Set(() => BpmValue, ref songInfo.BPM, value);
        }
        public double Offset
        {
            get => songInfo.Offset;
            set => Set(() => Offset, ref songInfo.Offset, value);
        }
        public double BPM_Multiplier
        {
            get => songInfo.BPM_Multiplier;
            set => Set(() => BPM_Multiplier, ref songInfo.BPM_Multiplier, value);
        }
        public double VideoDuration
        {
            get => songInfo.VideoDuration;
            set => Set(() => VideoDuration, ref songInfo.VideoDuration, value);
        }
        public string VideoFileName { get => songInfo.VideoFileName; set => Set(() => VideoFileName, ref songInfo.VideoFileName, value); }
        public AsyncCommand CleanupOnClosingCommand { get; }
        public RelayCommand OpenDatabaseSearchWindowCommand { get; }
        public RelayCommand<IResizable> MinimizeCommand { get; }
        public RelayCommand<IResizable> CloseCommand { get; }
        public RelayCommand<IResizable> SizeChangedCommand { get; }
        public RelayCommand OpenFileDialogCommand { get; }
        public AsyncCommand MakeAnimationCommand { get; }
        public string AudioFilePickedName { get => songInfo.AudioPath; set => Set(() => AudioFilePickedName, ref songInfo.AudioPath, value); }
        private SongInfo songInfo;

        /// </summary>
        public MainViewModel(IVideoMaker videoMaker)
        {
            MinimizeCommand = new RelayCommand<IResizable>(MinimizeWindow);
            CloseCommand = new RelayCommand<IResizable>(CloseWindow);
            SizeChangedCommand = new RelayCommand<IResizable>(ChangePositionOfButtonsWhenSizeChanged);
            OpenFileDialogCommand = new RelayCommand(OpenFileDialog);
            OpenDatabaseSearchWindowCommand = new RelayCommand(OpenDatabaseSearchWindow);
            MakeAnimationCommand = new AsyncCommand(MakeAnimation);
            CleanupOnClosingCommand = new AsyncCommand(CleanupOnClosing);
            songInfo = new SongInfo(videoMaker);
        }

        private async Task MakeAnimation()
        {
            await songInfo.MakeVideo();
        }

        private void OpenDatabaseSearchWindow()
        {
            throw new NotImplementedException();
        }

        private void OpenFileDialog()
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
                AudioFilePickedName = openFileDialog.FileName;
        }
        private async Task CleanupOnClosing()
        {
            DirectoryInfo temporaryFilesDirectory = new DirectoryInfo(@"TemporaryVideos\");
            var files = temporaryFilesDirectory.GetFiles();
                for (int i = 0; i < files.Length; i++)
                {
                    try
                    {
                        files[i].Delete();
                    }
                    catch (IOException ex)
                    {
                        Messaging.ShowMessage($"Temporary file {files[i].Name} couldn't be deleted.");
                    }
                }
            
        }
        private void ChangePositionOfButtonsWhenSizeChanged(IResizable window)
        {
            if (window != null)
                window.ChangePositionOfButtonsWhenSizeChanged();
        }

        private void CloseWindow(IResizable window)
        {
            if (window != null)
                window.Close();
        }

        private void MinimizeWindow(IResizable window)
        {
            if (window != null)
                window.Minimize();
        }
    }
}