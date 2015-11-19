using System;

namespace ETravel.Nps.DataAccess.Entities
{
    public class Nps
    {
        public virtual string Id { get; set; }
        public virtual string RatableType { get; set; }
        public virtual string RatableId { get; set; }
        public virtual int Score { get; set; }
        public virtual string Comment { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime? UpdatedAt { get; set; }
        public virtual string Language { get; set; }
        public virtual string Brand { get; set; }
        public virtual string Country { get; set; }
    }
}
