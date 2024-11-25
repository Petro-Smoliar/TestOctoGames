using CNS.Enum;
using CNS.System.Action;

namespace CNS.System.Provider
{
    public interface IDialogActionProvider
    {
        IDialogAction GetAction(DialogTriggerAction action);
    }
}