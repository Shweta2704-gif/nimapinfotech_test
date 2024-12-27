using nimapinfotech_test.Models;
using nimapinfotech_test.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nimapinfotech_test.Controllers
{
    public class CatagoryController : Controller
    {
        public ActionResult GetAllCatagories()
        {
            catagoryrepository catagoryRepo = new catagoryrepository();
            ModelState.Clear();
            return View(catagoryRepo.GetAllCatagory());
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
                    catagoryrepository catrepo = new catagoryrepository();

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
        public ActionResult EditcatagoryDetails(int id)
        {
            catagoryrepository catRepo = new catagoryrepository();

            return View(catRepo.GetAllCatagory().Find(Emp => Emp.catagoryid == id));
        }
        [HttpPost]
        public ActionResult EditcatagoryDetails(int id, Catagory obj)
        {
            try
            {
                catagoryrepository catRepo = new catagoryrepository();

                catRepo.UpdateCatagory(obj);
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
                catagoryrepository catRepo = new catagoryrepository();
                if (catRepo.Deletecatagory(id))
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

