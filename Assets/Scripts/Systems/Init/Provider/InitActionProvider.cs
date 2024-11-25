using System.Collections.Generic;
using CNS.Action;
using CNS.Provider;
using Zenject;

namespace Systems.Init.Provider
{
    public class InitActionProvider : AActionProvider
    {
        [Inject]
        public InitActionProvider(List<IAction> actions) : base(actions) {}
    }
}