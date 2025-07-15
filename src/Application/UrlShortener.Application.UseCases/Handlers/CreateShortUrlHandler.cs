using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using UrlShortener.Application.UseCases.Commands;
using UrlShortener.Application.UseCases.Interfaces;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.UseCases.Handlers
{
    public class CreateShortUrlHandler : IRequestHandler<CreateShortUrlCommand, bool>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUrlShorteningService _urlShorteningService;

        public CreateShortUrlHandler(IApplicationDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor, IUrlShorteningService urlShorteningService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _urlShorteningService = urlShorteningService;
        }

        public async Task<bool> Handle(CreateShortUrlCommand request, CancellationToken cancellationToken)
        {
            var code = await _urlShorteningService.GenerateUniqueCode();
            var shortUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.ToString()}/{code.ToString()}";
            var shortenedUrl = _mapper.Map<ShortenedUrl>(request);
            shortenedUrl.ShortUrl = shortUrl;
            shortenedUrl.Code = code.ToString()!;
            await _dbContext.ShortenedUrls.AddAsync(shortenedUrl, cancellationToken);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
