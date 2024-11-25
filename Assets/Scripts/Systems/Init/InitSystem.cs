using CNS.Entities;
using CNS.Installer;
using CNS.Manager;
using CNS.Manager.Impl;
using CNS.System;
using Systems.ButtonSys;
using Systems.Init.Provider;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Systems.Init
{
    [Bind(Scope.AsCached)]
    public class InitSystem : ISystem
    {
        private readonly IEntityManager entityManager;
        private readonly IProviderManager providerManager;

        [Inject]
        public InitSystem(IEntityManager entityManager, IProviderManager providerManager)
        {
            this.entityManager = entityManager;
            this.providerManager = providerManager;
        }

        public void Execute(Entity entity)
        {
            Debug.Log("InitSystem Execute");
            entityManager.AddEntity(entity);

            var button = entity.Model.GetComponent<Button>();
            if (button != null) InitButton(button, entity);
                
        }

        private void InitButton(Button button, Entity entity)
        {
            button.onClick.RemoveAllListeners();
            button
                .onClick
                .AddListener(() => SystemManager.Instance.ExecuteSystem<ButtonSystem>(entity));
        }
    }
}