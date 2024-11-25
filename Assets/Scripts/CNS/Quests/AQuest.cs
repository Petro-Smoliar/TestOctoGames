using System;
using System.Collections.Generic;

namespace CNS.Quests
{
    public abstract class AQuest
    {
        private readonly Queue<QuestStage> stages;
        public Type QuestType { get; private set; }

        protected AQuest()
        {
            stages = new Queue<QuestStage>();
            QuestType = GetType();
        }

        public QuestStage GetStage()
        {
            return stages.Peek();
        }

        public void UpdateQuest()
        {
            stages.Dequeue();
        }

        protected void AddStage(QuestStage stage)
        {
            stages.Enqueue(stage);
        }
    }
}