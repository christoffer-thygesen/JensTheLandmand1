using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JensTheLandmand_v6.Models
{
    public class AuditViewModel
    {
    }

    public class ChartViewModel
    {
        public int id { get; set; }
        public IEnumerable<Audit> ForumList { get; set; }
        public IEnumerable<Audit> LinksList { get; set; }
        public IEnumerable<Audit> ShopList { get; set; }
    }

    public class ChartProductDetailsViewModel
    {
        public int id { get; set; }
        public IEnumerable<Audit> DetailsList { get; set; }
        public IEnumerable<ChartProducts> ChartSortedList { get; set; }
    }

    public class ChartProducts
    {
        public int id { get; set; }
        public int counts { get; set; }
        public string name { get; set; }
    }

    public class UnikVisitsViewModel
    {
        public int id { get; set; }
        public IEnumerable<string> IPList { get; set; }
    }
}