using CNS.Enum;
using CNS.Installer;
using CNS.Manager;
using CNS.Manager.Impl;
using CNS.System.Action;
using Entities;
using Systems.Location;
using UnityEngine.SceneManagement;
using Zenject;

namespace Systems.DialogAction.Action
{
    [Bind(Scope.AsCached)]
    public class PlayGameAction : IDialogAction
    {
        [Inject] 
        private readonly IEntityManager entityManager;
        
        public DialogTriggerAction Action { get; } = DialogTriggerAction.PlayGame;
        
        public void Execute()
        {
            var player = (Player) entityManager.GetEntity(Marker.Player);
            player.Quest.UpdateQuest();
            SettingsManager.ActionMinigame = ActionMiniGame;
            SceneManager.LoadSceneAsync("Minigame", LoadSceneMode.Additive);
        }

        private void ActionMiniGame()
        {
            var location2 = entityManager.GetEntity(Marker.Location2);
            SystemManager.Instance.ExecuteSystem<LocationSystem>(location2);
        }
    }
}