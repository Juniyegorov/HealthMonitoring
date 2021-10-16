using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HealthMonitoring.DataAccessLayer.Models
{
    public partial class HealthMonitoringContext : DbContext
    {
        public HealthMonitoringContext()
        {
        }

        public HealthMonitoringContext(DbContextOptions<HealthMonitoringContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CaloriesExpendedPerDay> CaloriesExpendedPerDays { get; set; }
        public virtual DbSet<CaloriesReceivedPerDay> CaloriesReceivedPerDays { get; set; }
        public virtual DbSet<CategoriesOfProduct> CategoriesOfProducts { get; set; }
        public virtual DbSet<CharacteristicsOfTheDish> CharacteristicsOfTheDishes { get; set; }
        public virtual DbSet<CompletedExercise> CompletedExercises { get; set; }
        public virtual DbSet<CompositionOfTheDish> CompositionOfTheDishes { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<EatenDish> EatenDishes { get; set; }
        public virtual DbSet<EatenProduct> EatenProducts { get; set; }
        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserCharacteristic> UserCharacteristics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-DTDCJOQ\\SQLEXPRESS;Database=HealthMonitoring;User Id=sa;Password=2034329;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<CaloriesExpendedPerDay>(entity =>
            {
                entity.ToTable("CaloriesExpendedPerDay");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CaloriesExpendedPerDays)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__CaloriesE__UserI__412EB0B6");
            });

            modelBuilder.Entity<CaloriesReceivedPerDay>(entity =>
            {
                entity.ToTable("CaloriesReceivedPerDay");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CaloriesReceivedPerDays)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__CaloriesR__UserI__3D5E1FD2");
            });

            modelBuilder.Entity<CategoriesOfProduct>(entity =>
            {
                entity.ToTable("CategoriesOfProduct");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(120);
            });

            modelBuilder.Entity<CharacteristicsOfTheDish>(entity =>
            {
                entity.ToTable("CharacteristicsOfTheDish");

                entity.HasOne(d => d.Dish)
                    .WithMany(p => p.CharacteristicsOfTheDishes)
                    .HasForeignKey(d => d.DishId)
                    .HasConstraintName("FK__Character__DishI__300424B4");
            });

            modelBuilder.Entity<CompletedExercise>(entity =>
            {
                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Exercise)
                    .WithMany(p => p.CompletedExercises)
                    .HasForeignKey(d => d.ExerciseId)
                    .HasConstraintName("FK__Completed__Exerc__38996AB5");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CompletedExercises)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Completed__UserI__37A5467C");
            });

            modelBuilder.Entity<CompositionOfTheDish>(entity =>
            {
                entity.ToTable("CompositionOfTheDish");

                entity.HasOne(d => d.Dish)
                    .WithMany(p => p.CompositionOfTheDishes)
                    .HasForeignKey(d => d.DishId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Compositi__DishI__5CD6CB2B");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CompositionOfTheDishes)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Compositi__Produ__5DCAEF64");
            });

            modelBuilder.Entity<Dish>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<EatenDish>(entity =>
            {
                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Weight).HasDefaultValueSql("((100))");

                entity.HasOne(d => d.Dish)
                    .WithMany(p => p.EatenDishes)
                    .HasForeignKey(d => d.DishId)
                    .HasConstraintName("FK__EatenDish__DishI__45F365D3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EatenDishes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__EatenDish__UserI__44FF419A");
            });

            modelBuilder.Entity<EatenProduct>(entity =>
            {
                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Weight).HasDefaultValueSql("((100))");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.EatenProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EatenProd__Produ__619B8048");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EatenProducts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EatenProd__UserI__60A75C0F");
            });

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Weight).HasDefaultValueSql("((100))");

                entity.HasOne(d => d.CategoryOfProduct)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryOfProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Products__Catego__5441852A");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<UserCharacteristic>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCharacteristics)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserChara__UserI__32E0915F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
