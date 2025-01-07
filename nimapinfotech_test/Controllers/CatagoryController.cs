using nimapinfotech_test.Models;
using nimapinfotech_test.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using PagedList;
using PagedList.Mvc;

namespace nimapinfotech_test.Controllers
{
    public class CatagoryController : Controller
    {
        private readonly catagoryrepository catrepo = new catagoryrepository();
        //public ActionResult GetAllCatagories()
        //{

        //    //catagoryrepository catagoryRepo = new catagoryrepository();
        //    ModelState.Clear();
        //    return View(catrepo.GetAllCatagory());
        //}
        public ActionResult GetAllCatagories(int pageNumber = 1, int pageSize = 10)
        {

            var allcatgaory = catrepo.GetAllCatagory();

            if (allcatgaory == null || !allcatgaory.Any())
            {

                allcatgaory = new List<Catagory>();
            }


            int totalRecords = allcatgaory.Count();
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);


            var paginatedProducts = allcatgaory
                                    .OrderBy(p => p.catagoryid)
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList();


            ViewBag.CurrentPage = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;


            return View(paginatedProducts);
        }

        public ActionResult AddCatagory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCatagory(Catagory catagory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   // catagoryrepository catrepo = new catagoryrepository();

                    if (catrepo.AddCatagory(catagory))
                    {
                        ViewBag.Message = "catagory details added successfully";
                    }
                }

                //return View();
                return RedirectToAction("GetAllCatagories");

            }
            catch
            {
                return View();
            }
        }
        //public ActionResult EditcatagoryDetails(int id)
        //{
        //   // catagoryrepository catRepo = new catagoryrepository();

        //    return View(catrepo.GetAllCatagory().Select(Emp => Emp.catagoryid == id));
        //}
        public ActionResult EditcatagoryDetails(int id)
        {

            var catagory = catrepo.GetAllCatagory().FirstOrDefault(c => c.catagoryid == id);

            if (catagory == null)
            {

                return HttpNotFound("Product not found.");
            }

            return View(catagory);
        }
        [HttpPost]
        public ActionResult EditcatagoryDetails(int id, Catagory obj)
        {
            try
            {
                //catagoryrepository catRepo = new catagoryrepository();

                catrepo.UpdateCatagory(obj);
                return RedirectToAction("GetAllCatagories");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Deletecatagory(int id)
        {
            try
            {
                //catagoryrepository catRepo = new catagoryrepository();
                if (catrepo.Deletecatagory(id))
                {
                    ViewBag.AlertMsg = "catagory details deleted successfully";
                }
                return RedirectToAction("GetAllCatagories");
            }
            catch
            {
                return View();
            }

        }


    }

}

