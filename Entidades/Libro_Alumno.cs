using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro_Alumnos
    {
        #region Propiedades
        public int? Id_isbn { get; set; }
        public int? Id_dni { get; set; }
        public DateTime Fecha_Entrega { get; set; }
        public DateTime Fecha_Devolucion { get; set; }

        #endregion

        #region Constructores
        public Libro_Alumnos()
        { }
        public Libro_Alumnos(Libros idIsbn, Alumnos idDni, DateTime fecha_entrega, DateTime fecha_devolucion)
        {
            Id_isbn = idIsbn;
            Id_dni = idDni;
            Fecha_Entrega = fecha_entrega;
            Fecha_Devolucion = fecha_devolucion;
        }
        #endregion

    }
}
