using CNS.Enum;
using Dialogs;

namespace CNS.Manager
{
    public interface IDialogManager
    {
        void LoadDialogs();

        void AddDefaultDialog(Marker locationMarker, int id);
        
        void AddEmptyDefaultDialog(Marker locationMarker);
        
        Dialog GetDialog(int? id);
        
        Dialog GetDefaultDialog(Marker locationMarker);
    }
}