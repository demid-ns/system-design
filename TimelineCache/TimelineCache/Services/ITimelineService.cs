using TimelineCache.DTOs;
using TimelineCache.Models;

namespace TimelineCache.Services
{
    public interface ITimelineService
    {
        UserReadDto GetUserWithMostFollowers();
        UserReadDto GetUserWithMostFollowings();
        void Subscribe(SubscriptionCreateDto subscription);
    }
}
