using MediaAPI.Domain.Common;
using MediaAPI.Domain.Entities;

namespace MediaAPI.Domain;

public class DownloadedFileResponse : BaseResponse
{
    public DownloadedFile Data { get; set; }
}
