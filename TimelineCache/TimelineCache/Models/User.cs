using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TimelineCache.Models
{
    public class User
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        public ICollection<Subscription> Followers { get; set; }
        public ICollection<Subscription> Following { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
