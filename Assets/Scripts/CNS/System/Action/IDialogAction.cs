using CNS.Enum;

namespace CNS.System.Action
{
    public interface IDialogAction
    {
        DialogTriggerAction Action { get; }
        
        void Execute();
    }
}