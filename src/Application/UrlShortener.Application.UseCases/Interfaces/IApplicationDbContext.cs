using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.UseCases.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<ShortenedUrl> ShortenedUrls { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
