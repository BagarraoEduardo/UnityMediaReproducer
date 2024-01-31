using MediaAPI.Application.Features.GetDownloadedFile;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediaAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AudioController : ControllerBase
{
    private readonly ILogger<AudioController> _logger;
    private readonly IMediator _mediator;

    public AudioController(
        ILogger<AudioController> logger, 
        IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost(Name = "Download")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(GetDownloadedFileResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(GetDownloadedFileResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Download()
    {
        var response = new GetDownloadedFileResponse();

        try
        {
            response = await _mediator.Send(new GetDownloadedFileRequest());
            
            return Ok(response);
        }
        catch(Exception exception)
        {
            var errorMessage = $"An exception has ocurred. Error: {exception.Message}";
            _logger.LogError(exception, errorMessage);
            response.ErrorMessage = errorMessage;

            return BadRequest(response); 
        }
    }
}
