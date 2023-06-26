using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TimelineCache.Data;
using TimelineCache.DTOs;

namespace TimelineCache.Services
{
    public class TimelineValidationService : ITimelineValidationService
    {
        private readonly IUserRepository _userRepository;

        public TimelineValidationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void ValidateSubscription(ModelStateDictionary modelState, SubscriptionCreateDto dto)
        {
            var follower = _userRepository.GetUserById(dto.FollowerId);
            var following = _userRepository.GetUserById(dto.FollowingId);

            string errorMessage = "User with this ID doesn't exist";
            if (follower == null)
            {
                modelState.AddModelError(nameof(dto.FollowerId), errorMessage);
            }
            if (following == null)
            {
                modelState.AddModelError(nameof(dto.FollowingId), errorMessage);
            }
        }
    }
}
