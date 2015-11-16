namespace ETravel.Nps.Service.Models
{
    public class Nps
    {
        /// <summary>
        /// ID of the NPS. Assigned by the database backend.
        /// </summary>
        public virtual string id { get; set; }
        public virtual string ratable_type { get; set; }
        public virtual string ratable_id { get; set; }
        public virtual int score { get; set; }
        public virtual string comment { get; set; }
        public virtual string created_at { get; set; }
        public virtual string updated_at { get; set; }
        public virtual string language { get; set; }
        public virtual string brand { get; set; }
        public virtual string country { get; set; }
    }
}