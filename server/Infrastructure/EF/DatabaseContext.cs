namespace Infrastructure.EF
{
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
                 : base(options)
        {
        }

        public DbSet<Film> Film { get; set; }

        public DbSet<Genre> Genre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<Film>()
                 .HasMany(p => p.Genres)
                 .WithMany(p => p.Films)
                 .UsingEntity(j => j.ToTable("FilmGenre"));
        }
    }
}
