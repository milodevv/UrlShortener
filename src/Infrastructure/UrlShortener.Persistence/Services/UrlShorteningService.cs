using Microsoft.EntityFrameworkCore;
using UrlShortener.Application.UseCases.DTOs;
using UrlShortener.Application.UseCases.Interfaces;

namespace UrlShortener.Persistence.Services
{
    public class UrlShorteningService : IUrlShorteningService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly Random _random = new();

        public UrlShorteningService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> GenerateUniqueCode()
        {
            var codeChars = new char[ShortLinkSettingsDTO.Length];
            int maxValue = ShortLinkSettingsDTO.Alphabet.Length;

            while (true)
            {
                for (var i = 0; i < ShortLinkSettingsDTO.Length; i++)
                {
                    var randomIndex = _random.Next(maxValue);

                    codeChars[i] = ShortLinkSettingsDTO.Alphabet[randomIndex];
                }

                var code = new string(codeChars);

                if (!await _dbContext.ShortenedUrls.AnyAsync(s => s.Code == code))
                {
                    return code;
                }
            }
        }
    }
}
