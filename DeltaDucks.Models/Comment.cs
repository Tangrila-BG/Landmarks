namespace DeltaDucks.Models
{
    using System;

    public class Comment
    {
        public int CommentId { get; set; }

        public string Text { get; set; }

        public virtual Landmark Landmark { get; set; }

        public int? LandmarkId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public string AuthorId { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
