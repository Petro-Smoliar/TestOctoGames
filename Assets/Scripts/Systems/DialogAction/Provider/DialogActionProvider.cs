using System.Collections.Generic;
using System.Linq;
using CNS.Enum;
using CNS.Installer;
using CNS.System.Action;
using CNS.System.Provider;
using Zenject;

namespace Systems.DialogAction.Provider
{
    [Bind(Scope.AsSingle)]
    public class DialogActionProvider : IDialogActionProvider
    {
        [Inject]
        private readonly List<IDialogAction> dialogActions;
        
        public IDialogAction GetAction(DialogTriggerAction action)
        {
            return dialogActions.FirstOrDefault(dialogAction => dialogAction.Action == action);
        }
    }
}