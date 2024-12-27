using nimapinfotech_test.Models;
using nimapinfotech_test.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nimapinfotech_test.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult GetAllproducts()
        {
            productrepository productRepo = new productrepository();
            ModelState.Clear();
            return View(productRepo.GetAllProduct());
        }
        public ActionResult Addproduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Addproduct(Product products)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productrepository productRepo = new productrepository();
                    if (productRepo.Addproduct(products))
                    {
                        ViewBag.Message = "product details added successfully";
                    }
                }

                //return View();
                return RedirectToAction("GetAllProducts"); 
            }
            catch
            {
                return View();
            }
        }
        public ActionResult EditproductDetails(int id)
        {
            productrepository productRepo = new productrepository();

            return View(productRepo.GetAllProduct().Find(Emp => Emp.productid == id));
        }
        [HttpPost]
        public ActionResult EditproductDetails(int id, Product obj)
        {
            try
            {
                productrepository productRepo = new productrepository();

                productRepo.UpdateProduct(obj);
                return RedirectToAction("GetAllProducts");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Deleteproduct(int id)
        {
            try
            {
                productrepository productRepo = new productrepository();

                if (productRepo.Deleteproduct(id))
                {
                    ViewBag.AlertMsg = "product details deleted successfully";
                }
                return RedirectToAction("GetAllProducts");
            }
            catch
            {
                return View();
            }
        }
    }

}

