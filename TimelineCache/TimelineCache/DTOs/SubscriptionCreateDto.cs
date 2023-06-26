using System.ComponentModel.DataAnnotations;

namespace TimelineCache.DTOs
{
    public class SubscriptionCreateDto
    {
        [Required]
        public int FollowerId { get; set; }
        [Required]
        public int FollowingId { get; set; }
    }
}
