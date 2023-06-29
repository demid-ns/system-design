using TimelineCache.Models;

namespace TimelineCache.Data
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        User GetUserWithMostFollowers();
        User GetUserWithMostFollowings();
        int SaveChanges();
    }
}
