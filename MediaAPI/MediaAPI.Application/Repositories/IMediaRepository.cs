using MediaAPI.Domain;
using MediaAPI.Domain.Entities;

namespace MediaAPI.Application.Repositories;

public interface IMediaRepository
{
    Task<DownloadedFileResponse> GetDownloadedFile();
}
