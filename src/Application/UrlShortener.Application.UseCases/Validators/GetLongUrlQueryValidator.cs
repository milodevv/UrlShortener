using FluentValidation;
using UrlShortener.Application.UseCases.Queries;

namespace UrlShortener.Application.UseCases.Validators
{
    public class GetLongUrlQueryValidator : AbstractValidator<GetLongUrlQuery>
    {
        public GetLongUrlQueryValidator()
        {
            RuleFor(x => x.Code).NotNull().NotEmpty().Must(code => code.Length == 9).WithMessage("Invalid code");
        }
    }
}
