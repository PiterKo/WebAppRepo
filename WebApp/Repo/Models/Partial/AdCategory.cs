using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Repo.Models.Partial
{
    public class AdCategory
    {
        public AdCategory()
        {
            this.AdModels = new HashSet<AdModel>();
        }

        [Display(Name = "Id kategorii")]
        public int Id { get; set; }

        [Display(Name = "Nazwa Kategorii")]
        public string Name { get; set; }

        [Display(Name = "Zaznaczone?")]
        public bool IsSelected { get; set; } = false;

        // Seting configuration many-to-many with Ad
        public virtual ICollection<AdModel> AdModels {get;set;}
    }
}