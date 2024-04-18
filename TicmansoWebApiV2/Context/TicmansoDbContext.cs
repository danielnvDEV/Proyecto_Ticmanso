﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace TicmansoWebApiV2.Context
{
    public partial class TicmansoDbContext : IdentityDbContext<ApplicationUser>
    {
        public TicmansoDbContext() 
        { 
        }
        public TicmansoDbContext(DbContextOptions<TicmansoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<ChatMessage> ChatMessages { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Company)
                .WithMany(c => c.Users)
                .HasForeignKey(c => c.Companyid);

            builder.Entity<Company>(entity =>
            {
                entity.ToTable("Companies");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.Country)
                    .HasColumnName("Country")
                    .HasMaxLength(100);

                entity.Property(e => e.Address)
                    .HasColumnName("Address")
                    .HasMaxLength(200);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("PostalCode")
                    .HasMaxLength(20);

                entity.Property(e => e.City)
                    .HasColumnName("City")
                    .HasMaxLength(100);

                entity.Property(e => e.Cif)
                    .HasColumnName("Cif")
                    .HasMaxLength(50);
            });

            builder.Entity<Priority>(entity =>
            {
                entity.ToTable("Priorities");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            });

            builder.Entity<Status>(entity =>
            {
                entity.ToTable("Statuses");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            });

            builder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Tickets");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.CreationDate).IsRequired();

                entity.HasOne(e => e.Priority)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(e => e.PriorityId)
                    .IsRequired();

                entity.HasOne(e => e.Status)
                    .WithMany(s => s.Tickets)
                    .HasForeignKey(e => e.StatusId)
                    .IsRequired();

                entity.HasOne(e => e.CreationUser)
                    .WithMany(u => u.CreatedTickets)
                    .HasForeignKey(e => e.CreationUserId)
                    .IsRequired();

                entity.HasOne(e => e.SupportUser)
                    .WithMany(u => u.SupportedTickets)
                    .HasForeignKey(e => e.SupportUserId)
                    .IsRequired(false);
            });

            builder.Entity<Attendance>(entity =>
            {
                entity.ToTable("Attendances");

                entity.HasKey(e => new { e.Date, e.UserId });

                entity.Property(e => e.Date).HasColumnType("date");
                entity.Property(e => e.EntryTime).IsRequired();
                entity.Property(e => e.DepartureTime).IsRequired(false);

                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .IsRequired();

                entity.HasIndex(e => new { e.Date, e.UserId }).IsUnique();
            });

            builder.Entity<ChatMessage>(entity =>
            {
                entity.ToTable("ChatMessages");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Content).IsRequired();
                entity.Property(e => e.Timestamp).IsRequired();

                entity.HasOne(e => e.Sender)
                    .WithMany()
                    .HasForeignKey(e => e.SenderId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Receiver)
                    .WithMany()
                    .HasForeignKey(e => e.ReceiverId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasIndex(e => new { e.SenderId, e.ReceiverId })
                .IsUnique();
            });

            OnModelCreatingPartial(builder);
        }
    }

}
