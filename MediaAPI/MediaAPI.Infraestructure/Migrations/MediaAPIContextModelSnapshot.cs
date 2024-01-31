﻿// <auto-generated />
using MediaAPI.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MediaAPI.Infraestructure.Migrations
{
    [DbContext(typeof(MediaAPIContext))]
    partial class MediaAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MediaAPI.Domain.Entities.DownloadedFile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<byte[]>("FileContent")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("Filename")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("DownloadedFiles");
                });
#pragma warning restore 612, 618
        }
    }
}