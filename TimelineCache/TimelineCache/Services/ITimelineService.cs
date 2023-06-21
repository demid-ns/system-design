using TimelineCache.Models;

namespace TimelineCache.Services
{
    public interface ITimelineService
    {
        User GetUserWithMostFollowers();
        User GetUserWithMostFollowings();
    }
}
