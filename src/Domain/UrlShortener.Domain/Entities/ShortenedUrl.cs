using UrlShortener.Domain.Commons;

namespace UrlShortener.Domain.Entities;

public class ShortenedUrl : BaseAuditableEntity
{
    public string LongUrl { get; set; } = string.Empty;
    public string ShortUrl { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
}
