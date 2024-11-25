using CNS.Entities;
using CNS.Enum;
using Dialogs;
using UnityEngine;

namespace Entities
{
    public class Npc : Entity
    {
        public string Name { get; set; }
        public string Relationship = "normal";
        public Sprite Sprite { get; set; }
        public Dialog DefaultDialog { get; set; }

        public Npc(Marker marker)
        {
            Marker = marker;
        }
    }
}