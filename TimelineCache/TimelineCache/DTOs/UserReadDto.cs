using TimelineCache.Models;

namespace TimelineCache.DTOs
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SubscriptionReadDto> Followers { get; set; }
        public ICollection<SubscriptionReadDto> Following { get; set; }
        public ICollection<PostReadDto> Posts { get; set; }
    }
}
