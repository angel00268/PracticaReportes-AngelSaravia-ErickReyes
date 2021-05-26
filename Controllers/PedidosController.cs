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
    public class PedidosController : Controller
    {
        // GET: Pedidos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReporteFechas(string fechaIni, string fechaFin)
        {
            var reporte = new ReportClass();
            reporte.FileName = Server.MapPath("/Rpts/ReportePedidos.rpt");
            //Estableciendo un parametro al reporte
            reporte.SetParameterValue("fechaInicial", fechaIni);
            reporte.SetParameterValue("fechaFinal", fechaFin);
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