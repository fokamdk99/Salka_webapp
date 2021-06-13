using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Salka.Data.Schedules.Model.Data
{
    public partial class salkadbscheduleContext : DbContext
    {
        public salkadbscheduleContext()
        {
        }

        public salkadbscheduleContext(DbContextOptions<salkadbscheduleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<ReservationDate> Reservationdates { get; set; }
        public virtual DbSet<ReservationType> Reservationtypes { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=host.docker.internal;database=salkadb.schedule;user=root;password=Rolka7Sushi");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("reservations");

                entity.HasIndex(e => e.ReservationTypeId, "fk_Reservation_ReservationType1_idx");

                entity.Property(e => e.Comment).HasMaxLength(45);

                entity.Property(e => e.IsAcknowledged).HasColumnType("tinyint");

                entity.Property(e => e.IsPaymentCompleted).HasColumnType("tinyint");

                entity.Property(e => e.IsRegular).HasColumnType("tinyint");

                entity.Property(e => e.NumberOfVocals).HasMaxLength(45);

                entity.HasOne(d => d.ReservationType)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.ReservationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reservation_ReservationType1");
            });

            modelBuilder.Entity<ReservationDate>(entity =>
            {
                entity.ToTable("reservationdates");

                entity.HasIndex(e => e.ReservationId, "fk_ReservationDate_Reservation1_idx");

                entity.HasIndex(e => e.ScheduleId, "fk_ReservationDate_Schedule1_idx");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.ReservationDates)
                    .HasForeignKey(d => d.ReservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ReservationDate_Reservation1");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.ReservationDates)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ReservationDate_Schedule1");
            });

            modelBuilder.Entity<ReservationType>(entity =>
            {
                entity.ToTable("reservationtypes");

                entity.Property(e => e.IsProducerRequired).HasColumnType("tinyint");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("schedules");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
