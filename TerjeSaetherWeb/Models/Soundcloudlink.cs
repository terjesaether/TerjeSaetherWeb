using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TerjeSaetherWeb.Models
{
    public class Soundcloudlink
    {
        public Guid Id { get; set; }

        [Display(Name ="Soundcloud link")]
        public string Url { get; set; }

        [Display(Name = "Show it!")]
        public bool Show { get; set; }
    }
}