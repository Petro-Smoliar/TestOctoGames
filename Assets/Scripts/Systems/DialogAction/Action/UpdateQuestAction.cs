using CNS.Enum;
using CNS.Installer;
using CNS.Manager;
using CNS.Manager.Impl;
using CNS.System.Action;
using Entities;
using Systems.LogQuest;
using UnityEngine;
using Zenject;

namespace Systems.DialogAction.Action
{
    [Bind(Scope.AsCached)]
    public class UpdateQuestAction : IDialogAction
    {
        [Inject] 
        private readonly IEntityManager entityManager;
        
        public DialogTriggerAction Action { get; } = DialogTriggerAction.UpdateQuest;
        
        public void Execute()
        {
            Debug.Log("UpdateQuestAction");
            var player = (Player) entityManager.GetEntity(Marker.Player);
            player.Quest.UpdateQuest();
            SystemManager.Instance.ExecuteSystem<LogQuestSystem>();
        }
    }
}