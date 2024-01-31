using AutoMapper;
using MediaAPI.Application.Features.GetDownloadedFile;
using MediaAPI.Domain;

namespace MediaAPI.Application;

public class GetDownloadedFileMapper : Profile
{
    public GetDownloadedFileMapper()
    {
        CreateMap<GetDownloadedFileResponse, DownloadedFileResponse>()
            .ReverseMap()
            .ForMember(dest => dest.MimeType, origin => origin.MapFrom(src => src.Data.MimeType))
            .ForMember(dest => dest.FileContent, origin => origin.MapFrom(src => src.Data.FileContent))
            .ForMember(dest => dest.Filename, origin => origin.MapFrom(src => src.Data.Filename));
    }
}
