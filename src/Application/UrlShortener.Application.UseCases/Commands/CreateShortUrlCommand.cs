using MediatR;
using UrlShortener.Application.UseCases.DTOs;

namespace UrlShortener.Application.UseCases.Commands
{
    public sealed record CreateShortUrlCommand : IRequest<bool>
    {
        public required string LongUrl { get; init; }
    }
}
