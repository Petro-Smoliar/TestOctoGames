using System.Collections.Generic;
using CNS.Action;
using CNS.Installer;
using CNS.Provider;
using Zenject;

namespace Systems.ButtonSys.Provider
{
    [Bind(Scope.AsCached)]
    public class ButtonActionProvider : AActionProvider
    {
        [Inject]
        public ButtonActionProvider(List<IAction> actions) : base(actions) { }
    }
}