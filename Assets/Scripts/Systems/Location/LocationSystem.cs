using System.Collections.Generic;
using System.Linq;
using CNS.Entities;
using CNS.Enum;
using CNS.Installer;
using CNS.Manager;
using CNS.Models;
using CNS.System;
using Dialogs;
using Entities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Systems.Location
{
    [Bind(Scope.AsCached)]
    public class LocationSystem : ISystem
    {
        [Inject]
        private readonly IEntityManager entityManager;
        [Inject]
        private readonly IDialogManager dialogManager;
        private readonly List<Button> answerButtons = new ();
        
        public void Execute(Entity entity)
        {
            var player = (Player) entityManager.GetEntity(Marker.Player);
            var locationItem = entityManager.GetEntity(Marker.LocationItem);
            
            if (player.Quest?.GetStage().GameItem != null)
            {
               locationItem.Model.gameObject.transform.parent.gameObject.SetActive(true);
               locationItem.Model.GetComponent<Image>().sprite =
                   player.Quest.GetStage().GameItem.Sprite;
            }
            else locationItem.Model.gameObject.transform.parent.gameObject.SetActive(false);
            
            if (player.Quest != null && player.Quest.GetStage().MarkerTrigger == entity.Marker)
            {
                var dialog = dialogManager.GetDialog(player.Quest.GetStage().DialogId);
                LoadDialogCanvas(dialog);
            }
            else
            {
                LoadDialogCanvas(dialogManager.GetDefaultDialog(entity.Marker));
            }
        }

        private void LoadDialogCanvas(Dialog dialog)
        {
            if (dialog.GetTextNpc() == null)
            {
                DeactivateObject(Marker.Dialog);
            }
            else LoadTextNpc(dialog);

            if (dialog.GetTextPlayer() == null)
            {
                DeactivateObject(Marker.AnswerBtn);
                DeactivateObject(Marker.PlayerImage);
            }
            else LoadTextPlayer(dialog);
            
            if (dialog.Npc == null) DeactivateObject(Marker.NpcImage);
            else
            {
                LoadImageNpc(dialog);
            }
        }

        private void LoadTextNpc(Dialog dialog)
        {
            var dialogEntity = entityManager.GetEntity(Marker.Dialog);
            var textNpc = dialogEntity.Model.GetComponentInChildren<TMP_Text>();
            textNpc.gameObject.transform.parent.gameObject.SetActive(true);
            textNpc.text = dialog.GetTextNpc().Text;
        }

        private void LoadImageNpc(Dialog dialog)
        {
            var imageNpc = entityManager.GetEntity(Marker.NpcImage);
            imageNpc.Model.gameObject.transform.parent.gameObject.SetActive(true);
            imageNpc.Model.GetComponent<Image>().sprite = dialog.Npc.Sprite;
        }

        private void LoadTextPlayer(Dialog dialog)
        {
            var imagePlayer = entityManager.GetEntity(Marker.PlayerImage);
            imagePlayer.Model.gameObject.transform.parent.gameObject.SetActive(true);
            var player = (Player) entityManager.GetEntity(Marker.Player);
            imagePlayer.Model.GetComponent<Image>().sprite = player.Sprite;
            
            var answerPanel = entityManager.GetEntity(Marker.AnswerPanel);
            answerPanel.Model.gameObject.gameObject.SetActive(true);
            
            var buttons = entityManager.GetAnswerButtons();
            
            foreach (var button in buttons)
            {
                 button.gameObject.SetActive(false);
            }
            var textsPlayer = dialog.GetTextPlayer();

            for (var i = 0; i < textsPlayer.Count; i++)
            {
                buttons[i].gameObject.SetActive(true);
                var entity = (AnswerBtn) buttons[i].GetComponent<Model>().Entity;
                entity.Action = textsPlayer[i].Action;
                buttons[i].GetComponentInChildren<TMP_Text>().text = textsPlayer[i].Text;
            }
        }

        private void DeactivateObject(Marker marker)
        {
            entityManager
                .GetEntity(marker)
                .Model
                .gameObject
                .transform
                .parent
                .gameObject
                .SetActive(false);
        }

        private void AddAnswerButton(Button button)
        {
            answerButtons.Add(button);
        }
    }
}