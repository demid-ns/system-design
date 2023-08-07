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

        public IEnumerable<PostReadDto> GetUserTimeline(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            var posts = new List<PostReadDto>();

            foreach (var subscription in user.Followings)
            {
                var following = _userRepository.GetUserById(subscription.FollowingId);
                var followingPosts = _mapper.Map<IEnumerable<PostReadDto>>(following.Posts);
                posts.AddRange(followingPosts);
            }

            return posts;
        }

        public UserReadDto GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            var userDto = _mapper.Map<UserReadDto>(user);
            return userDto;
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

        public void Subscribe(SubscriptionCreateDto dto)
        {
            var subscription = _mapper.Map<Subscription>(dto);

            var follower = _userRepository.GetUserById(subscription.FollowerId);
            follower.Followings.Add(subscription);

            _userRepository.SaveChanges();
        }
    }
}
