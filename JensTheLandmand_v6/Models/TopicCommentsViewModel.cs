using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace JensTheLandmand_v6.Models
{
    public class TopicCommentsViewModel
    {
        public TitleAndNote TitleAndNote { get; set; }
        public AllComments AllComments { get; set; }
        public int Id { get; set; }
    }

    public class TitleAndNote
    {
        public string TopicTitle { get; set; }
        public string TopicNote { get; set; }
    }

    public class AllComments
    {
        public IQueryable<Comments> CommentList { get; set; }
    }
}