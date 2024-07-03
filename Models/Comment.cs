namespace GameZone.Models
{
    public class Comment
    {
        public int Id { get; set; }
        //public int TweetId { get; set; }
        //public string UserId { get; set; } = null!;
        public string CommentText { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        //public AppUser User { get; set; } = null!;
        //public Tweet Tweet { get; set; } = null!;

    }
}
