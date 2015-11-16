namespace ETravel.Nps.DataAccess.Repositories.Interfaces
{
    public interface INpsRepository
    {
        void Save(Entities.Nps nps);
        Entities.Nps[] RetrieveByRatableType(string ratableType);
        Entities.Nps[] RetrieveByRatableId(string ratableId);
        Entities.Nps[] RetrieveByRatableTypeAndId(string ratableType, string ratableId);
        Entities.Nps Get(string id);
        void Update(Entities.Nps nps);
    }
}