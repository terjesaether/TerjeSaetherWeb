using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TerjeSaetherWeb.Models
{
    public class Release
    {
        public Guid ReleaseId { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public bool ShowOnFrontpage { get; set; }
        public DateTime Releasedate { get; set; }
        public byte[] CoverImage { get; set; }
        public ICollection<Song> Songs { get; set; }
        public virtual ICollection<SongToRelease> SongToReleases { get; set; }
    }
}