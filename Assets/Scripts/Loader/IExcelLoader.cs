using System.Collections.Generic;
using Dialogs;

namespace Loader
{
    public interface IExcelLoader
    {
        Dictionary<int, Dialog> LoadDialoguesFromExcel(string lang);
        
        Dictionary<int, string> LoadDescriptionsFromExcel(string lang);
    }
}