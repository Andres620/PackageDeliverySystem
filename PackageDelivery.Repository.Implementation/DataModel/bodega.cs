//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PackageDelivery.Repository.Implementation.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class bodega
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bodega()
        {
            this.historial = new HashSet<historial>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public string codigo { get; set; }
        public string direccion { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public int idMunicipio { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<historial> historial { get; set; }
        public virtual municipio municipio { get; set; }
    }
}
