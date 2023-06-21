using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TimelineCache.Models;

namespace TimelineCache.DTOs
{
    public class PostReadDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int AuthorId { get; set; }
    }
}
