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
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VerReporte()
        {
            var reporte = new ReportClass();
            reporte.FileName = Server.MapPath("/Rpts/ClientesReport.rpt");

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