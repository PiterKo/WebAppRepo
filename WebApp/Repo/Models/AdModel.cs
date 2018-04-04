using Repo.Models.Partial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repo.Models
{
    public class AdModel
    {
        public AdModel()
        {
            this.AdCategories = new HashSet<AdCategory>();
        }

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Status")]
        public bool Active { get; set; } = true; // Default set is true.

        [Display(Name = "Dodaj zdjęcie")]
        public string Image { get; set; }

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

        [Display(Name = "Data dodania")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? AddingDate { get; set; } = DateTime.Now; // Default set is current date.

        // Seting relation one-to-one with Type
        public virtual AdType AdType { get; set; }
        //Store Ad Types for drop down in view
        public virtual IEnumerable<AdType> Types { get; set; }

        // Seting relation many-to-many with Categories
        [Display(Name = "Kategoria ogłoszenia")]
        public virtual ICollection<AdCategory> AdCategories { get; set; }
        // Store selected values
        public virtual ICollection<int> SelectedCategories { get; set; }

        // Set relation one-to-zero-or-one
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}