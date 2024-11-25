using System;
using CNS.Action;
using CNS.Enum;
using CNS.Installer;
using CNS.Manager;
using CNS.Manager.Impl;
using Entities;
using Systems.ButtonSys.Provider;
using Systems.Location;
using TMPro;
using UnityEngine;
using Zenject;

namespace Systems.ButtonSys.Action
{
    [Bind(Scope.AsCached)]
    public class InputNameBtnAction : IAction
    {
        [Inject]
        private readonly IEntityManager entityManager;
        
        public Type ProviderType { get; } = typeof(ButtonActionProvider);
        public Marker Marker { get; } = Marker.InputNameBtn;
        
        public void Execute()
        {
            var name = entityManager
                .GetEntity(Marker.InputName)
                .Model.GetComponent<TMP_InputField>()
                .text;
            var player = (Player) entityManager.GetEntity(Marker.Player);
            player.Name = name;

            entityManager.GetEntity(Marker.NamePanel).Model.gameObject.SetActive(false);
            
            entityManager.GetEntity(Marker.StartCanvas).Model.gameObject.SetActive(false);
            
            entityManager.GetEntity(Marker.MainSceneCanvas).Model.gameObject.SetActive(true);
            
            SystemManager.Instance
                .ExecuteSystem<LocationSystem>(entityManager.GetEntity(Marker.Location1));
        }
    }
}