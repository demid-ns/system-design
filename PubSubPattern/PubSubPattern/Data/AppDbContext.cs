using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PubSubPattern.Models;

namespace PubSubPattern.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.Migrate();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>().ToTable("message");
            modelBuilder.Entity<Topic>().ToTable("topic");
            modelBuilder.Entity<Subscription>().ToTable("subscription");
        }
    }
}
