using MediatR;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.UseCases.Commands;
using UrlShortener.Application.UseCases.DTOs;

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
            if (!result)
            {
                return BadRequest(new ProblemDetails
                {
                    Title = "Error",
                    Detail = "Failed to create short URL. Please check the provided long URL.",
                    Status = StatusCodes.Status400BadRequest
                });
            }

            return Created();
        }
    }
}
