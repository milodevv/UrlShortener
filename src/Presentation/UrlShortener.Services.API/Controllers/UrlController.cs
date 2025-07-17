using MediatR;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.UseCases.Commands;
using UrlShortener.Application.UseCases.Queries;

namespace UrlShortener.Services.API.Controllers
{
    [ApiController]
    [Route("api/url")]
    public class UrlController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UrlController(IMediator mediator)
        {
            _mediator = mediator;
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
            var splitUrl = shortUrl.Split("%2F");
            var code = splitUrl[splitUrl.Length - 1];
            var longUrlResponse = await _mediator.Send(new GetLongtUrlQuery { Code = code });
            if (longUrlResponse is null)
            {
                return BadRequest(new ProblemDetails
                {
                    Title = "Error",
                    Detail = "Failed to get long URL",
                    Status= StatusCodes.Status400BadRequest
                });
            }

            return Ok(longUrlResponse.LongUrl);
        }
    }
}
