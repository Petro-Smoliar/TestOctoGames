using System.Collections.Generic;
using CNS.Entities;
using CNS.Enum;
using CNS.Installer;
using UnityEngine.UI;

namespace CNS.Manager.Impl
{
    [Bind(Scope.AsSingle)]
    public class EntityManager : IEntityManager
    {
        private readonly Dictionary<Marker, Entity> models = new();
        private readonly List<Button> answerButtons = new();
        
        public Entity GetEntity(Marker marker)
        {
            return models[marker];
        }

        public void AddEntity(Entity entity)
        {
            models.TryAdd(entity.Marker, entity);
        }

        public void RemoveEntity(Entity entity)
        {
            models.Remove(entity.Marker);
        }

        public void AddAnswerButton(Button button)
        {
            answerButtons.Add(button);
        }

        public List<Button> GetAnswerButtons()
        {
            return answerButtons;
        }
    }
}