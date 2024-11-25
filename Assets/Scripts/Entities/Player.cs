using CNS.Entities;
using CNS.Enum;
using CNS.Quests;
using UnityEngine;

namespace Entities
{
    public class Player : Entity
    {
        public string Name { get; set; }
        public Sprite Sprite { get; set; }
        public AQuest Quest { get; set; }
        public GameItem Item { get; set; }
        
        public Player(Marker marker)
        {
            Marker = marker;
        }
    }
}