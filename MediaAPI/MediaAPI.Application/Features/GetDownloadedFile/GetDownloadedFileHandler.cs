using AutoMapper;
using MediaAPI.Application.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MediaAPI.Application.Features.GetDownloadedFile;

public class GetDownloadedFileHandler : IRequestHandler<GetDownloadedFileRequest, GetDownloadedFileResponse>
{
    private readonly IMediaRepository _mediaRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetDownloadedFileHandler> _logger;


    public GetDownloadedFileHandler(
        IMediaRepository mediaRepository,
        ILogger<GetDownloadedFileHandler> logger,
        IMapper mapper)
    {
        _mediaRepository = mediaRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<GetDownloadedFileResponse> Handle(
        GetDownloadedFileRequest request, 
        CancellationToken cancellationToken)
    {
        var response = new GetDownloadedFileResponse();

        try
        {
            response = _mapper.Map<GetDownloadedFileResponse>(await _mediaRepository.GetDownloadedFile());
        }
        catch(Exception exception)
        {
            var errorMessage = $"An exception has ocurred. Error: {exception.Message}";
            _logger.LogError(exception, errorMessage);
            response.Success = false;
            response.ErrorMessage = errorMessage;
        }

        return response;
    }
}
