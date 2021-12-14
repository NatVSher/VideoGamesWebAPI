using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VideoGamesDb.Models;

namespace VideoGamesDb
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<Genre> Genres { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasMany(p => p.VideoGames).WithMany(p => p.Genres);

            modelBuilder.Entity<Genre>().HasData(new List<Genre>()
            {
                new Genre(1, "Genre1"),
                new Genre(2, "Genre2"),
                new Genre(3, "Genre3")
            });

            modelBuilder.Entity<VideoGame>().HasData(new List<VideoGame>()
            {
                new VideoGame(1, "Game1", "DeveloperStudio1"),
                new VideoGame(2, "Game2", "DeveloperStudio2"),
                new VideoGame(3, "Game3", "DeveloperStudio3")
            });
        }
    }
}
