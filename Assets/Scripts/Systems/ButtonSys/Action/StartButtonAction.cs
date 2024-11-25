using System;
using CNS.Action;
using CNS.Enum;
using CNS.Installer;
using CNS.Manager;
using CNS.Manager.Impl;
using Systems.ButtonSys.Provider;
using Systems.Start;
using UnityEngine;
using Zenject;

namespace Systems.ButtonSys.Action
{
    [Bind(Scope.AsCached)]
    public class StartButtonAction : IAction
    {
        [Inject]
        private readonly IEntityManager entityManager;
        
        public Type ProviderType { get; } = typeof(ButtonActionProvider);
        public Marker Marker { get; } = Marker.StartBtn;
        
        public void Execute()
        {
            SystemManager.Instance.ExecuteSystem<StartSystem>();
            
            entityManager
                .GetEntity(Marker.NamePanel)
                .Model
                .gameObject
                .SetActive(true);
        }
    }
}