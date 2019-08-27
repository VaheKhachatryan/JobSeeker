using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JobSeeker.DatabaseLayer.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<DictionaryEmploymentType> DictionaryEmploymentType { get; set; }
        public virtual DbSet<DictionaryJobCategory> DictionaryJobCategory { get; set; }
        public virtual DbSet<Job> Job { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City", "Global");

                entity.HasIndex(e => e.CityName)
                    .HasName("IX_Global_City_CityName");

                entity.HasIndex(e => e.CountryId)
                    .HasName("IX_City_CountyId");

                entity.Property(e => e.CityId).ValueGeneratedNever();

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Global_Country");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country", "Global");

                entity.Property(e => e.CountryId).ValueGeneratedNever();

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<DictionaryEmploymentType>(entity =>
            {
                entity.ToTable("DictionaryEmploymentType", "Global");

                entity.Property(e => e.DictionaryEmploymentTypeId).ValueGeneratedNever();

                entity.Property(e => e.EmploymentType)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<DictionaryJobCategory>(entity =>
            {
                entity.ToTable("DictionaryJobCategory", "Global");

                entity.HasIndex(e => e.Category)
                    .HasName("IX_Global_DictionaryJobCategory_Category");

                entity.Property(e => e.DictionaryJobCategoryId).ValueGeneratedNever();

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job", "Jobs");

                entity.HasIndex(e => new { e.Title, e.Description, e.DictionaryJobCategoryId, e.DictionaryEmploymentTypeId, e.CityId })
                    .HasName("IX_Job");

                entity.Property(e => e.Description).HasColumnType("nvarchar(max)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Global_City");

                entity.HasOne(d => d.DictionaryEmploymentType)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.DictionaryEmploymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Global_DictionaryEmploymentType");

                entity.HasOne(d => d.DictionaryJobCategory)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.DictionaryJobCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Global_DictionaryJobCategory");
            });
        }
    }
}
