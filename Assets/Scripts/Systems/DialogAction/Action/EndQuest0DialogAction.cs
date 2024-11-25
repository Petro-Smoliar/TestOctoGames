using CNS.Enum;
using CNS.Installer;
using CNS.Manager;
using CNS.Manager.Impl;
using CNS.System.Action;
using Entities;
using Zenject;

namespace Systems.DialogAction.Action
{
    [Bind(Scope.AsCached)]
    public class EndQuest0DialogAction : IDialogAction
    {
        [Inject] 
        private readonly IEntityManager entityManager;

        public DialogTriggerAction Action { get; } = DialogTriggerAction.EndQuest0;
        
        public void Execute()
        {
            var player = (Player) entityManager.GetEntity(Marker.Player);
            player.Quest = null;
            
            entityManager.GetEntity(Marker.Log).Model.gameObject.SetActive(false);
            
            SettingsManager.SaveNpcRelationship(Marker.Npc2, "bad");
            SettingsManager.SaveNpcRelationship(Marker.Npc1, "bad");
        }
    }
}