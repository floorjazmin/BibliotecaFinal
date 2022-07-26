using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Detalle_Libro
    {
        #region Propiedades
        public int? Id_DetalleLibro { get; set; }
        public int? Id_isbn { get; set; }
        public string Sinopsis { get; set; }
        public string Indice { get; set; }

        #endregion

        #region Constructores
        public Detalle_Libro()
        { }
        public Detalle_Libro(int idDetalleLibro, Libros idIsbn, string sinopsis, string indice)
        {
            Id_DetalleLibro = idDetalleLibro;
            Id_isbn = idIsbn;
            Sinopsis = sinopsis;
            Indice = indice;
        }
        #endregion

    }
}
