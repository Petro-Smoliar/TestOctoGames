using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Zenject;

namespace CNS.Installer
{
    public class AutoBindingInstaller : MonoInstaller
    {
        [SerializeField] 
        private GameObject buttonPrefab;
        
        public override void InstallBindings()
        {
            AutoBind();
        }

        private void AutoBind()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var type in types)
            {
                if (type.GetCustomAttributes(typeof(BindAttribute), true)
                        .FirstOrDefault() is not BindAttribute bindAttr) continue;
                var scope = (Scope)bindAttr.GetType().GetProperty("Scope")?.GetValue(bindAttr)!;

                if (type.GetInterfaces().Length > 0)
                {
                    BindInterfaces(type, scope);
                }
                else
                {
                    Bind(type, scope);
                }
            }
        }

        private void BindInterfaces(Type type, Scope scope)
        {
            switch (scope)
            {
                case Scope.AsSingle:
                    Container.BindInterfacesTo(type).AsSingle();
                    break;
                case Scope.AsCached:
                    Container.BindInterfacesTo(type).AsCached();
                    break;
                case Scope.AsTransient:
                default:
                    Container.BindInterfacesTo(type).AsTransient();
                    break;
            }
        }

        private void Bind(Type type, Scope scope)
        {
            switch (scope)
            {
                case Scope.AsSingle:
                    Container.Bind(type).AsSingle();
                    break;
                case Scope.AsCached:
                    Container.Bind(type).AsCached();
                    break;
                case Scope.AsTransient:
                default:
                    Container.Bind(type).AsTransient();
                    break;
            }
        }
    }
}