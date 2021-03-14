using FluentValidation;

namespace StarWarsDemo.Web.Validators
{
    public class NewRatingValidator : AbstractValidator<string>
    {
        public NewRatingValidator()
        {
            Transform(from: x => x, to: value => int.TryParse(value, out int val) ? (int?)val : null)
                .NotNull()
                .WithMessage("Please specify a rating.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Rating must be greater or equal zero.")
                .LessThanOrEqualTo(10)
                .WithMessage("Rating must be less or equal 10");

        }
    }
}
