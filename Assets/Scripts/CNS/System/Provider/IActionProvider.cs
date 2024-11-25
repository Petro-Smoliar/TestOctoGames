using CNS.Action;
using CNS.Enum;

namespace CNS.System.Provider
{
    public interface IActionProvider
    {
        IAction GetAction(Marker marker);
    }
}