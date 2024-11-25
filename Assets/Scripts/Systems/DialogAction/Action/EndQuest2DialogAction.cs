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
    public class EndQuest2DialogAction : IDialogAction
    {
        [Inject] 
        private readonly IEntityManager entityManager;
        
        public DialogTriggerAction Action { get; } = DialogTriggerAction.EndQuest2;
        
        public void Execute()
        {
            var player = (Player) entityManager.GetEntity(Marker.Player);
            player.Quest = null;
            player.Item = null;
            entityManager.GetEntity(Marker.PlayerItem).Model.gameObject.SetActive(false);
            entityManager.GetEntity(Marker.Log).Model.gameObject.SetActive(false);
            
            SettingsManager.SaveNpcRelationship(Marker.Npc2, "good");
            SettingsManager.SaveNpcRelationship(Marker.Npc1, "bad");
        }
    }
}