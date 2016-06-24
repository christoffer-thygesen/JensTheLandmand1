using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security;

namespace JensTheLandmand_v6.Models
{
    public class Comments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentID { get; set; }

        [StringLength(128)]
        [ForeignKey("AspNetUser")]
        public virtual string C_AspNetUserId { get; set; }

        public virtual ApplicationUser AspNetUser { get; set; }

        [ForeignKey("TopicID")]
        public virtual int C_TopicId { get; set; }

        public virtual Topics TopicID { get; set; }

        public string Creator { get; set; }

        [Required]
        [Display(Name = "Kommentar")]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
    }
}