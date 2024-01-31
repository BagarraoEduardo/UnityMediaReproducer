using MediaAPI.Domain.Common;

namespace MediaAPI.Domain.Entities;

public class DownloadedFile
{
    public long Id { get; set; }
    public string MimeType { get; set; }
    public string Filename { get; set; }
    public byte[] FileContent { get; set; }
}
