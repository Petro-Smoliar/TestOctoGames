using System;
using CNS.Enum;

namespace CNS.Quests
{
    public class QuestStage
    {
        public Marker MarkerTrigger { get; private set; }
        public int? DialogId { get; private set; }
        public int? DescriptionId { get; private set; }
        public GameItem GameItem { get; private set; }

        public QuestStage SetMarkerTrigger(Marker trigger)
        {
           MarkerTrigger = trigger;
           return this;
        }
        
        public QuestStage SetDialogId(int? dialogId)
        {
            DialogId = dialogId;
            return this;
        }
        
        public QuestStage SetDescriptionId(int? descriptionId)
        {
            DescriptionId = descriptionId;
            return this;
        }
        
        public QuestStage SetGameItem(GameItem gameItem)
        {
            GameItem = gameItem;
            return this;
        }
    }
}