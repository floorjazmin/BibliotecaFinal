using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Negocio
{
    public class Libros
    {


        #region Metodos publicos
        
        public static List<Entidades.Libros> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Libros.Listar();

            List<Entidades.Libros> listaLibros = new List<Entidades.Libros>();

            foreach (DataRow item in dt.Rows)
            {
                listaLibros.Add(ArmarDatos(item));
            }


            return listaLibros;
        }

        public static Entidades.Libros Obtener(int id_isbn)
        {
            DataTable dt = new DataTable();
            dt = Datos.Libros.ObtenerPorId(id_isbn);

            return ArmarDatos(dt.Rows[0]);
        }


        public int Grabar(Entidades.Libros libros)
        {
            try
            {
                if (esValida(libros, out string error))
                {
                    if (libros.Id_isbn == null)
                    {
                        return Insertar(libros);
                    }
                    else
                    {
                        return Modificar(libros);
                    }
                }
                else
                    throw new Exception(error);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion

        #region Metodos privados
        private int Insertar(Entidades.Libros libros)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                return Datos.Libros.Insertar(libros);
            }

        }

        private int Modificar(Entidades.Libros libros)
        {
            Datos.Libros.Modificar(libros);

            return libros.Id_isbn.Value;
        }

        private static bool esValida(Entidades.Libros libros, out string error)
        {
            error = "";

            if (libros.Id_autor <= 0)
                error += "El id ingresado se encuentra vacio; ";


            if(libros.Id_editorial <= 0)
                error += "El id ingresado se encuentra vacio; ";


            if (libros.Id_categorias <= 0)
                error += "La id email ingresado se encuentra vacia; ";


            if (libros.Id_idiomas <= 0)
                error += "La id ingresado se encuentra vacia; ";


            if (string.IsNullOrEmpty(libros.Titulo))
                error += "El titulo ingresado se encuentra vacia; ";


            if (libros.Stock <= 0)
                error += "El stock ingresada no es válida. Tiene que ser mayor a 0; ";



            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }


        private static Entidades.Libros ArmarDatos(DataRow item)
        {


            Entidades.Libros libros = new Entidades.Libros();


            libros.Id_isbn = Convert.ToInt32(item["IdDni"]);
            libros.Id_autor = Convert.ToInt32(item["IdAutor"]);
            libros.Id_editorial = Convert.ToInt32(item["IdEditorial"]);
            libros.Id_categorias = Convert.ToInt32(item["IdCategorias"]);
            libros.Id_idiomas = Convert.ToInt32(item["IdIdiomas"]);
            libros.Titulo = item["Titulo"].ToString();
            libros.Stock = Convert.ToInt32(item["Stock"]);
            libros.Fecha_publicacion = (Convert.ToDateTime(item["Fecha_Publicacion"]));


            return libros;
        }


        #endregion
       

    }
}
