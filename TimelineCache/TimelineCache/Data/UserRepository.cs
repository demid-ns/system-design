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

        public User GetUserById(int id)
        {
            return _context.Users
                .Include(user => user.Followers)
                .Include(user => user.Following)
                .Include(user => user.Posts)
                .SingleOrDefault(u => u.Id == id);
        }
        public User GetUserWithMostFollowers()
        {
            return _context.Users
                .OrderByDescending(user => user.Followers.Count)
                .Include(user => user.Followers)
                .Include(user => user.Following)
                .Include(user => user.Posts)
                .FirstOrDefault();
        }

        public User GetUserWithMostFollowings()
        {
            return _context.Users
                .OrderByDescending(user => user.Following.Count)
                .Include(user => user.Following)
                .Include(user => user.Followers)
                .Include(user => user.Posts)
                .FirstOrDefault();
        }
    }
}
