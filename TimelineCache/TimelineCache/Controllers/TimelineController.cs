using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimelineCache.DTOs;
using TimelineCache.Services;

namespace TimelineCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimelineController : ControllerBase
    {
        private readonly ITimelineService _timelineService;
        private readonly IMapper _mapper;

        public TimelineController(
            ITimelineService timelineService,
            IMapper mapper
            )
        {
            _timelineService = timelineService;
            _mapper = mapper;
        }

        [HttpGet("user-most-followers")]
        public ActionResult<UserReadDto> GetUserWithMostFollowers()
        {
            var user = _timelineService.GetUserWithMostFollowers();
            var userDto = _mapper.Map<UserReadDto>(user);

            return userDto;
        }
    }
}
