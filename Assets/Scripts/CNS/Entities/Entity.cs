using CNS.Enum;
using CNS.Models;

namespace CNS.Entities
{
    public class Entity
    {
        public Marker Marker { get; set; }
        public Model Model { get; private set; }

        public void SetModel(Model model)
        {
            this.Model = model;
        }
    }
}