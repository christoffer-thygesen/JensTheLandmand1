using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JensTheLandmand_v6.Models
{
    public class Links
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LinksID { get; set; }

        [Required]
        [Display(Name ="Link URL")]
        public string LinkURL { get; set; }
        
        [Required]
        [Display(Name = "Beskrivelse")]
        public string LinkDesc { get; set; }

        public string TrimLink
        {
            get
            {

                return this.LinkURL.Substring(7);                
            }
        }
    }
}