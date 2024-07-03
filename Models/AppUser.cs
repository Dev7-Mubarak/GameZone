using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Models
{
    public class AppUser : IdentityUser
    {
        [MaxLength(100)]
        public string? FirstName { get; set; } = null!;
        [MaxLength(100)]
        public string? LastName { get; set; } = null!;

        //public byte[]? ProilePicture { get; set; } = null!;
        //public int? TweetId { get; set; }
        //public int? CommentId { get; set; }
        public virtual Rest Rest { get; set; } = default!;

        //public ICollection<Tweet>? Tweets = new List<Tweet>();
        //public ICollection<Comment>? Comments = new List<Comment>();
        [NotMapped]
        public string FullName { get => FirstName + " " + LastName;}
    }
}
