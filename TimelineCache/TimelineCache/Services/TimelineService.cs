using AutoMapper;
using TimelineCache.Data;
using TimelineCache.DTOs;
using TimelineCache.Models;

namespace TimelineCache.Services
{
    public class TimelineService : ITimelineService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public TimelineService(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserReadDto GetUserWithMostFollowers()
        {
            var user = _userRepository.GetUserWithMostFollowers();
            var userDto = _mapper.Map<UserReadDto>(user);
            return userDto;
        }

        public UserReadDto GetUserWithMostFollowings()
        {
            var user = _userRepository.GetUserWithMostFollowings();
            var userDto = _mapper.Map<UserReadDto>(user);
            return userDto;
        }

        public void Subscribe(SubscriptionCreateDto subscription)
        {
            throw new NotImplementedException();
        }
    }
}
