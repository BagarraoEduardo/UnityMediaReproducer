using MediaAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediaAPI.Infraestructure.Context;

public class MediaAPIContext : DbContext
{    
    public DbSet<DownloadedFile> DownloadedFiles { get; set; }

    public MediaAPIContext(DbContextOptions<MediaAPIContext> options) : base(options)
    {
	        
    }
}
