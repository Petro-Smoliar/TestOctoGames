using System;
using CNS.Enum;

namespace CNS.Action
{
    public interface IAction
    {
        Type ProviderType { get; }
        
        Marker Marker { get; }
        
        void Execute();
    }
}