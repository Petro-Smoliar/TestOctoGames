using System;
using CNS.Action;
using CNS.Enum;
using CNS.Installer;
using CNS.Manager;
using CNS.Manager.Impl;
using Systems.ButtonSys.Provider;
using Zenject;

namespace Systems.ButtonSys.Action
{
    [Bind(Scope.AsCached)]
    public class UaBtnAction : IAction
    {
        [Inject]
        private readonly IEntityManager entityManager;

        public Type ProviderType { get; } = typeof(ButtonActionProvider);
        public Marker Marker { get; } = Marker.UaBtn;
        
        public void Execute()
        {
            SettingsManager.SaveLanguage("ua");
            entityManager.GetEntity(Marker.OptionPanel).Model.gameObject.SetActive(false);
        }
    }
}