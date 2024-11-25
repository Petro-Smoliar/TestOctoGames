namespace CNS.Manager
{
    public interface IDescriptionManager
    {
        void LoadDescription();
        
        string GetDescription(int? id);
    }
}