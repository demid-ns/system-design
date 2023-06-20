using AutoMapper;
using TimelineCache.DTOs;
using TimelineCache.Models;

namespace TimelineCache.Profiles
{
    public class TimelineProfile : Profile
    {
        public TimelineProfile()
        {
            //source -> target
            CreateMap<User, UserReadDto>();
            CreateMap<Subscription, SubscriptionReadDto>();
        }
    }
}
