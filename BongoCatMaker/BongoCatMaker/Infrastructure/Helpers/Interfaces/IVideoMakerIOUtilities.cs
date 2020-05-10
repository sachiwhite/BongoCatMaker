using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BongoCatMaker.Infrastructure
{
    public interface IVideoMakerIOUtilities
    {
        string ReturnNameWithExtension(string title, bool isTemporaryFile);
        bool CheckIfImageFilesExist(string imageFilesPath, int numberOfFilesToCheck);
        
    }
}
