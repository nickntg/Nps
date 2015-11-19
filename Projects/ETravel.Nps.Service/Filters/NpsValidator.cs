using System.Net;
using FluentValidation;

namespace ETravel.Nps.Service.Filters
{
    /// <summary>
    /// This validator ensures that an NPS model is valid.
    /// </summary>
    public class NpsValidator : AbstractValidator<Models.Nps>
    {
        /// <summary>
        /// True to validate only score (PUT).
        /// Otherwise, validate everything.
        /// </summary>
        public bool ValidateScoreOnly { get; set; }

        /// <summary>
        /// Validates an NPS model.
        /// </summary>
        public NpsValidator()
        {
            RuleFor(nps => nps).NotNull().WithMessage(ValidationMessages.InvalidOrEmptyNps).WithState(x => HttpStatusCode.BadRequest);
            When(nps => nps != null && !ValidateScoreOnly, () =>
            {
                RuleFor(nps => nps.brand)
                    .NotEmpty()
                    .WithMessage(ValidationMessages.BrandMustHaveAValue)
                    .WithState(x => (HttpStatusCode) 422);
                RuleFor(nps => nps.country)
                    .NotEmpty()
                    .WithMessage(ValidationMessages.CountryMustHaveAValue)
                    .WithState(x => (HttpStatusCode) 422);
                RuleFor(nps => nps.language)
                    .NotEmpty()
                    .WithMessage(ValidationMessages.LanguageMustHaveAValue)
                    .WithState(x => (HttpStatusCode) 422);
                RuleFor(nps => nps.ratable_id)
                    .NotEmpty()
                    .WithMessage(ValidationMessages.RatableIdMustHaveAValue)
                    .WithState(x => (HttpStatusCode) 422);
                RuleFor(nps => nps.ratable_type)
                    .NotEmpty()
                    .WithMessage(ValidationMessages.RatableTypeMustHaveAValue)
                    .WithState(x => (HttpStatusCode) 422);
            });
            When(nps => nps != null, () => RuleFor(nps => nps.score)
                .InclusiveBetween(1, 10)
                .WithMessage(ValidationMessages.ScoreMustBeBetweenOneAndTen)
                .WithState(x => (HttpStatusCode) 422));
        }
    }
}