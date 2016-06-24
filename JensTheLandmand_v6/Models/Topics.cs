using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JensTheLandmand_v6.Models
{
    public class Topics
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TopicID { get; set; }

        [StringLength(128), MinLength(3)]
        [ForeignKey("AppUser")]
        public virtual string T_AspNetUserId { get; set; }

        public virtual ApplicationUser AppUser { get; set; }

        [Required]
        [MaxLength(128)]
        [Display(Name = "Overskrift")]
        public string TopicTitle { get; set; }

        [Required]
        [Display(Name = "Tekst")]
        [DataType(DataType.MultilineText)]
        public string TopicNote { get; set; }

        public string Creator { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }

        //truncater string hvis den er for lang
        public string TrimNote
        {
            get
            {
                if (this.TopicNote.Length > 20)
                {
                    return this.TopicNote.Substring(0, 20) + "...";
                }
                else
                {
                    return this.TopicNote;
                }
            }
        }
    }
}