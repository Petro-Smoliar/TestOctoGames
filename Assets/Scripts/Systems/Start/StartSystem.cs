using CNS.Entities;
using CNS.Enum;
using CNS.Installer;
using CNS.Manager;
using CNS.Manager.Impl;
using CNS.System;
using Entities;
using UnityEngine;
using Zenject;

namespace Systems.Start
{
    [Bind(Scope.AsCached)]
    public class StartSystem : ISystem
    {
        [Inject]
        private readonly IEntityManager entityManager;
        [Inject]
        private readonly IDialogManager dialogManager;
        [Inject]
        private readonly IDescriptionManager descriptionManager;
        

        public void Execute(Entity entity)
        {
            CreateCharacter();
            AddDefaultDialog();
            LoadDescription();
            SettingsManager.SaveNpcRelationship(Marker.Npc1, "normal");
            SettingsManager.SaveNpcRelationship(Marker.Npc2, "normal");
        }

        private void CreateCharacter()
        {
            var player = new Player(Marker.Player);
            player.Sprite = Resources.Load<Sprite>("player");
            entityManager.AddEntity(player);

            var npc1 = new Npc(Marker.Npc1); 
            npc1.Sprite = Resources.Load<Sprite>("npc1");
            entityManager.AddEntity(npc1);
            
            var npc2 = new Npc(Marker.Npc2);
            npc2.Sprite = Resources.Load<Sprite>("npc2");
            entityManager.AddEntity(npc2);
        }

        private void AddDefaultDialog()
        {
            dialogManager.LoadDialogs();
            dialogManager.AddDefaultDialog(Marker.Location1, 1);
            dialogManager.AddDefaultDialog(Marker.Location2, 7);
            dialogManager.AddEmptyDefaultDialog(Marker.Location3);
        }

        private void LoadDescription()
        {
            descriptionManager.LoadDescription();
        }
    }
}