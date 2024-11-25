using CNS.Entities;
using CNS.Enum;
using CNS.Installer;
using CNS.Manager;
using CNS.System;
using Entities;
using TMPro;
using Zenject;

namespace Systems.LogQuest
{
    [Bind(Scope.AsCached)]
    public class LogQuestSystem : ISystem
    {
        [Inject] 
        private readonly IEntityManager entityManager;
        [Inject]
        private readonly IDescriptionManager descriptionManager;
        
        public void Execute(Entity entity)
        {
            var log = entityManager.GetEntity(Marker.Log);

            var player = (Player)entityManager.GetEntity(Marker.Player);

            log.Model.GetComponent<TMP_Text>().text = 
                descriptionManager.GetDescription(player.Quest.GetStage().DescriptionId);
        }
    }
}