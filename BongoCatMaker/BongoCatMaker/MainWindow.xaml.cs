using BongoCatMaker.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BongoCatMaker
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IResizable
    {
        private readonly double ButtonCountInBorder;
        public MainWindow()
        {
            ButtonCountInBorder=2;
            InitializeComponent();
        }

        public void ChangePositionOfButtonsWhenSizeChanged()
        {
            var titleLabelWidth = titleLabel.ActualWidth;
            Thickness newMargin = new Thickness(App.Current.MainWindow.ActualWidth - 29- titleLabelWidth - ButtonCountInBorder * firstButton.Width, 0, 0, 0);
            firstButton.Margin = newMargin;
        }

        public void Minimize()
        {
             App.Current.MainWindow.WindowState = WindowState.Minimized;
        }
    }
}
