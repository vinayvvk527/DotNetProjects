using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EKart.Models
{
    public partial class ElectronicsstoreContext : DbContext
    {
        public ElectronicsstoreContext()
        {
        }

        public ElectronicsstoreContext(DbContextOptions<ElectronicsstoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<UserRegistration> UserRegistrations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:electstoreapp.database.windows.net,1433;Initial Catalog=Electronicsstore;Persist Security Info=False;User ID=Electappadmin;Password=Niit@#1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;\n");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Category)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.QuantityAvailable)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRegistration>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserRegi__1788CCACF11201C4");

                entity.ToTable("UserRegistration");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
