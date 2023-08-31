using System.ComponentModel.DataAnnotations.Schema;

namespace PubSubPattern.Models
{
    public class Subscription
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("topic_id")]
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
