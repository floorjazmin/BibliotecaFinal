//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Biblioteca_Entity.Models.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class Alumnos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alumnos()
        {
            this.Libros_Alumnos = new HashSet<Libros_Alumnos>();
        }
    
        public int id_dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Nullable<int> edad { get; set; }
        public string direccion { get; set; }
        public string localidad { get; set; }
        public Nullable<System.DateTime> fechaDeNacimiento { get; set; }
        public Nullable<int> telefono { get; set; }
        public string email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Libros_Alumnos> Libros_Alumnos { get; set; }
    }
}
