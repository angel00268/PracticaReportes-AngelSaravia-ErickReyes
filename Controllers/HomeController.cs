using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using PracticaReportes_AngelSaravia_ErickReyes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaReportes_AngelSaravia_ErickReyes.Controllers
{
    public class HomeController : Controller
    {
    
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ReporteSimple ()
        {
            return View();
        }
    }
}