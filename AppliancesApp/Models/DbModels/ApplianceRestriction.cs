using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppliancesApp.Models.DbModels
{
    public class ApplianceRestriction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string Name { get; set; }
        
        public bool? IsHidden { get; set; }

    }
}