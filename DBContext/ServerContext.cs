using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using kmutt_x_covid.Models;

#nullable disable

namespace kmutt_x_covid.DBContext
{
    public partial class ServerContext : DbContext
    {
        public ServerContext()
        {
        }

        public ServerContext(DbContextOptions<ServerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<BuildingStampIn> BuildingStampIns { get; set; }
        public virtual DbSet<Groupcovid> Groupcovids { get; set; }
        public virtual DbSet<Infection> Infections { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Building>(entity =>
            {
                entity.ToTable("building");

                entity.Property(e => e.BuildingId)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("building_id");

                entity.Property(e => e.BuildingName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("building_name");
            });

            modelBuilder.Entity<BuildingStampIn>(entity =>
            {
                entity.HasKey(e => e.StampId)
                    .HasName("building_stamp_in_PK");

                entity.ToTable("building_stamp_in");

                entity.Property(e => e.StampId).HasColumnName("stamp_id");

                entity.Property(e => e.BuildingId)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("building_id");

                entity.Property(e => e.Floors).HasColumnName("floors");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TimeIn)
                    .HasColumnType("datetime")
                    .HasColumnName("time_in");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.BuildingStampIns)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("building_stamp_in_FK");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.BuildingStampIns)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("building_stamp_in_FK_User");
            });

            modelBuilder.Entity<Groupcovid>(entity =>
            {
                entity.HasKey(e => e.RiskId)
                    .HasName("groupcovid_PK");

                entity.ToTable("groupcovid");

                entity.Property(e => e.RiskId).HasColumnName("risk_id");

                entity.Property(e => e.RiskLevel)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("risk_level");
            });

            modelBuilder.Entity<Infection>(entity =>
            {
                entity.HasKey(e => e.Number)
                    .HasName("Infection_PK");

                entity.ToTable("Infection");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TimeInfection)
                    .HasColumnType("datetime")
                    .HasColumnName("time_infection");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Infections)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("Infection_FK");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("position");

                entity.Property(e => e.PositionId)
                    .ValueGeneratedNever()
                    .HasColumnName("position_id");

                entity.Property(e => e.PositionType)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("position_type");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("department");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.PositionId)
                    .HasColumnName("position_id")
                    .HasDefaultValueSql("((2))");

                entity.Property(e => e.RiskId)
                    .HasColumnName("risk_id")
                    .HasDefaultValueSql("((4))");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("User_FK_position");

                entity.HasOne(d => d.Risk)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RiskId)
                    .HasConstraintName("User_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
