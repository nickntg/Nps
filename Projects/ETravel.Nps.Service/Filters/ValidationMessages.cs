namespace ETravel.Nps.Service.Filters

{
    /// <summary>
    /// Placeholder for validation error messages;
    /// </summary>
    public class ValidationMessages
    {
        /// <summary>
        /// Returned when there's no NPS argument detected. 
        /// </summary>
        /// <remarks>This should never be encountered...</remarks>
        public static string NoNpsArguments = "No NPS argument";

        /// <summary>
        /// Returned when there's no NPS passed.
        /// </summary>
        public static string InvalidOrEmptyNps = "Invalid or empty nps";

        /// <summary>
        /// Returned when a brand is null or empty.
        /// </summary>
        public static string BrandMustHaveAValue = "Brand must have a value";

        /// <summary>
        /// Returned when a country is null or empty.
        /// </summary>
        public static string CountryMustHaveAValue = "Country must have a value";

        /// <summary>
        /// Returned when a language is null or empty.
        /// </summary>
        public static string LanguageMustHaveAValue = "Language must have a value";

        /// <summary>
        /// Returned when ratable id is null or empty.
        /// </summary>
        public static string RatableIdMustHaveAValue = "Ratable id must have a value";

        /// <summary>
        /// Returned when ratable type is null or empty.
        /// </summary>
        public static string RatableTypeMustHaveAValue = "Ratable type must have a value";

        /// <summary>
        /// Returned if a score is not between 1 and 10.
        /// </summary>
        public static string ScoreMustBeBetweenOneAndTen = "Score must be 1-10";
    }
}