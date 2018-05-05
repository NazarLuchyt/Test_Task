using System;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Mvc;
using Test_WEB_Api.Repositories;
using Test_WEB_Api.Helpers;

namespace Test_WEB_Api.Controllers
{
    public class HomeController : Controller
    {
       
        SentenceRepository db;
        public HomeController()
        {
            db = new SentenceRepository();
        }

        public ActionResult Index()
        {
            
            ViewBag._Sentences = db.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult FindAndAdd(HttpPostedFileBase file,string SearchWord)
        {
            if (file != null)
            {
               db.Create(ParseString_Helper.Parse(file, SearchWord));
            }
            return RedirectToAction("Index");
        }
        

    }
}