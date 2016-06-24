using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JensTheLandmand_v6.Models
{
    public class PostViewModel
    {
    }

    public class CreateTopicViewModel
    {
        
    }

    public class ListTopicWithNamesViewModel
    {
        public IQueryable<Topics> topics { get; set; }
        public IQueryable<ApplicationUser> users { get; set; }
        public string email { get; set; }
    }

    public class CreateCommentReplyViewModel
    {
        public Topics topic { get; set; }
        public ApplicationUser user { get; set; }
        public string content { get; set; }
    }

    public class ViewTopicAndCommentsViewModel
    {
        public Topics topic { get; set; }
        public IQueryable<Comments> comments { get; set; }
        public ApplicationUser user { get; set; }
    }
}