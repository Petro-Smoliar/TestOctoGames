using System.Collections.Generic;
using System.Linq;
using CNS.Enum;
using CNS.Manager.Impl;
using Entities;

namespace Dialogs
{
    public class Dialog
    {
        public Npc Npc { get; set; }
        public List<TextNpc> TextNpcs { get;} = new();
        public List<TextPlayer> TextPlayers { get; set; } = new();

        public TextNpc GetTextNpc()
        {
            if (TextNpcs.Count == 0) return null;
            
            if (Npc == null) return TextNpcs.First();
            
            var relationship = SettingsManager.LoadNpcRelationship(Npc.Marker);
            return TextNpcs.FirstOrDefault(textNpc => textNpc.Relationship == relationship);
        }

        public List<TextPlayer> GetTextPlayer()
        {
            return TextPlayers.Count == 0 ? null : TextPlayers;
        }
    }
}