using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimelineCache.Models
{
    public class Post
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("text")]
        public string Text { get; set; }
        [Required]
        [Column("author_id")]
        public int AuthorId { get; set; }
        public User Author { get; set; }
    }
}
