using DAL.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public partial class TheatreContext : DbContext
    {
        public TheatreContext(DbContextOptions<TheatreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Checkout> Checkouts { get; set; }
        public virtual DbSet<Hole> Holes { get; set; }
        public virtual DbSet<Performance> Performances { get; set; }
        public virtual DbSet<Theatre> Theatres { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketStatus> TicketStatuses { get; set; } = null!;
        public virtual DbSet<TicketType> TicketTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Name=ConnectionString");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Checkout>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("CheckoutID");

                entity.HasOne(d => d.PerformanceId).WithMany(p => p.Checkouts)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("PerformanceID");

                entity.HasOne(d => d.TicketStatusID).WithMany(p => p.Checkouts)
                    .HasForeignKey(d => d.TicketStatusId)
                    .HasConstraintName("TicketStatusID");
            });

            modelBuilder.Entity<Hole>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("HoleID");

                entity.ToTable("Holes");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumberOfSeats)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Performance>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PerformanceID");

                entity.ToTable("Performances");
            });

            modelBuilder.Entity<Theatre>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("TheatreID");

                entity.ToTable("Theatres");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("TicketID");

                //entity.HasOne(d => d.PerformanceID).WithMany(p => p.Checkouts)
                //    .HasForeignKey(d => d.PerformanceID)
                //    .HasConstraintName("PerformanceID");

                //entity.HasOne(d => d.CheckoutNavigation).WithMany(p => p.Tickets)
                //    .HasForeignKey(d => d.CheckoutID)
                //    .HasConstraintName("CheckoutID");

                //entity.HasOne(d => d.TicketTypeNavigation).WithMany(p => p.Tickets)
                //    .HasForeignKey(d => d.TicketTypeID)
                //    .HasConstraintName("TicketTypeID");
            });

            modelBuilder.Entity<TicketStatus>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("TicketStatusID");

                entity.ToTable("TicketStatuses");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TicketType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("TicketTypeID");

                entity.Property(e => e.TicketTypeName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
