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
    public class OptionBtnAction : IAction
    {
        [Inject] 
        private readonly IEntityManager entityManager;
        
        public Type ProviderType { get; } = typeof(ButtonActionProvider);
        public Marker Marker { get; } = Marker.OptionsBtn;
        
        public void Execute()
        {
            entityManager.GetEntity(Marker.OptionPanel).Model.gameObject.SetActive(true);
        }
    }
}