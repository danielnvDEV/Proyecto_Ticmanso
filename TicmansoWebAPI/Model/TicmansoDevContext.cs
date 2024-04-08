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

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Priority> Priorities { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Signing> Signings { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

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

        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_chat");

            entity.ToTable("chat", tb => tb.HasComment("TRIAL"));

            entity.HasIndex(e => e.UserId, "fk_chat_user1_idx").HasFillFactor(99);

            entity.HasIndex(e => e.UserId1, "fk_chat_user2_idx").HasFillFactor(99);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Messages)
                .HasColumnType("text")
                .HasColumnName("messages");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserId1)
                .HasComment("TRIAL")
                .HasColumnName("user_id1");

            entity.HasOne(d => d.User).WithMany(p => p.ChatUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_chat_user1");

            entity.HasOne(d => d.UserId1Navigation).WithMany(p => p.ChatUserId1Navigations)
                .HasForeignKey(d => d.UserId1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_chat_user2");
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

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_role");

            entity.ToTable("role", tb => tb.HasComment("TRIAL"));

            entity.Property(e => e.Id)
                .HasComment("TRIAL")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasComment("TRIAL")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Signing>(entity =>
        {
            entity.HasKey(e => e.Date).HasName("pk_signing");

            entity.ToTable("signing", tb => tb.HasComment("TRIAL"));

            entity.HasIndex(e => e.UserId, "idx_user_id").HasFillFactor(99);

            entity.Property(e => e.Date)
                .HasComment("TRIAL")
                .HasColumnName("date");
            entity.Property(e => e.DepartureTime)
                .HasComment("TRIAL")
                .HasColumnName("departure_time");
            entity.Property(e => e.EntryTime)
                .HasComment("TRIAL")
                .HasColumnName("entry_time");
            entity.Property(e => e.UserId)
                .HasComment("TRIAL")
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Signings)
                .HasForeignKey(d => d.UserId)
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

            entity.HasIndex(e => e.SupportUserId, "IX_ticket_Support_user_id");

            entity.HasIndex(e => e.ChatId, "IX_ticket_chat_id");

            entity.HasIndex(e => e.CreationUserId, "IX_ticket_creation_user_id");

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
            entity.Property(e => e.CreationUserId).HasColumnName("creation_user_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.PriorityId).HasColumnName("priority_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.SupportUserId).HasColumnName("Support_user_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.Chat).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ChatId)
                .HasConstraintName("ticket_ibfk_1");

            entity.HasOne(d => d.CreationUser).WithMany(p => p.TicketCreationUsers)
                .HasForeignKey(d => d.CreationUserId)
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
                .HasForeignKey(d => d.SupportUserId)
                .HasConstraintName("fk_ticket_user2");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_user");

            entity.ToTable("user", tb => tb.HasComment("TRIAL"));

            entity.HasIndex(e => e.CompanyId, "fk_user_company1_idx").HasFillFactor(99);

            entity.HasIndex(e => e.RoleId, "fk_user_role1_idx").HasFillFactor(99);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.Email)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("mail");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Surnames)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surnames");

            entity.HasOne(d => d.Company).WithMany(p => p.Users)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_company1");

            //entity.HasOne(d => d.Role).WithMany(p => p.Users)
            //    .HasForeignKey(d => d.RoleId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("fk_user_role1");


        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
