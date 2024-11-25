using System;

namespace CNS.Installer
{
    [AttributeUsage(AttributeTargets.Class)]
    public class BindAttribute : Attribute
    {
        public Scope Scope { get; }

        public BindAttribute(Scope scope)
        {
            Scope = scope;
        }
    }

    public enum Scope
    {
        AsSingle,
        AsCached,
        AsTransient
    }
}