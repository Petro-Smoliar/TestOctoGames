using CNS.Enum;
using CNS.Installer;
using CNS.Quests;
using UnityEngine;

namespace Quest
{
    [Bind(Scope.AsSingle)]
    public class Quest1 : AQuest
    {
        public Quest1()
        {
            AddStage(
                new QuestStage()
                    .SetMarkerTrigger(Marker.Location2)
                    .SetDialogId(2)
                    .SetDescriptionId(1)
                );
            AddStage(
                new QuestStage()
                    .SetMarkerTrigger(Marker.Location2)
                    .SetDialogId(3)
                    .SetDescriptionId(1)
                );
            
            AddStage(
                new QuestStage()
                    .SetMarkerTrigger(Marker.Location3)
                    .SetDialogId(0)
                    .SetDescriptionId(2)
                    .SetGameItem(new GameItem(Resources.Load<Sprite>("key")))
                );
            
            AddStage(
                new QuestStage()
                    .SetMarkerTrigger(Marker.Location2)
                    .SetDialogId(4)
                    .SetDescriptionId(3)
                );
            
             AddStage(
                 new QuestStage()
                     .SetMarkerTrigger(Marker.Location1)
                     .SetDialogId(5)
                     .SetDescriptionId(4)
                 );
        }
    }
}