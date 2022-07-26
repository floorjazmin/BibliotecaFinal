using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categorias
    {
        #region Propiedades

        public int? Id_categorias { get; set; }
        public string Descripcion { get; set; }

        #endregion

        #region Constructores
        public Categorias()
        { }
        public Categorias(int IdCategorias, string descripcion)
        {
            Id_categorias = IdCategorias;
            Descripcion = descripcion;
        }
        #endregion
    }
}
