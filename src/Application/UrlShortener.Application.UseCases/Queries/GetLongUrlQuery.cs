using MediatR;
using UrlShortener.Application.UseCases.DTOs;

namespace UrlShortener.Application.UseCases.Queries
{
    public sealed record GetLongUrlQuery : IRequest<LongUrlResponseDTO>
    {
        public string Code { get; set; }
    }
}
