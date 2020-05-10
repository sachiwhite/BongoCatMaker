using BongoCatMaker.Infrastructure;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace BongoCatMaker.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
            SimpleIoc.Default.Register<IVideoMakerTimingUtilities,DirectShowVideoMakerUtilities>();
            SimpleIoc.Default.Register<IVideoCutter, ConsoleFFMpegVideoCutter>();
            SimpleIoc.Default.Register<IVideoMakerIOUtilities, DirectShowVideoMakerIOUtilities>();
            SimpleIoc.Default.Register<IVideoMaker, VideoMakerUsingDirectShow>();
            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}