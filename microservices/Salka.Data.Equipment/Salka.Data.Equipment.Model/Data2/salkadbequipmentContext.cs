using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Salka.Data.Equipments.Model.Data2
{
    public partial class salkadbequipmentContext : DbContext
    {
        public salkadbequipmentContext()
        {
        }

        public salkadbequipmentContext(DbContextOptions<salkadbequipmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<Equipmentcategory> Equipmentcategories { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=host.docker.internal;database=salkadb.equipment;user=root;password=Rolka7Sushi");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.ToTable("equipments");

                entity.HasIndex(e => e.EquipmentCategoryId, "fk_Equipment_EquipmentCategory1_idx");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.HasOne(d => d.EquipmentCategory)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.EquipmentCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Equipment_EquipmentCategory1");
            });

            modelBuilder.Entity<Equipmentcategory>(entity =>
            {
                entity.ToTable("equipmentcategories");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.ToTable("resources");

                entity.HasIndex(e => e.EquipmentId, "fk_Resource_Equipment1_idx");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Resource_Equipment1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
