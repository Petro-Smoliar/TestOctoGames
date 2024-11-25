using System.Collections.Generic;
using CNS.Entities;
using CNS.Enum;
using CNS.Models;
using UnityEngine.UI;

namespace CNS.Manager
{
    public interface IEntityManager
    {
        Entity GetEntity(Marker marker);
        
        void AddEntity(Entity entity);
        
        void RemoveEntity(Entity entity);

        void AddAnswerButton(Button button);
        
        List<Button> GetAnswerButtons();
    }
}