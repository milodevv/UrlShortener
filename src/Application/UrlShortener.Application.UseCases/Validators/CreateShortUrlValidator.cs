using FluentValidation;
using UrlShortener.Application.UseCases.Commands;

namespace UrlShortener.Application.UseCases.Validators
{
    public class CreateShortUrlValidator : AbstractValidator<CreateShortUrlCommand>
    {
        public CreateShortUrlValidator()
        {
            RuleFor(x => x.LongUrl).NotEmpty().NotNull().Must(BeAValidUrl).WithMessage("The provided URL is not valid");
        }

        private bool BeAValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out var uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
