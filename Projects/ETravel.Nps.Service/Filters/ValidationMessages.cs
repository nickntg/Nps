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
        public const string NoNpsArguments = "No NPS argument";

        /// <summary>
        /// Returned where there's no arguments.
        /// </summary>
        /// <remarks>This should never be encountered...</remarks>
        public const string NoArguments = "No arguments";

        /// <summary>
        /// Returned when there's no NPS passed.
        /// </summary>
        public const string InvalidOrEmptyNps = "Invalid or empty nps";

        /// <summary>
        /// Returned when a brand is null or empty.
        /// </summary>
        public const string BrandMustHaveAValue = "Brand must have a value";

        /// <summary>
        /// Returned when a country is null or empty.
        /// </summary>
        public const string CountryMustHaveAValue = "Country must have a value";

        /// <summary>
        /// Returned when a language is null or empty.
        /// </summary>
        public const string LanguageMustHaveAValue = "Language must have a value";

        /// <summary>
        /// Returned when ratable id is null or empty.
        /// </summary>
        public const string RatableIdMustHaveAValue = "Ratable id must have a value";

        /// <summary>
        /// Returned when ratable type is null or empty.
        /// </summary>
        public const string RatableTypeMustHaveAValue = "Ratable type must have a value";

        /// <summary>
        /// Returned if a score is not between 1 and 10.
        /// </summary>
        public const string ScoreMustBeBetweenOneAndTen = "Score must be 1-10";

        /// <summary>
        /// Returned if both ratable id and type are missing.
        /// </summary>
        public const string RatableIdAndTypeMustNotBothBeEmpty = "Need ratable id or ratable type - both are null or empty";
    }
}