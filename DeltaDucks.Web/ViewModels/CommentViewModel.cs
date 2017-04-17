using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeltaDucks.Web.ViewModels
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }

        [Required, StringLength(300, ErrorMessage = "Comment must be at least {2} symbols.", MinimumLength = 5)]
        public string Text { get; set; }

        public byte LandmarkNumber { get; set; }

        public int LandmarkId { get; set; }

        public string AuthorId { get; set; }

        public DateTime DateCreated { get; set; }
    }
}