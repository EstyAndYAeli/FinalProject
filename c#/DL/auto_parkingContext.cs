using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DL
{
    public partial class auto_parkingContext : DbContext
    {
        //public auto_parkingContext()
        //{
        //}

        public auto_parkingContext(DbContextOptions<auto_parkingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Costumer> Costumer { get; set; }
        public virtual DbSet<CreditDetails> CreditDetails { get; set; }
        public virtual DbSet<ParkingHistory> ParkingHistory { get; set; }
        public virtual DbSet<ParkingLot> ParkingLot { get; set; }
        public virtual DbSet<ParkingManager> ParkingManager { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Rate> Rate { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=srv2\\pupils;Database=auto_parking;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.NumberLicensePlate);

                entity.ToTable("car");

                entity.Property(e => e.NumberLicensePlate)
                    .HasColumnName("number_license_plate")
                    .HasMaxLength(50);

                entity.Property(e => e.CarType).HasColumnName("car_type");

                entity.Property(e => e.CostumerId).HasColumnName("costumer_id");

                entity.HasOne(d => d.Costumer)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.CostumerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_car_costumer");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comment");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.CostumerId).HasColumnName("costumer_id");

                entity.Property(e => e.ExposeCostumerName).HasColumnName("expose_costumer_name");

                entity.Property(e => e.ForManager).HasColumnName("for_manager");

                entity.Property(e => e.Recommendation)
                    .IsRequired()
                    .HasColumnName("recommendation");

                entity.HasOne(d => d.Costumer)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.CostumerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_comment_costumer");
            });

            modelBuilder.Entity<Costumer>(entity =>
            {
                entity.ToTable("costumer");

                entity.Property(e => e.CostumerId).HasColumnName("costumer_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnName("phone_number")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<CreditDetails>(entity =>
            {
                entity.HasKey(e => e.CreditId);

                entity.ToTable("credit_details");

                entity.Property(e => e.CreditId).HasColumnName("credit_id");

                entity.Property(e => e.BackDigits)
                    .IsRequired()
                    .HasColumnName("back_digits")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CostumerId).HasColumnName("costumer_id");

                entity.Property(e => e.ExpiryDate)
                    .IsRequired()
                    .HasColumnName("expiry_date")
                    .HasMaxLength(4)
                    .IsFixedLength();

                entity.Property(e => e.FrontDigits)
                    .IsRequired()
                    .HasColumnName("front_digits")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Costumer)
                    .WithMany(p => p.CreditDetails)
                    .HasForeignKey(d => d.CostumerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_credit_details_costumer");
            });

            modelBuilder.Entity<ParkingHistory>(entity =>
            {
                entity.HasKey(e => e.ParkingLotId);

                entity.ToTable("parking_history");

                entity.Property(e => e.ParkingLotId).HasColumnName("parking_lot_id");

                entity.Property(e => e.DateEntryParking)
                    .HasColumnName("date_entry_parking")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.DateExitParking)
                    .HasColumnName("date_exit_parking")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.IsEntry).HasColumnName("is_entry");

                entity.Property(e => e.NumberLicensePlate)
                    .IsRequired()
                    .HasColumnName("number_license_plate")
                    .HasMaxLength(50);

                entity.Property(e => e.ParkingId).HasColumnName("parking_id");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.HasOne(d => d.NumberLicensePlateNavigation)
                    .WithMany(p => p.ParkingHistory)
                    .HasForeignKey(d => d.NumberLicensePlate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_parking_history_car");

                entity.HasOne(d => d.Parking)
                    .WithMany(p => p.ParkingHistory)
                    .HasForeignKey(d => d.ParkingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_history_parking");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.ParkingHistory)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_parking_history_payment");
            });

            modelBuilder.Entity<ParkingLot>(entity =>
            {
                entity.HasKey(e => e.ParkingId)
                    .HasName("PK_parking");

                entity.ToTable("parking_lot");

                entity.Property(e => e.ParkingId).HasColumnName("parking_id");

                entity.Property(e => e.Adress)
                    .HasColumnName("adress")
                    .HasMaxLength(50);

                entity.Property(e => e.ManagerId).HasColumnName("manager_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.NumOfDisabled).HasColumnName("num_of_disabled");

                entity.Property(e => e.NumOfRegular).HasColumnName("num_of_regular");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.ParkingLot)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_parking_parking_manager1");
            });

            modelBuilder.Entity<ParkingManager>(entity =>
            {
                entity.HasKey(e => e.ManagerId);

                entity.ToTable("parking_manager");

                entity.Property(e => e.ManagerId).HasColumnName("manager_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payment");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.Amount).HasColumnName("amount");
            });

            modelBuilder.Entity<Rate>(entity =>
            {
                entity.ToTable("rate");

                entity.Property(e => e.RateId).HasColumnName("rate_id");

                entity.Property(e => e.BeginsAt).HasColumnName("beginsAt");

                entity.Property(e => e.EndsAt).HasColumnName("endsAt");

                entity.Property(e => e.ParkingId).HasColumnName("parking_id");

                entity.Property(e => e.PayPerHour)
                    .HasColumnName("pay_per_hour")
                    .HasColumnType("money");

                entity.HasOne(d => d.Parking)
                    .WithMany(p => p.Rate)
                    .HasForeignKey(d => d.ParkingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rate_parking");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
