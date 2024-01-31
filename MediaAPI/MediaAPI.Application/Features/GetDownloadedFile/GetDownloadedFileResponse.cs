using MediaAPI.Application.Common.Base;
using MediaAPI.Domain.Entities;

namespace MediaAPI.Application.Features.GetDownloadedFile;

public class GetDownloadedFileResponse : BaseResponse
{
    public string MimeType { get; set; }
    public string Filename { get; set; }
    public byte[] FileContent { get; set; }
}
