using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using UrlShortener.Application.UseCases.Interfaces;
using UrlShortener.Persistence.Configurations;

namespace UrlShortener.Persistence.Services
{
    public class UrlShorteningService : IUrlShorteningService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ShortLinkSettings _settings;
        private readonly Random _random = new();

        public UrlShorteningService(IApplicationDbContext dbContext, IOptions<ShortLinkSettings> options)
        {
            _dbContext = dbContext;
            _settings = options.Value;
        }

        public async Task<string> GenerateUniqueCode()
        {
            var codeChars = new char[_settings.Length];
            int maxValue = _settings.Alphabet.Length;

            const int maxRetries = 1000;
            for (int attempt = 0; attempt < maxRetries; attempt++)
            {
                for (var i = 0; i < _settings.Length; i++)
                {
                    var randomIndex = _random.Next(maxValue);
                    codeChars[i] = _settings.Alphabet[randomIndex];
                }

                var code = new string(codeChars);

                if (!await _dbContext.ShortenedUrls.AnyAsync(s => s.Code == code))
                {
                    return code;
                }
            }

            throw new Exception("A unique code could not be generated after multiple attempts.");
        }
    }
}
