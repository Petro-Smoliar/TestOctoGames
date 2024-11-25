using System;
using System.Collections.Generic;
using CNS.Entities;
using CNS.Installer;
using CNS.System;
using Zenject;

namespace CNS.Manager.Impl
{
    [Bind(Scope.AsCached)]
    public class SystemManager : IInitializable
    {
        public static SystemManager Instance;
        
        [Inject]
        private readonly List<ISystem> iSystems;  
        private readonly Dictionary<Type, ISystem> systems = new ();
        
        
        public void Initialize()
        {
            foreach (var system in iSystems)
            {
                systems.Add(system.GetType(), system);
            }
            
            Instance = this;
        }

        public void ExecuteSystem<T>(Entity entity = null) where T : ISystem
        {
            systems[typeof(T)].Execute(entity);
        }
    }
}