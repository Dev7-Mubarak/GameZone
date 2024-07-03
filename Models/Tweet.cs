using Microsoft.AspNetCore.Identity;

namespace GameZone.Models
{
    public class Tweet
    {
        public int Id { get; set; }
        //public string UserId { get; set; } = null!;
        public string TweetText { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        //public AppUser User { get; set; } = null!;
        //public int CommentId { get; set; }

        //public ICollection<Comment>? Comments = new List<Comment>();

    }
}
