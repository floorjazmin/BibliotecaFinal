using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Negocio
{
    public class Autores
    {

        #region Metodos publicos

        public static List<Entidades.Autores> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Autores.Listar();

            List<Entidades.Autores> listaAutores = new List<Entidades.Autores>();

            foreach (DataRow item in dt.Rows)
            {
                listaAutores.Add(ArmarDatos(item));
            }


            return listaAutores;
        }

        public static Entidades.Autores Obtener(int idAutores)
        {
            DataTable dt = new DataTable();
            dt = Datos.Autores.ObtenerPorId(idAutores);

            return ArmarDatos(dt.Rows[0]);
        }


        public int Grabar(Entidades.Autores autores)
        {
            try
            {
                if (esValida(autores, out string error))
                {
                    if (autores.id_autor == null)
                    {
                        return Insertar(autores);
                    }
                    else
                    {
                        return Modificar(autores);
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
        private int Insertar(Entidades.Autores autores)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                return Datos.Autores.Insertar(autores);
            }

        }

        private int Modificar(Entidades.Autores autores)
        {
            Datos.Autores.Modificar(autores);

            return autores.id_autor.Value;
        }

        private static bool esValida(Entidades.Autores autores, out string error)
        {
            error = "";


            if (string.IsNullOrEmpty(autores.Nombre))
                error += "El Nombre ingresado se encuentra vacia; ";

            if (string.IsNullOrEmpty(autores.Apellido))
                error += "El Apellido ingresado se encuentra vacia; ";

            if (string.IsNullOrEmpty(autores.Email))
                error += "El titulo ingresado se encuentra vacia; ";

            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }


        private static Entidades.Autores ArmarDatos(DataRow item)
        {


            Entidades.Autores autores = new Entidades.Autores();


            autores.id_autor = Convert.ToInt32(item["IdAutor"]);
            autores.id_pais = Convert.ToInt32(item["IdAutor"]);
            autores.Nombre = item["Nombre"].ToString();
            autores.Apellido = item["Apellido"].ToString(); 
            autores.FechaDeNacimiento = Convert.ToDateTime(item["FechaDeNacimiento"]);
            autores.Email = item["Titulo"].ToString();

            return autores;
        }


        #endregion

    }
}
