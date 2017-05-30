using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TerjeSaetherWeb.Models;

namespace TerjeSaetherWeb.Models
{
    public class BlogPost
    {
        public Guid BlogPostId { get; set; }

        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public ApplicationUser User { get; set; }
        public virtual PostType PostType { get; set; }
    }
}