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

    [HttpGet(Name = "Download")]
    // [Produces("audio/mpeg")]
    // [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
    // [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Download()
    {
        var response = new GetDownloadedFileResponse();

        try
        {
            response = await _mediator.Send(new GetDownloadedFileRequest());
            
            return File(response.FileContent, response.MimeType, response.Filename);
        }
        catch(Exception exception)
        {
            var errorMessage = $"An exception has ocurred. Error: {exception.Message}";
            _logger.LogError(exception, errorMessage);
            response.ErrorMessage = errorMessage;

            return BadRequest(); 
        }
    }
}
