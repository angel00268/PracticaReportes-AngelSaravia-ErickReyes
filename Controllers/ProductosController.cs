using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using PracticaReportes_AngelSaravia_ErickReyes.Models;

namespace PracticaReportes_AngelSaravia_ErickReyes.Controllers
{
    public class ProductosController : Controller
    {
        neptunoEntities contexto = new neptunoEntities();
        // GET: Productos
        public ActionResult Index()
        {
            return View();
        }

        /*Reporte Numero 1*/
        public ActionResult VerReporte(string parametro)
        {
            var reporte = new ReportClass();
            reporte.FileName = Server.MapPath("/Rpts/ProductosReport.rpt");

            //ESTABLECIENDO UN PARAMETRO AL REPORTE
            reporte.SetParameterValue("paramCategorias", parametro);

            //Conexion para el reporte
            var coninfo = ReporteConexion.getConexion();
            TableLogOnInfo logoninfo = new TableLogOnInfo();
            Tables tables;
            tables = reporte.Database.Tables;
            foreach (Table item in tables)
            {
                logoninfo = item.LogOnInfo;
                logoninfo.ConnectionInfo = coninfo;
                item.ApplyLogOnInfo(logoninfo);
            }
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = reporte.ExportToStream(ExportFormatType.PortableDocFormat);

            return new FileStreamResult(stream, "application/pdf");
        }

        //Llenar Combo 
        public JsonResult GetCategorias()
        {
            var cats = contexto.categorias.Select(x => x.nombrecategoria).ToList();

            return Json(new { resultado = cats }, JsonRequestBehavior.AllowGet);
        }
        /*End Reporte Numero 1*/
    }
}