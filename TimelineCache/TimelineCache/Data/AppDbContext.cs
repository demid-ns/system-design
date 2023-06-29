using Microsoft.EntityFrameworkCore;
using TimelineCache.Models;

namespace TimelineCache.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("post");
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<Subscription>().ToTable("subscription");

            modelBuilder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.Author)
                .HasForeignKey(p => p.AuthorId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Followers)
                .WithOne(uf => uf.Following)
                .HasForeignKey(uf => uf.FollowingId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Followings)
                .WithOne(uf => uf.Follower)
                .HasForeignKey(uf => uf.FollowerId);
        }
    }
}
