using TimelineCache.Models;

namespace TimelineCache.Data
{
    public interface IUserRepository
    {
        User GetUserWithMostFollowers();
        User GetUserWithMostFollowings();
        User GetUserById(int id);
    }
}
