using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "Pazi, prazno ti je!")]
        public string Title { get; set; }

        [Required]
        [MinLength(20, ErrorMessage = "Pazi kratko ti je!")]
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual User User { get; set; }
    }
}