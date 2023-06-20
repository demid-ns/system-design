using TimelineCache.Data;
using TimelineCache.Models;

namespace TimelineCache.Services
{
    public class TimelineService : ITimelineService
    {
        private readonly IUserRepository _userRepository;

        public TimelineService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserWithMostFollowers()
        {
            return _userRepository.GetUserWithMostFollowers();
        }
    }
}
