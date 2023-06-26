using Microsoft.AspNetCore.Mvc.ModelBinding;
using TimelineCache.DTOs;

namespace TimelineCache.Services
{
    public interface ITimelineValidationService
    {
        void ValidateSubscription(ModelStateDictionary modelState, SubscriptionCreateDto dto);
    }
}
