namespace ETravel.Nps.Service.Factories
{
    /// <summary>
    /// Creates data entities from models.
    /// </summary>
    public static class NpsDataFactory
    {
        /// <summary>
        /// Converts a web model to a data entity.
        /// </summary>
        /// <param name="nps"></param>
        /// <returns></returns>
        public static DataAccess.Entities.Nps FromModel(this Models.Nps nps)
        {
            if (nps == null)
            {
                return null;
            }

            return new DataAccess.Entities.Nps
            {
                Brand = nps.brand,
                Comment = nps.comment,
                Country = nps.country,
                Id = nps.id,
                Language = nps.language,
                RatableId = nps.ratable_id,
                RatableType = nps.ratable_type,
                Score = nps.score
            };
        }
    }
}