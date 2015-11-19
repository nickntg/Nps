using System.Linq;

namespace ETravel.Nps.Service.Factories
{
    public static class NpsResponseFactory
    {
        public static Models.Nps ToModel(this DataAccess.Entities.Nps nps)
        {
            if (nps == null)
            {
                return null;
            }

            return new Models.Nps
            {
                brand = nps.Brand,
                comment = nps.Comment,
                country = nps.Country,
                id = nps.Id,
                language = nps.Language,
                ratable_id = nps.RatableId,
                ratable_type = nps.RatableType,
                score = nps.Score,
                created_at = nps.CreatedAt.ToString("O"),
                updated_at = nps.UpdatedAt.ToString("O")
            };
        }

        public static Models.Nps[] ToModel(this DataAccess.Entities.Nps[] nps)
        {
            if (nps == null)
            {
                return null;
            }

            return nps.Select(n => n.ToModel()).ToArray();
        }
    }
}