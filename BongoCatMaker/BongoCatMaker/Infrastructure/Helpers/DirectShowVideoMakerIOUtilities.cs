using System;
using System.IO;

namespace BongoCatMaker.Infrastructure
{
    public class DirectShowVideoMakerIOUtilities : IVideoMakerIOUtilities
    {
        public bool CheckIfImageFilesExist(string imageFilesPath, int numberOfFilesToCheck)
        {
            for (int i = 1; i <= numberOfFilesToCheck; i++)
            {
                if(!File.Exists($"{imageFilesPath}{i}.jpg"))
                {
                    Messaging.ShowMessage("Some image files has not been found. Check if installation of the program was successful.");
                     return false;
                }
                   
            }
            return true;
        }

      

        public string ReturnNameWithExtension(string title, bool isTemporaryFile)
        {
            if (isTemporaryFile)
                title = $"{title}_temp";
            return $"{title}.wmv";
        }
    }
}
