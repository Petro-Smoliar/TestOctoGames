using CNS.Entities;
using CNS.Installer;
using CNS.Manager;
using CNS.Provider;
using CNS.System;
using CNS.System.Provider;
using Systems.ButtonSys.Provider;
using Zenject;

namespace Systems.ButtonSys
{
    [Bind(Scope.AsCached)]
    public class ButtonSystem : ISystem
    {
        private readonly IActionProvider provider;

        [Inject]
        public ButtonSystem(IProviderManager providerManager)
        {
            provider = providerManager.GetProvider<ButtonActionProvider>();
        }
        
        public void Execute(Entity entity)
        {
            provider.GetAction(entity.Marker).Execute();
        }
    }
}