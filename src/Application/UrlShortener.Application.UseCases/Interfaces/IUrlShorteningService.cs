namespace UrlShortener.Application.UseCases.Interfaces
{
    public interface IUrlShorteningService
    {
        Task<string> GenerateUniqueCode();
    }
}
