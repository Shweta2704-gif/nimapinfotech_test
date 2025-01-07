using nimapinfotech_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nimapinfotech_test.Interface
{
    public interface IProductrepository
    {
         IEnumerable<Product> GetAllProduct();
       // Customer GetCustomerById(int? id);
        bool Addproduct(Product products);
        bool UpdateProduct(Product products);
        bool Deleteproduct(int? id);

    }
}