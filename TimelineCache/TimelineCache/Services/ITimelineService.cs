using TimelineCache.DTOs;
using TimelineCache.Models;

namespace TimelineCache.Services
{
    public interface ITimelineService
    {
        IEnumerable<PostReadDto> GetUserTimeline(int userId);
        UserReadDto GetUserById(int id);
        UserReadDto GetUserWithMostFollowers();
        UserReadDto GetUserWithMostFollowings();
        void Subscribe(SubscriptionCreateDto subscription);
    }
}
