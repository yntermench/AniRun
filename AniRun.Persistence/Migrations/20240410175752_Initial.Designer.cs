﻿// <auto-generated />
using System;
using AniRun.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AniRun.Persistence.Migrations
{
    [DbContext(typeof(AniDbContext))]
    [Migration("20240410175752_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("AniRun")
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AniRun.Domain.Models.Episode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("EditedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<Guid>("TitleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("VideoId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TitleId");

                    b.HasIndex("VideoId");

                    b.ToTable("Episodes", "AniRun");
                });

            modelBuilder.Entity("AniRun.Domain.Models.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("EditedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres", "AniRun");
                });

            modelBuilder.Entity("AniRun.Domain.Models.Media", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("EditedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Medias", "AniRun");
                });

            modelBuilder.Entity("AniRun.Domain.Models.Studio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("EditedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Studios", "AniRun");
                });

            modelBuilder.Entity("AniRun.Domain.Models.Title", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeSpan?>("Duration")
                        .HasColumnType("interval");

                    b.Property<DateTimeOffset>("EditedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("EndDateTitle")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("LastEpisode")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("PictureId")
                        .HasColumnType("uuid");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("StartDateTitle")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid?>("StudioId")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PictureId");

                    b.HasIndex("StudioId");

                    b.ToTable("Titles", "AniRun");
                });

            modelBuilder.Entity("GenreTitle", b =>
                {
                    b.Property<Guid>("GenresId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TitlesId")
                        .HasColumnType("uuid");

                    b.HasKey("GenresId", "TitlesId");

                    b.HasIndex("TitlesId");

                    b.ToTable("GenreTitle", "AniRun");
                });

            modelBuilder.Entity("AniRun.Domain.Models.Episode", b =>
                {
                    b.HasOne("AniRun.Domain.Models.Title", "Title")
                        .WithMany("Episodes")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AniRun.Domain.Models.Media", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Title");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("AniRun.Domain.Models.Title", b =>
                {
                    b.HasOne("AniRun.Domain.Models.Media", "Picture")
                        .WithMany()
                        .HasForeignKey("PictureId");

                    b.HasOne("AniRun.Domain.Models.Studio", "Studio")
                        .WithMany("Titles")
                        .HasForeignKey("StudioId");

                    b.Navigation("Picture");

                    b.Navigation("Studio");
                });

            modelBuilder.Entity("GenreTitle", b =>
                {
                    b.HasOne("AniRun.Domain.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AniRun.Domain.Models.Title", null)
                        .WithMany()
                        .HasForeignKey("TitlesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AniRun.Domain.Models.Studio", b =>
                {
                    b.Navigation("Titles");
                });

            modelBuilder.Entity("AniRun.Domain.Models.Title", b =>
                {
                    b.Navigation("Episodes");
                });
#pragma warning restore 612, 618
        }
    }
}
