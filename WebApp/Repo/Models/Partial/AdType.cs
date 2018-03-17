using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repo.Models.Partial
{
    public class AdType
    {
        [Display(Name = "Id kategorii")]
        public int Id { get; set; }

        [Display(Name = "Nazwa kategorii")]
        public string Name { get; set; }

        public virtual ICollection<AdModel> AdModels { get; set; }
    }
}