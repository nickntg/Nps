namespace ETravel.Nps.Service.Models
{
    public class Nps
    {
        /// <summary>
        /// ID of the NPS. Assigned by the database backend.
        /// </summary>
        public virtual string id { get; set; }

        /// <summary>
        /// Ratable type of the NPS.
        /// </summary>
        public virtual string ratable_type { get; set; }

        /// <summary>
        /// Ratable ID of the NPS>
        /// </summary>
        public virtual string ratable_id { get; set; }

        /// <summary>
        /// NPS score (1-9).
        /// </summary>
        public virtual int score { get; set; }

        /// <summary>
        /// Customer comment.
        /// </summary>
        public virtual string comment { get; set; }

        /// <summary>
        /// NPS creation date (ISO 8601).
        /// </summary>
        public virtual string created_at { get; set; }

        /// <summary>
        /// NPS update date (ISO 8601).
        /// </summary>
        public virtual string updated_at { get; set; }

        /// <summary>
        /// Customer language.
        /// </summary>
        public virtual string language { get; set; }

        /// <summary>
        /// Brand used by customer.
        /// </summary>
        public virtual string brand { get; set; }

        /// <summary>
        /// Customer country.
        /// </summary>
        public virtual string country { get; set; }

        public override string ToString()
        {
            return
                string.Format(
                    "Id:[{0}], ratable type:[{1}], ratable id:[{2}], score:[{3}], comment: [{4}], language:[{5}], brand:[{6}], country:[{7}]",
                    id, ratable_type, ratable_id, score, comment, language, brand, country);
        }
    }
}