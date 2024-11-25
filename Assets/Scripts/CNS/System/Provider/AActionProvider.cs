using System;
using System.Collections.Generic;
using System.Linq;
using CNS.Action;
using CNS.Enum;
using CNS.System.Provider;

namespace CNS.Provider
{
    public abstract class AActionProvider : IActionProvider
    {
        private readonly List<IAction> actions;

        protected AActionProvider(List<IAction> actions)
        { 
            this.actions = actions.Where(action => action.ProviderType == GetType()).ToList();
        }

        public IAction GetAction(Marker marker)
        {
            return actions.FirstOrDefault(action => action.Marker == marker);
        }
    }
}