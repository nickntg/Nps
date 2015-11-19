using System.Linq;
using ETravel.Nps.Service.Extensions;

namespace ETravel.Nps.Service.Factories
{
    /// <summary>
    /// Creates NPS responses from NPS models.
    /// </summary>
    public static class NpsResponseFactory
    {
        /// <summary>
        /// Converts from database model to web model.
        /// </summary>
        /// <param name="nps"></param>
        /// <returns></returns>
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
                created_at = nps.CreatedAt.ToIso8601(),
                updated_at = nps.UpdatedAt.ToIso8601()
            };
        }

        /// <summary>
        /// Converts an array of database models to an array of web models.
        /// </summary>
        /// <param name="nps"></param>
        /// <returns></returns>
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