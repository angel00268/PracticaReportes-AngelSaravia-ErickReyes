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
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        public ActionResult Index()
        {
            return View();
        }

        /*Reporte Numero 5*/
        public ActionResult VerReporte(string parametro)
        {
            var reporte = new ReportClass();
            reporte.FileName = Server.MapPath("/Rpts/EmpleadosReport.rpt");

            //ESTABLECIENDO UN PARAMETRO AL REPORTE
            reporte.SetParameterValue("paramFecha", DateTime.Parse(parametro));

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
    }
}