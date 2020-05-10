using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BongoCatMaker
{
    public static class Messaging
    {
        public static void ShowMessage(string messageText, string caption="An error occured")
        {
            MessageBox.Show(messageText,caption);
        }
    }
}
