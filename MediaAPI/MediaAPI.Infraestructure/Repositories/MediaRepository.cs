using MediaAPI.Application.Repositories;
using MediaAPI.Domain;
using MediaAPI.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MediaAPI.Infraestructure;

public class MediaRepository : IMediaRepository
{
    private readonly MediaAPIContext _context;
    private readonly ILogger<MediaRepository> _logger;

    public MediaRepository(
        MediaAPIContext context, 
        ILogger<MediaRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<DownloadedFileResponse> GetDownloadedFile()
    {
        var response = new DownloadedFileResponse();

        try
        {
            var downloadedFile = await _context.DownloadedFiles.FirstOrDefaultAsync();

            if(downloadedFile != null)
            {
                response.Data = downloadedFile;
                response.Success = true;
            }
            else
            {
                response.ErrorMessage = "There is not any available file to download.";
            }
        }
        catch(Exception exception)
        {
            var errorMessage = $"An exception has ocurred. Error: {exception.Message}";
            _logger.LogError(exception, errorMessage);
            response.ErrorMessage = errorMessage;
        }

        return response;
    }
}
