using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JensTheLandmand_v6.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public IEnumerable<Products> allProducts { get; set; }
        public IEnumerable<File> AllFiles { get; set; }
        //public IEnumerable<AllProducts> Products { get; set; }
    }

    public class ProductPlusImg
    {
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public decimal ProductPrice { get; set; }

        public byte[] ImgPath { get; set; }
    }

    public class ProductDetails
    {
        public Products Product { get; set; }
        public File ImgPath { get; set; }
    }
}