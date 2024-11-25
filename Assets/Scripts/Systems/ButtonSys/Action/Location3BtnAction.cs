using System;
using CNS.Action;
using CNS.Enum;
using CNS.Installer;
using CNS.Manager;
using CNS.Manager.Impl;
using Systems.ButtonSys.Provider;
using Systems.Location;
using Zenject;

namespace Systems.ButtonSys.Action
{
    [Bind(Scope.AsCached)]
    public class Location3BtnAction : IAction
    {
        public Type ProviderType { get; } = typeof (ButtonActionProvider);
        public Marker Marker { get; } = Marker.Location3;

        [Inject] 
        private readonly IEntityManager entityManager;
        
        public void Execute()
        {
            SystemManager.Instance.ExecuteSystem<LocationSystem>(entityManager.GetEntity(Marker));
            entityManager.GetEntity(Marker.MapCanvas).Model.gameObject.SetActive(false);
        }
    }
}