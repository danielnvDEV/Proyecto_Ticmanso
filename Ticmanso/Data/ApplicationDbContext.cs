using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Infrastructure;

namespace Ticmanso.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Signin> Signins { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Se definen las relaciones entre las entidades

            modelBuilder.Entity<User>()
                .HasOne(u => u.Company)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CompanyId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<Signin>()
                .HasOne(s => s.User)
                .WithMany(u => u.Signins)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Chat)
                .WithOne(c => c.Ticket)
                .HasForeignKey<Ticket>(t => t.ChatId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.CreationUser)
                .WithMany(u => u.CreatedTickets)
                .HasForeignKey(t => t.CreationUserId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.SupportUser)
                .WithMany(u => u.AssignedTickets)
                .HasForeignKey(t => t.SupportUserId);

            modelBuilder.Entity<Ticket>()
               .HasOne(t => t.Priority)
               .WithMany(p => p.Tickets)
               .HasForeignKey(t => t.PriorityId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Status)
                .WithMany(s => s.Tickets)
                .HasForeignKey(t => t.StatusId);

            modelBuilder.Entity<Chat>()
                .HasOne(c => c.CreationUser)
                .WithMany(u => u.CreatedChats)
                .HasForeignKey(c => c.CreationUserId);

            modelBuilder.Entity<Chat>()
                .HasOne(c => c.SupportUser)
                .WithMany(u => u.AssignedChats)
                .HasForeignKey(c => c.SupportUserId);




        }
    }
}

