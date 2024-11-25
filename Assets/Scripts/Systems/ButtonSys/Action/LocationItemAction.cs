using System;
using CNS.Action;
using CNS.Enum;
using CNS.Installer;
using CNS.Manager;
using CNS.Manager.Impl;
using Entities;
using Systems.ButtonSys.Provider;
using Systems.LogQuest;
using UnityEngine.UI;
using Zenject;

namespace Systems.ButtonSys.Action
{
    [Bind(Scope.AsCached)]
    public class LocationItemAction : IAction
    {
        [Inject] 
        private readonly IEntityManager entityManager;
        
        public Type ProviderType { get; } = typeof(ButtonActionProvider);
        public Marker Marker { get; } = Marker.LocationItem;
        
        public void Execute()
        {
            var locationItem = entityManager.GetEntity(Marker).Model;
            locationItem.gameObject.transform.parent.gameObject.SetActive(false);

            var player = (Player) entityManager.GetEntity(Marker.Player);
            player.Item = player.Quest.GetStage().GameItem;

            var playerItem = entityManager.GetEntity(Marker.PlayerItem);
            playerItem.Model.gameObject.SetActive(true);
            playerItem.Model.GetComponent<Image>().sprite = player.Item.Sprite;
            
            player.Quest.UpdateQuest();
            
            entityManager.GetEntity(Marker.Location3).Model.gameObject.SetActive(false);
            
            SystemManager.Instance.ExecuteSystem<LogQuestSystem>();
        }
    }
}