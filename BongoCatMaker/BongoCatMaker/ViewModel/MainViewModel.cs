using BongoCatMaker.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;

namespace BongoCatMaker.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        private double bpmValue;
        public double BpmValue
        {
            get { return bpmValue; }
            set { Set(()=>BpmValue, ref bpmValue, value); }
        }
        public RelayCommand OpenDatabaseSearchWindowCommand{get;}
        public RelayCommand<IResizable> MinimizeCommand { get;}
        public RelayCommand<IResizable> CloseCommand { get;}
        public RelayCommand<IResizable> SizeChangedCommand{get;}
        public RelayCommand OpenFileDialogCommand{get;}
        public RelayCommand MakeAnimationCommand{get;}
        private string pickedFileName;
        public string PickedFileName { get=>pickedFileName; set=>Set(()=>PickedFileName, ref pickedFileName,value); }

        private VideoMakerUsingDirectShow testAnimationMaker;

        /// </summary>
        public MainViewModel()
        {
            MinimizeCommand=new RelayCommand<IResizable>(MinimizeWindow);
            CloseCommand = new RelayCommand<IResizable>(CloseWindow);
            SizeChangedCommand=new RelayCommand<IResizable>(ChangePositionOfButtonsWhenSizeChanged);
            OpenFileDialogCommand=new RelayCommand(OpenFileDialog);
            OpenDatabaseSearchWindowCommand=new RelayCommand(OpenDatabaseSearchWindow);
            MakeAnimationCommand=new RelayCommand(MakeAnimation);
            PickedFileName="filename will be here";
            testAnimationMaker=new VideoMakerUsingDirectShow(new DirectShowVideoMakerUtilities(), new ConsoleFFMpegVideoCutter());
        }

        private void MakeAnimation()
        {
          testAnimationMaker.MakeVideo(0,0,0,"output");
        }

        private void OpenDatabaseSearchWindow()
        {
            throw new NotImplementedException();
        }

        private void OpenFileDialog()
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            if (openFileDialog.ShowDialog()==true)
                PickedFileName = openFileDialog.FileName;
        }

        private void ChangePositionOfButtonsWhenSizeChanged(IResizable window)
        {
            if (window!=null)
                window.ChangePositionOfButtonsWhenSizeChanged();
        }

        private void CloseWindow(IResizable window)
        {
            if (window!=null)
                window.Close();
        }

        private void MinimizeWindow(IResizable window)
        {
            if (window!=null)
                window.Minimize();
        }
    }
}