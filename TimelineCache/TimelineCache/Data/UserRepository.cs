using Microsoft.EntityFrameworkCore;
using TimelineCache.Models;

namespace TimelineCache.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User GetUserWithMostFollowers()
        {
            return _context.Users
                .OrderByDescending(user => user.Followers.Count)
                .Include(user => user.Followers)
                .FirstOrDefault();
        }
    }
}
