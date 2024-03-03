using Microsoft.EntityFrameworkCore;

namespace Ticmano.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


        public DbSet<Ticket> ticket { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<Role> role { get; set; }
        public DbSet<Status> status { get; set; }
        public DbSet<Company> company { get; set; }
        public DbSet<Signing> signing { get; set; }
        public DbSet<Chat> chat { get; set; }
        public DbSet<Priority> priority { get; set; }
    }
}

