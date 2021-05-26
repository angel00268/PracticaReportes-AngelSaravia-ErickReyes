using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaReportes_AngelSaravia_ErickReyes.Models
{
    public class ReporteConexion
    {
        public static CrystalDecisions.Shared.ConnectionInfo getConexion()
        {
            CrystalDecisions.Shared.ConnectionInfo infocon = new CrystalDecisions.Shared.ConnectionInfo();
            infocon.ServerName = @"LAPTOP-RGAMU58L\LOCALHOST";
            infocon.DatabaseName = "neptuno";
            infocon.IntegratedSecurity = true;

            return infocon;
        }
    }
}