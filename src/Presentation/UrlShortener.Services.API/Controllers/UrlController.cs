using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using UrlShortener.Application.UseCases.Commands;
using UrlShortener.Application.UseCases.Queries;

namespace UrlShortener.Services.API.Controllers
{
    [ApiController]
    [Route("api/url")]
    public class UrlController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;

        public UrlController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }

        [HttpPost("shorten")]
        public async Task<ActionResult> CreateShortUrl([FromBody] CreateShortUrlCommand command)
        {
            var result = await _mediator.Send(command);
            if (result is null)
            {
                return BadRequest(new ProblemDetails
                {
                    Title = "Error",
                    Detail = "Failed to create short URL. Please check the provided long URL.",
                    Status = StatusCodes.Status400BadRequest
                });
            }

            return Ok(result);
        }

        [HttpGet("{shortUrl}")]
        public async Task<ActionResult> GetLongUrl(string shortUrl)
        {
            string cacheKey = $"shortUrl_{shortUrl}";

            if (!_memoryCache.TryGetValue(cacheKey, out string? longUrl))
            {
                var splitUrl = shortUrl.Split("%2F");
                var code = splitUrl[^1];

                var longUrlResponse = await _mediator.Send(new GetLongUrlQuery { Code = code });
                if (longUrlResponse is null)
                {
                    return BadRequest(new ProblemDetails
                    {
                        Title = "Error",
                        Detail = "Failed to get long URL",
                        Status = StatusCodes.Status400BadRequest
                    });
                }

                longUrl = longUrlResponse.LongUrl;

                var options = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                _memoryCache.Set(cacheKey, longUrl, options);
            }

            return Ok(longUrl!);
        }
    }
}
