using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppliancesApp.Models.DbModels
{
    public class Appliance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string Name { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public bool IsInStock { get; set; }

        [MaxLength(200)]
        public string Attachment { get; set; }
    }
}