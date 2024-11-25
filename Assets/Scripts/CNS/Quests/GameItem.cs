using UnityEngine;

namespace CNS.Quests
{
    public class GameItem
    {
        public string Name;
        public readonly Sprite Sprite;

        public GameItem(Sprite sprite)
        {
            Sprite = sprite;
        }
    }
}