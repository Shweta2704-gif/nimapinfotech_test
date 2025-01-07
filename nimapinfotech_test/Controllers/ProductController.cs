using nimapinfotech_test.Models;
using nimapinfotech_test.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Collections.Generic;

namespace nimapinfotech_test.Controllers
{
    public class ProductController : Controller
    {
        private readonly productrepository prorepo = new productrepository();
        //public ActionResult GetAllproducts()
        //{


        //   // productrepository productRepo = new productrepository();

        //    ModelState.Clear();
        //    return View(prorepo.GetAllProduct());
        //}
        public ActionResult GetAllproducts(int pageNumber = 1, int pageSize = 10)
        {
          
            var allProducts = prorepo.GetAllProduct();

            if (allProducts == null || !allProducts.Any())
            {
             
                allProducts = new List<Product>();
            }

           
            int totalRecords = allProducts.Count();
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

        
            var paginatedProducts = allProducts
                                    .OrderBy(p => p.productid) 
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList();

          
            ViewBag.CurrentPage = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;

            
            return View(paginatedProducts);
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
                    //productrepository productRepo = new productrepository();
                    if (prorepo.Addproduct(products))
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
        //public ActionResult EditproductDetails(int id)
        //{
        //    //productrepository productRepo = new productrepository();

        //    return View(prorepo.GetAllProduct().Select(Emp => Emp.productid == id));
        //}
        public ActionResult EditproductDetails(int id)
        {
            
            var product = prorepo.GetAllProduct().FirstOrDefault(p => p.productid == id);

            if (product == null)
            {
                
                return HttpNotFound("Product not found.");
            }

            return View(product);
        }

        [HttpPost]
        public ActionResult EditproductDetails(int id, Product obj)
        {
            try
            {
                //productrepository productRepo = new productrepository();

                prorepo.UpdateProduct(obj);
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
                //productrepository productRepo = new productrepository();

                if (prorepo.Deleteproduct(id))
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

