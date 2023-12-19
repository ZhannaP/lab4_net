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

        public virtual DbSet<Theatre> Theatres { get; set; }

        public virtual DbSet<Performance> Performances { get; set; }
        public virtual DbSet<TicketStatus> TicketStatuses { get; set; } = null!;

        public virtual DbSet<TicketType> TicketTypes { get; set; }

        public virtual DbSet<Ticket> Tickets { get; set; }

        //public virtual DbSet<UserAccount> UserAccounts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Name=ConnectionString");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Checkout>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_IdAllTickets");

                entity.HasOne(d => d.IdPerformanceNavigation).WithMany(p => p.AllTickets)
                    .HasForeignKey(d => d.IdPerformance)
                    .HasConstraintName("FK_AllTickets_Performance");

                entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.AllTickets)
                    .HasForeignKey(d => d.IdType)
                    .HasConstraintName("FK_AllTickets_TypeOfTickets");
            });

            modelBuilder.Entity<Hole>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_IdAuthor");

                entity.ToTable("Holes");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.NumberOfSeats)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_IdGenre");

                entity.ToTable("Genre");

                entity.Property(e => e.NameGenre)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Performance>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_IdPerformance");

                entity.ToTable("Performance");

                entity.Property(e => e.DateTimeEvent).HasColumnType("datetime");
                entity.Property(e => e.PerformanceName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.Performances)
                    .HasForeignKey(d => d.IdAuthor)
                    .HasConstraintName("FK_Performance_Author");

                entity.HasOne(d => d.IdGenreNavigation).WithMany(p => p.Performances)
                    .HasForeignKey(d => d.IdGenre)
                    .HasConstraintName("FK_Performance_Genre");
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_IdRefreshToken");

                entity.ToTable("RefreshToken");

                entity.Property(e => e.Expires).HasColumnType("datetime");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Token).IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_RefreshToken_UserAccount");
            });

            modelBuilder.Entity<RoleUser>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_IdRole");

                entity.ToTable("RoleUser");

                entity.Property(e => e.NameRole)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusTicket>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_IdStatus");

                entity.ToTable("StatusTicket");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_IdTicket");

                entity.ToTable("Ticket");

                entity.HasOne(d => d.IdAllTicketsNavigation).WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdAllTickets)
                    .HasConstraintName("FK_Ticket_AllTickets");

                entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_StatusTicket");

                entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_Ticket_UserAccount");
            });

            modelBuilder.Entity<TicketType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("TicketTypeID");

                entity.Property(e => e.TicketTypeName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

        //    modelBuilder.Entity<UserAccount>(entity =>
        //    {
        //        entity.HasKey(e => e.Id).HasName("PK_IdUser");

        //        entity.ToTable("UserAccount");

        //        entity.Property(e => e.Email)
        //            .HasMaxLength(20)
        //            .IsUnicode(false);
        //        entity.Property(e => e.FirstName)
        //            .HasMaxLength(20)
        //            .IsUnicode(false);
        //        entity.Property(e => e.LastName)
        //            .HasMaxLength(20)
        //            .IsUnicode(false);
        //        entity.Property(e => e.MiddleName)
        //            .HasMaxLength(20)
        //            .IsUnicode(false);

        //        entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.UserAccounts)
        //            .HasForeignKey(d => d.IdRole)
        //            .HasConstraintName("FK_UserAccount_RoleUser");
        //    });
        //    OnModelCreatingPartial(modelBuilder);
        //}

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
