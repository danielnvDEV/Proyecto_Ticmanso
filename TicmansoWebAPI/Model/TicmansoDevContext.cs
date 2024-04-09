using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TicmansoWebAPI.Model;

public partial class TicmansoDevContext : DbContext
{
    public TicmansoDevContext()
    {
    }

    public TicmansoDevContext(DbContextOptions<TicmansoDevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<Message> Menssages { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Priority> Priorities { get; set; }


    public virtual DbSet<Signing> Signings { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.Name).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_company");

            entity.ToTable("company", tb => tb.HasComment("TRIAL"));

            entity.Property(e => e.Id)
                .HasComment("TRIAL")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("TRIAL")
                .HasColumnName("address");
            entity.Property(e => e.Cif)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasComment("TRIAL")
                .HasColumnName("cif");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("TRIAL")
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("TRIAL")
                .HasColumnName("country");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("TRIAL")
                .HasColumnName("name");
            entity.Property(e => e.PostalCode)
                .HasComment("TRIAL")
                .HasColumnName("postalCode");
        });

        modelBuilder.Entity<Priority>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_priority");

            entity.ToTable("priority", tb => tb.HasComment("TRIAL"));

            entity.Property(e => e.Id)
                .HasComment("TRIAL")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Signing>(entity =>
        {
            entity.HasKey(e => e.Date).HasName("pk_signing");       

            entity.HasIndex(e => e.UserId, "idx_user_id").HasFillFactor(99);

            entity.Property(e => e.Date)
                .HasColumnName("date");
            entity.Property(e => e.DepartureTime)
                .HasColumnName("departure_time");
            entity.Property(e => e.EntryTime)
                .HasColumnName("entry_time");
            entity.Property(e => e.UserId)
                .HasColumnName("user_id");

            entity.HasOne(d => d.User)
                   .WithMany(p => p.Signings)
                   .HasForeignKey(d => d.AspNetUserId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("signing_ibfk_1");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_status");

            entity.ToTable("status", tb => tb.HasComment("TRIAL"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_ticket");

            entity.ToTable("ticket", tb => tb.HasComment("TRIAL"));

            entity.HasIndex(e => e.AspNetUserSupportId, "IX_ticket_Support_user_id");

            entity.HasIndex(e => e.ChatId, "IX_ticket_chat_id");

            entity.HasIndex(e => e.AspNetUserCreationId, "IX_ticket_creation_user_id");

            entity.HasIndex(e => e.PriorityId, "IX_ticket_priority_id");

            entity.HasIndex(e => e.StatusId, "IX_ticket_status_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChangedDate)
                .HasColumnType("datetime")
                .HasColumnName("changed_date");
            entity.Property(e => e.ChatId).HasColumnName("chat_id");
            entity.Property(e => e.CloseDate)
                .HasColumnType("datetime")
                .HasColumnName("close_date");
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("creation_date");
            entity.Property(e => e.AspNetUserCreationId).HasColumnName("creation_user_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.PriorityId).HasColumnName("priority_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.AspNetUserSupportId).HasColumnName("Support_user_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(e => e.Chat)
                   .WithMany(c => c.Tickets)
                   .HasForeignKey(e => e.ChatId)
                   .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(d => d.CreationUser)
                 .WithMany(p => p.TicketCreationUsers)
                 .HasForeignKey(d => d.AspNetUserCreationId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("fk_ticket_user1");

            entity.HasOne(d => d.Priority).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.PriorityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ticket_priority1");

            entity.HasOne(d => d.Status).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ticket_status1");

            entity.HasOne(d => d.SupportUser).WithMany(p => p.TicketSupportUsers)
                .HasForeignKey(d => d.AspNetUserSupportId)
                .HasConstraintName("fk_ticket_user2");
        });

        modelBuilder.Entity<User>().HasBaseType<AspNetUser>();

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.CompanyId, "fk_user_company1_idx").HasFillFactor(99);

            entity.HasIndex(e => e.RoleId, "fk_user_role1_idx").HasFillFactor(99);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.Surnames)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surnames");

            entity.HasOne(d => d.Company).WithMany(p => p.Users)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_company1");
        });

        modelBuilder.Entity<Chat>(entity =>
        {
            entity.ToTable("chat");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.User1Id)
                .HasColumnName("user1_id")
                .IsRequired();

            entity.Property(e => e.User2Id)
                .HasColumnName("user2_id")
                .IsRequired();

            entity.Property(e => e.TicketId)
                .HasColumnName("ticket_id");

            entity.HasOne(e => e.User1)
                .WithMany()
                .HasForeignKey(e => e.User1Id)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.User2)
                .WithMany()
                .HasForeignKey(e => e.User2Id)
                .OnDelete(DeleteBehavior.Restrict);


            //entity.HasOne(e => e.Tickets)
            //    .WithMany()
            //    .HasForeignKey(e => e.TicketId)
            //    .OnDelete(DeleteBehavior.SetNull);

            entity.HasIndex(e => new { e.User1Id, e.User2Id })
                .IsUnique();
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.ToTable("messages");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.ChatId).HasColumnName("chat_id");

            entity.Property(e => e.SenderId).HasColumnName("sender_id");

            entity.Property(e => e.Content)
                .HasColumnName("content")
                .IsRequired();

            entity.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("GETDATE()");

            entity.HasOne(e => e.Chat)
                .WithMany(c => c.Messages)
                .HasForeignKey(e => e.ChatId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Sender)
                .WithMany()
                .HasForeignKey(e => e.SenderId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
