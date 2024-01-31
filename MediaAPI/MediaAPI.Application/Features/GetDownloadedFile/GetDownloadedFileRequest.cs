using MediaAPI.Application.Features.GetDownloadedFile;
using MediaAPI.Domain.Entities;
using MediatR;

namespace MediaAPI.Application.Features.GetDownloadedFile;

public class GetDownloadedFileRequest : IRequest<GetDownloadedFileResponse>;
