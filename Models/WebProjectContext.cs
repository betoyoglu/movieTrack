using System;


using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebProject.Models;

public partial class WebProjectContext : DbContext
{
    public WebProjectContext()
    {
    }

    public WebProjectContext(DbContextOptions<WebProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anime> Animes { get; set; }

    public virtual DbSet<MovieNameDirector> MovieNameDirectors { get; set; }

    public virtual DbSet<Seriess> Seriesses { get; set; }

    public virtual DbSet<Upcoming> Upcomings { get; set; }

    public virtual DbSet<WatchList> WatchLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-HF69CDLC; Initial Catalog=WebProject; Trusted_Connection=True; Integrated Security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anime>(entity =>
        {
            entity.ToTable("anime");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnimeCategory)
                .HasMaxLength(10)
                .HasColumnName("anime_category");
            entity.Property(e => e.AnimeName)
                .HasMaxLength(50)
                .HasColumnName("anime_name");
            entity.Property(e => e.AnimeReleaseDate)
                .HasColumnType("date")
                .HasColumnName("anime_release_date");
        });

        modelBuilder.Entity<MovieNameDirector>(entity =>
        {
            entity.ToTable("movie_name_director");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MovieDirector)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("movie_director");
            entity.Property(e => e.MovieName)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("movie_name");
        });

        modelBuilder.Entity<Seriess>(entity =>
        {
            entity.ToTable("Seriess");
        });

        modelBuilder.Entity<Upcoming>(entity =>
        {
            entity.ToTable("upcoming");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DurationTime).HasColumnName("duration_time");
            entity.Property(e => e.Episode).HasColumnName("episode");
            entity.Property(e => e.ReleaseDate)
                .HasColumnType("datetime")
                .HasColumnName("release_date");
            entity.Property(e => e.Season).HasColumnName("season");
            entity.Property(e => e.SeriesName)
                .HasMaxLength(50)
                .HasColumnName("series_name");
        });

        modelBuilder.Entity<WatchList>(entity =>
        {
            entity.ToTable("WatchList");

            entity.Property(e => e.Did_you_watch_it).HasColumnName("Did_you_watch_it");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
