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
        private readonly ITimelineValidationService _timelineValidationService;

        public TimelineController(
            ITimelineService timelineService,
            ITimelineValidationService timelineValidationService
            )
        {
            _timelineService = timelineService;
            _timelineValidationService = timelineValidationService;
        }

        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<PostReadDto>> GetUserTimeline(int userId)
        {
            return Ok(_timelineService.GetUserTimeline(userId));
        }

        [HttpGet("user/{id}")]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            return _timelineService.GetUserById(id);
        }

        [HttpGet("user-most-followers")]
        public ActionResult<UserReadDto> GetUserWithMostFollowers()
        {
            return _timelineService.GetUserWithMostFollowers(); ;
        }

        [HttpGet("user-most-followings")]
        public ActionResult<UserReadDto> GetUserWithMostFollowings()
        {
            return _timelineService.GetUserWithMostFollowings();
        }

        [HttpPost("subscribe")]
        public ActionResult<UserReadDto> Subscribe(
            [FromBody] SubscriptionCreateDto dto
            )
        {
            _timelineValidationService.ValidateSubscription(ModelState, dto);
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _timelineService.Subscribe(dto);

            return NoContent();
        }
    }
}
