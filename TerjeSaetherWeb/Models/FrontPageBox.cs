using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TerjeSaetherWeb.Models
{
    public class FrontPageBox
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual ICollection<Link> SoundcloudLinks { get; set; }
        public virtual ICollection<Link> BuyLinks { get; set; }
        public virtual Link WebsiteLink { get; set; }
    }
}