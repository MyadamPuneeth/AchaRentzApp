using System;
using System.Collections.Generic;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : 
        base(options)
    {
    }

    public virtual DbSet<CarDetail> CarDetail { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<RentalDetail> RentalDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=192.168.0.30;Initial Catalog=AchaRentzDb;User ID=User5;Password=CDev005#8;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarDetail>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("PK__CarDetai__68A0342E54D03EA0");

            entity.Property(e => e.AvailableFrom).HasColumnType("datetime");
            entity.Property(e => e.AvailableUntil).HasColumnType("datetime");
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.DistanceFromUser).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EngineType).HasMaxLength(50);
            entity.Property(e => e.Faqs).HasColumnName("FAQs");
            entity.Property(e => e.FuelType).HasMaxLength(50);
            entity.Property(e => e.HasGPS).HasColumnName("HasGPS");
            entity.Property(e => e.Height).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.InsuranceExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.InsuranceProvider).HasMaxLength(255);
            entity.Property(e => e.LastServicedDate).HasColumnType("datetime");
            entity.Property(e => e.Length).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.LicensePlate).HasMaxLength(50);
            entity.Property(e => e.Make).HasMaxLength(255);
            entity.Property(e => e.Mileage).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Model).HasMaxLength(255);
            entity.Property(e => e.OwnerAddress).HasMaxLength(255);
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            entity.Property(e => e.RegistrationState).HasMaxLength(255);
            entity.Property(e => e.RentalLocation).HasMaxLength(255);
            entity.Property(e => e.RentalPricePerDay).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Transmission).HasMaxLength(50);
            entity.Property(e => e.UserRating).HasColumnType("decimal(2, 1)");
            entity.Property(e => e.Username).HasMaxLength(255);
            entity.Property(e => e.Width).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.OwnerId).HasName("PK__Owners__819385B8BD5F1010");

            entity.HasOne(d => d.Car).WithMany(p => p.Owners)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__Owners__CarId__29572725");

            entity.HasOne(d => d.User).WithMany(p => p.Owners)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Owners__UserId__286302EC");
        });

        modelBuilder.Entity<RentalDetail>(entity =>
        {
            entity.HasKey(e => e.RentalId).HasName("PK__RentalDe__9700594377F59681");

            entity.Property(e => e.FromDateTime).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.ToDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Car).WithMany(p => p.RentalDetails)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__RentalDet__CarId__2D27B809");

            entity.HasOne(d => d.User).WithMany(p => p.RentalDetails)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__RentalDet__UserI__2C3393D0");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C34BDF440");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.UserName).HasMaxLength(255);
            entity.Property(e => e.UserType).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
