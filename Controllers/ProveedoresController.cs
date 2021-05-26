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
    public class ProveedoresController : Controller
    {
        neptunoEntities dbc = new neptunoEntities();
        // GET: Proveedores
        public ActionResult Index()
        {
            ViewBag.categorias = dbc.categorias.ToList();
            return View();
        }

        public ActionResult ReporteProveedores(int idcat)
        {
            var reporte = new ReportClass();
            reporte.FileName = Server.MapPath("/Rpts/ReporteProveedores.rpt");
            //Estableciendo un parametro al reporte
            reporte.SetParameterValue("idCategoria", idcat);
            //Establecer conexion para el reporte
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