using System;
using CNS.Action;
using CNS.Enum;
using CNS.Installer;
using CNS.Manager;
using CNS.Manager.Impl;
using Systems.ButtonSys.Provider;
using Systems.DialogAction;
using Zenject;

namespace Systems.ButtonSys.Action
{
    [Bind(Scope.AsCached)]
    public class AnswerBtnAction : IAction
    {
        [Inject] private readonly IEntityManager entityManager;
        public Type ProviderType { get; } = typeof (ButtonActionProvider);
        public Marker Marker { get; } = Marker.AnswerBtn;
        
        public void Execute()
        {
            var entity = entityManager.GetEntity(Marker);
            entity.Model.gameObject.transform.parent.gameObject.SetActive(false);
            SystemManager.Instance
                .ExecuteSystem<DialogActionSystem>(entity);
        }
    }
}