using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace nimapinfotech_test.Models
{
    public class Catagory
    {
        [Required(ErrorMessage = "Catagoryid  is Required")]

        public int catagoryid { get; set; }
        [Required(ErrorMessage = "Catagory Name is Required")]
        public string catagoryname { get; set; }
        [Required(ErrorMessage = "Product id is Required")]
        public string productid { get; set; }


    }
}