using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JensTheLandmand_v6.Models
{
    public class Audit
    {
        public Guid AuditID { get; set; }
        public string IPAddress { get; set; }
        public string UserName { get; set; }
        public string URLAccessed { get; set; }
        public DateTime TimeAccessed { get; set; }
    }

    public class PostingModel
    {
        public string PropertyA { get; set; }
        public string PropertyB { get; set; }

        public PostingModel()
        {

        }
    }
}