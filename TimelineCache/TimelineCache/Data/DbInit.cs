using Microsoft.EntityFrameworkCore;
using TimelineCache.Models;

namespace TimelineCache.Data
{
    public static class DbInit
    {
        const int BatchSize = 1000;
        const int TotalUsers = 100000;
        const int TotalPosts = 100000;
        const int MaxSubscriptions = 100000;

        private static readonly ILogger _logger;

        static DbInit()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            _logger = loggerFactory.CreateLogger(typeof(DbInit));
        }

        public static void Initialize(WebApplication app)
        {
            using var serviceScope = app.Services.CreateScope();
            var dbContext = serviceScope.ServiceProvider
                .GetRequiredService<AppDbContext>();
            SeedData(dbContext);
        }

        private static void SeedData(AppDbContext context)
        {
            try
            {
                _logger.LogInformation("--> Applying migrations");
                context.Database.Migrate();

                SeedUsers(context);
                SeedPosts(context);
                SeedSubscriptions(context);

                context.SaveChanges();

                _logger.LogInformation("--> Data seeding completed");
            }
            catch (Exception ex)
            {
                _logger.LogError($"--> Migrations failed: {ex.Message}");
            }
        }

        private static void SeedUsers(AppDbContext context)
        {
            if (context.Users.Any())
                return;

            var users = new List<User>();

            for (int i = 1; i <= TotalUsers; i++)
            {
                var user = new User { Name = $"User {i}" };
                users.Add(user);

                if (i % BatchSize == 0 || i == TotalUsers)
                {
                    context.Users.AddRange(users);
                    context.SaveChanges();
                    users.Clear();
                }
            }
        }

        private static void SeedPosts(AppDbContext context)
        {
            if (context.Posts.Any())
                return;

            var userIds = context.Users.Select(u => u.Id).ToList();
            var posts = new List<Post>();

            var random = new Random();

            for (int i = 1; i <= TotalPosts; i++)
            {
                int authorId = userIds[random.Next(userIds.Count)]; // Randomly select a user ID as the author
                var post = new Post { Text = $"Post {i}", AuthorId = authorId };
                posts.Add(post);

                if (i % BatchSize == 0 || i == TotalPosts)
                {
                    context.Posts.AddRange(posts);
                    context.SaveChanges();
                    posts.Clear();
                }
            }
        }

        private static void SeedSubscriptions(AppDbContext context)
        {
            if (context.Subscriptions.Any())
                return;

            var userIds = context.Users.Select(u => u.Id).ToList();
            var subscriptions = new List<Subscription>();

            var random = new Random();

            for (int i = 1; i <= MaxSubscriptions; i++)
            {
                int subscriberId = userIds[random.Next(userIds.Count)]; // Randomly select a subscriber
                int authorId = userIds[random.Next(userIds.Count)]; // Randomly select an author

                if (subscriberId != authorId) // Ensure the subscriber is not the same as the author
                {
                    var subscription = new Subscription
                    {
                        SubscriberId = subscriberId,
                        AuthorId = subscriberId
                    };
                    subscriptions.Add(subscription);
                }

                if (i % BatchSize == 0 || i == MaxSubscriptions)
                {
                    context.Subscriptions.AddRange(subscriptions);
                    context.SaveChanges();
                    subscriptions.Clear();
                }
            }
        }
    }
}
