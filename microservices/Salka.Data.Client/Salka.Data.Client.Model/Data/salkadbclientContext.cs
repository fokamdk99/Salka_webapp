using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Salka.Data.Clients.Model.Data
{
    public partial class salkadbclientContext : DbContext
    {
        public salkadbclientContext()
        {
        }

        public salkadbclientContext(DbContextOptions<salkadbclientContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<RecordingStudio> RecordingStudios { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=host.docker.internal;database=salkadb.client;user=root;password=Rolka7Sushi");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("addresses");

                entity.HasIndex(e => e.CityId, "fk_Address_City_idx");

                entity.HasIndex(e => e.PostId, "fk_Address_Post1_idx");

                entity.Property(e => e.Street).HasMaxLength(45);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Address_City");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Address_Post1");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("cities");

                entity.Property(e => e.Name).HasMaxLength(45);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients");

                entity.HasIndex(e => e.AddressId, "fk_Client_Address1_idx");

                entity.HasIndex(e => e.RecordingStudioId, "fk_Client_RecordingStudio1_idx");

                entity.Property(e => e.Bandname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Client_Address1");

                entity.HasOne(d => d.RecordingStudio)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.RecordingStudioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Client_RecordingStudio1");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("posts");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<RecordingStudio>(entity =>
            {
                entity.ToTable("recordingstudios");

                entity.HasIndex(e => e.AddressId, "fk_RecordingStudio_Address1_idx");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.RecordingStudios)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_RecordingStudio_Address1");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasIndex(e => e.AddressId, "fk_Staff_Addresses1_idx");

                entity.HasIndex(e => e.RecordingStudioId, "fk_Staff_RecordingStudios1_idx");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Surname).HasMaxLength(100);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Staff_Addresses1");

                entity.HasOne(d => d.RecordingStudio)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.RecordingStudioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Staff_RecordingStudios1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
