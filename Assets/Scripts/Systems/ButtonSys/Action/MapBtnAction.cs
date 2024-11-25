using System;
using CNS.Action;
using CNS.Enum;
using CNS.Installer;
using CNS.Manager;
using Systems.ButtonSys.Provider;
using Zenject;

namespace Systems.ButtonSys.Action
{
    [Bind(Scope.AsCached)]
    public class MapBtnAction : IAction
    {
        public Type ProviderType { get; } = typeof(ButtonActionProvider);
        public Marker Marker { get; } = Marker.MapBtn;

        [Inject] 
        private readonly IEntityManager entityManager;
        
        public void Execute()
        {
            entityManager.GetEntity(Marker.MapCanvas).Model.gameObject.SetActive(true);
        }
    }
}