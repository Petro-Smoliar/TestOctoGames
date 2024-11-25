using System;
using System.Collections.Generic;
using CNS.Installer;
using CNS.Provider;
using CNS.System.Provider;
using Zenject;

namespace CNS.Manager.Impl
{
    [Bind(Scope.AsSingle)]
    public class ProviderManager : IProviderManager
    {
        private readonly Dictionary<Type, IActionProvider> providers = new ();

        [Inject]
        public ProviderManager(List<IActionProvider> providers)
        {
            foreach (var provider in providers)
            {
                this.providers.Add(provider.GetType(), provider);
            }
        }

        public IActionProvider GetProvider<T>() where T : IActionProvider
        {
            return providers[typeof(T)];
        }
    }
}