using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEG.Azure.Functions;
using Microsoft.Azure.WebJobs.Host;

namespace SEG.Azure.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //DeleteEmployeeFunction.Run(new System.Net.Http.HttpRequestMessage(), "", l);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Intermediate Level Assignment";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}