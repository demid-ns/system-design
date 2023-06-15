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
        [Column("subscriber_id")]
        public int SubscriberId { get; set; }
        [Required]
        public User Subscriber { get; set; }
        [Required]
        [Column("author_id")]
        public int AuthorId { get; set; }
        [Required]
        public User Author { get; set; }
    }
}
