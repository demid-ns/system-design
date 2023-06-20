using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TimelineCache.Models;

namespace TimelineCache.DTOs
{
    public class SubscriptionReadDto
    {
        public int Id { get; set; }
        public int FollowerId { get; set; }
        public int FollowingId { get; set; }
    }
}
