using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class AdModel
    {
        [Display(Name = "Status")]
        public bool Active { get; set; }

        [Display(Name = "Path")]
        public string ImagePath { get; set; }

        [Display(Name = "Obszar")]
        public string Area { get; set; }

        [Display(Name = "Krótki opis")]
        [MaxLength(256)]
        public string ShortDescription { get; set; }

        [Display(Name = "Umiejętności")]
        public string Skills { get; set; }

        [Display(Name = "Linki")]
        public string Social { get; set; }
    }
}