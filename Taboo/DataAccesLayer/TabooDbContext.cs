using Microsoft.EntityFrameworkCore;
using Taboo.Entities;

namespace Taboo.DataAccesLayer
{
    public class TabooDbContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public TabooDbContext(DbContextOptions opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(e =>
            {
                e.HasKey(x => x.Code);
                e.Property(x => x.Code)
                    .IsFixedLength(true)
                    .HasMaxLength(2);

                e.HasIndex(x => x.Name)
                    .IsUnique();
                e.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(32);

                e.Property(x => x.Icon)
                    .HasMaxLength(128);
                e.HasData(new Language
                {
                    Code = "az",
                    Name = "Azərbaycan",
                    Icon = "string"
                });
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
