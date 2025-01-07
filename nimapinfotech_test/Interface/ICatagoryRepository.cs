using nimapinfotech_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nimapinfotech_test.Interface
{
    public interface ICatagoryRepository
    {
        IEnumerable<Catagory> GetAllCatagory();
        // Customer GetCustomerById(int? id);
        bool AddCatagory(Catagory catagory);
        bool UpdateCatagory(Catagory catagory);
        bool Deletecatagory(int? id);
    }
}