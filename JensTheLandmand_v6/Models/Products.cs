using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JensTheLandmand_v6.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [Required]
        [MaxLength(60)]
        [Display(Name = "Navn")]
        public string ProductName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Beskrivelse")]
        public string ProductDesc { get; set; }

        [Required]
        [Display(Name = "Pris")]
        public decimal ProductPrice { get; set; }      
        
        public virtual ICollection<File> Files { get; set; } 
    }
}