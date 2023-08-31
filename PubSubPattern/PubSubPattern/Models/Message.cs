using System.ComponentModel.DataAnnotations.Schema;

namespace PubSubPattern.Models
{
    public class Message
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("topic_message")]
        public string TopicMessage { get; set; }
        [Column("subscription_id")]
        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
        [Column("expires_after")]
        public DateTime ExpiresAfter { get; set; } = DateTime.UtcNow.AddDays(1);
        [Column("message_status")]
        public string MessageStatus { get; set; } = "NEW";
    }
}
