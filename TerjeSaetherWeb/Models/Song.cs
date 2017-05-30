using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TerjeSaetherWeb.Models
{
    public class Song
    {
        public Guid SongId { get; set; }

        [Required]
        public string Title { get; set; }
        public string Comment { get; set; }     
        public DateTime Timestamp { get; set; }
        public bool ShowOnFrontpage { get; set; }
        public string AudioUrl { get; set; }
        public virtual Image Image { get; set; }
        public virtual ICollection<SongToRelease> SongToReleases { get; set; }
        public virtual ICollection<Link> BuyLinks { get; set; }
    }
}