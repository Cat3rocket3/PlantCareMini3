using Microsoft.EntityFrameworkCore;
using PlantCareMini.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantCareMini.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Plant> Plants => Set<Plant>();
        public DbSet<Watering> Waterings => Set<Watering>();
        public DbSet<CareNote> CareNotes => Set<CareNote>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Plant>()
                .HasKey(plant => plant.Id);

            modelBuilder.Entity<Watering>(entity =>
            {
                entity.HasKey(watering => watering.Id);

                entity.HasOne(watering => watering.Plant)
                    .WithMany(plant => plant.Waterings)
                    .HasForeignKey(watering => watering.PlantId);
            });

            modelBuilder.Entity<CareNote>(entity =>
            {
                entity.HasKey(note => note.Id);

                entity.Property(note => note.Text)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(note => note.Plant)
                    .WithMany(plant => plant.CareNotes)
                    .HasForeignKey(note => note.PlantId);
            });
        }
    }
}
