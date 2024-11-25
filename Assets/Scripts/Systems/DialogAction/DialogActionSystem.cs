using CNS.Entities;
using CNS.Installer;
using CNS.System;
using CNS.System.Provider;
using Entities;
using Zenject;

namespace Systems.DialogAction
{
    [Bind(Scope.AsCached)]
    public class DialogActionSystem : ISystem
    {
        [Inject]
        private readonly IDialogActionProvider dialogActionProvider;
        
        public void Execute(Entity entity)
        {
            var answerBtn = (AnswerBtn) entity;
            dialogActionProvider.GetAction(answerBtn.Action).Execute();
        }
    }
}