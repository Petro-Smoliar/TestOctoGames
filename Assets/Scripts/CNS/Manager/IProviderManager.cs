using CNS.Provider;
using CNS.System.Provider;

namespace CNS.Manager
{
    public interface IProviderManager
    {
        IActionProvider GetProvider<T>() where T : IActionProvider;
    }
}