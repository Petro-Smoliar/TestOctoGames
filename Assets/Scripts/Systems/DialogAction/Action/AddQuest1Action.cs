using CNS.Enum;
using CNS.Installer;
using CNS.Manager;
using CNS.Manager.Impl;
using CNS.System.Action;
using Entities;
using Quest;
using Systems.LogQuest;
using Zenject;

namespace Systems.DialogAction.Action
{
    [Bind(Scope.AsCached)]
    public class AddQuest1Action : IDialogAction
    {
        [Inject] 
        private readonly Quest1 quest;
        [Inject] 
        private readonly IDialogManager dialogManager;
        [Inject] 
        private readonly IEntityManager entityManager;
        
        public DialogTriggerAction Action { get; } = DialogTriggerAction.AddQuest1;
        
        public void Execute()
        {
            var player = (Player) entityManager.GetEntity(Marker.Player);
            player.Quest = quest;
            
            dialogManager.AddDefaultDialog(Marker.Location1, 6);
            
            SystemManager.Instance.ExecuteSystem<LogQuestSystem>();
        }
    }
}