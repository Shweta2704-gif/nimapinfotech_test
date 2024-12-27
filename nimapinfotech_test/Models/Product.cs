using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace nimapinfotech_test.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Productid  is Required")]

        public int productid { get; set; }
        [Required(ErrorMessage = "Product Name is Required")]
        public string productname { get; set; }

       public int catagoryid { get; set; }
       public string catagoryname { get; set; }




    }
}