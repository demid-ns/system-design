using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimelineCache.Models
{
    public class Subscription
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("follower_id")]
        public int FollowerId { get; set; }
        public User Follower { get; set; }
        [Required]
        [Column("following_id")]
        public int FollowingId { get; set; }
        public User Following { get; set; }
    }
}
