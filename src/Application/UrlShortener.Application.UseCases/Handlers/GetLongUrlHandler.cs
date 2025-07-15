using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Application.UseCases.DTOs;
using UrlShortener.Application.UseCases.Interfaces;
using UrlShortener.Application.UseCases.Queries;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.UseCases.Handlers
{
    public class GetLongUrlHandler : IRequestHandler<GetLongtUrlQuery, LongUrlResponseDTO>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetLongUrlHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<LongUrlResponseDTO> Handle(GetLongtUrlQuery request, CancellationToken cancellationToken)
        {
            var shortenedUrl = await _dbContext.ShortenedUrls.FirstOrDefaultAsync(x => x.Code == request.Code);
            var longUrlResponseDto = _mapper.Map<LongUrlResponseDTO>(shortenedUrl);
            return longUrlResponseDto;
        }
    }
}
