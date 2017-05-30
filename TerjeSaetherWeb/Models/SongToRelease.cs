using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TerjeSaetherWeb.Models
{
    public class SongToRelease
    {
        public int SongToReleaseId { get; set; }
        public int SongId { get; set; }
        public int ReleaseId { get; set; }
        public virtual Song Song { get; set; }
        public virtual Release Release { get; set; }
    }
}