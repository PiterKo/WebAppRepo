using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class AdModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Status")]
        public bool Active { get; set; } = true; // Default set is true.

        [Required]
        [Display(Name = "Typ ogłoszenia")]
        public string Type { get; set; }

        [Display(Name = "Path")]
        public string ImagePath { get; set; }

        [Required]
        [Display(Name = "Obszar")]
        public string Area { get; set; }

        [Required]
        [Display(Name = "Krótki opis")]
        [MaxLength(256)]
        public string ShortDescription { get; set; }

        [Required]
        [Display(Name = "Umiejętności")]
        public string Skills { get; set; }

        [Display(Name = "Linki")]
        public string Links { get; set; }

        [Display(Name = "Data dodania")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AddingDate { get; set; } = DateTime.Now; // Default set is current date.

        // Set relation one-to-zero-or-one
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}