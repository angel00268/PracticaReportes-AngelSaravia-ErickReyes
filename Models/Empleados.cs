//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PracticaReportes_AngelSaravia_ErickReyes.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Empleados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleados()
        {
            this.Pedidos = new HashSet<Pedidos>();
        }
    
        public int IdEmpleado { get; set; }
        public string Apellidos { get; set; }
        public string Nombre { get; set; }
        public string cargo { get; set; }
        public string Tratamiento { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public Nullable<System.DateTime> FechaContratacion { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }
        public string region { get; set; }
        public string codPostal { get; set; }
        public string pais { get; set; }
        public string TelDomicilio { get; set; }
        public string Extension { get; set; }
        public string notas { get; set; }
        public Nullable<int> Jefe { get; set; }
        public Nullable<decimal> sueldoBasico { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedidos> Pedidos { get; set; }
    }
}
