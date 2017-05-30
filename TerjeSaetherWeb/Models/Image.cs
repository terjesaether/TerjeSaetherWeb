using System;

namespace TerjeSaetherWeb.Models
{
    public class Image
    {
        public Guid ImageId { get; set; }
        public string ImageUrl { get; set; }
        public string Filename { get; set; }
        public DateTime Timestamp { get; set; }
        public byte[] Data { get; set; }
        //public virtual Song Song { get; set; }
    }
}