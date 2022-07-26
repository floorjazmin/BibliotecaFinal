using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libros
    {
        #region Propiedades
        public int? Id_isbn { get; set; }
        public int? Id_autor { get; set; }
        public int? Id_editorial { get; set; }
        public int? Id_categorias { get; set; }
        public int? Id_idiomas { get; set; }
        public string Titulo { get; set; }
        public int Stock { get; set; }
        public DateTime Fecha_publicacion { get; set; }
        #endregion

        #region Constructores
        public Libros()
        { }
        public Libros(int idIsbn, int idAutor, int idEditoriales, int idCategorias, int idIdiomas, string titulo, int stock, DateTime fechaPublicacion)
        {
            Id_isbn = idIsbn;
            Id_autor = idAutor;
            Id_editorial = idEditoriales;
            Id_categorias = idCategorias;
            Id_idiomas = idIdiomas;
            Titulo = titulo;
            Stock = stock;
            Fecha_publicacion = fechaPublicacion;
        }
        #endregion
    }
}
