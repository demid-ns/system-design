using System.ComponentModel.DataAnnotations.Schema;

namespace PubSubPattern.Models
{
    public class Topic
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
    }
}
