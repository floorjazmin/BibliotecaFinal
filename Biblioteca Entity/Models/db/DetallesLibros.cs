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
    
    public partial class DetallesLibros
    {
        public int Id_Detalle_Libro { get; set; }
        public Nullable<int> Id_isbn { get; set; }
        public string Sinopsis { get; set; }
        public string Indice { get; set; }
    
        public virtual Libros Libros { get; set; }
    }
}
