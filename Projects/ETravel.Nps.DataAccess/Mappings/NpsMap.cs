using FluentNHibernate.Mapping;

namespace ETravel.Nps.DataAccess.Mappings
{
    public class NpsMap : ClassMap<Entities.Nps>
    {
        public NpsMap()
        {
            Table("ratings");
            Id(x => x.Id, "id").GeneratedBy.Assigned();
            Map(x => x.RatableType, "ratable_type");
            Map(x => x.RatableId, "ratable_id");
            Map(x => x.Score, "score");
            Map(x => x.Comment, "comment").Length(4000);
            Map(x => x.CreatedAt, "created_at");
            Map(x => x.UpdatedAt, "updated_at");
            Map(x => x.Language, "language");
            Map(x => x.Brand, "brand");
            Map(x => x.Country, "country");
        }
    }
}