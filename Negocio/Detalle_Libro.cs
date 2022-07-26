using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Detalle_Libro
    {
        #region Metodos publicos
        public static List<Entidades.Detalle_Libro> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Detalle_libro.Listar();

            List<Entidades.Detalle_Libro> listaDetalle_libro = new List<Entidades.Detalle_Libro>();

            foreach (DataRow item in dt.Rows)
            {
                listaDetalle_libro.Add(ArmarDatos(item));
            }


            return listaDetalle_libro;
        }

        public static void Eliminar(int idDetalle_libro)
        {
            Datos.Detalle_libro.Eliminar(idDetalle_libro);
        }


        public static int Grabar(Entidades.Detalle_Libro detalle_Libro)
        {

            if (detalle_Libro.Id_DetalleLibro == null)
                return Datos.Detalle_libro.Insertar(detalle_Libro);
            else
            {
                Datos.Detalle_libro.Modificar(detalle_Libro);
                return detalle_Libro.Id_DetalleLibro.Value;
            }



        }

        #endregion

        #region Metodos privados
        private static Entidades.Detalle_Libro ArmarDatos(DataRow item)
        {
            Entidades.Detalle_Libro detalle_Libro = new Entidades.Detalle_Libro();
            detalle_Libro.Id_DetalleLibro = Convert.ToInt32(item["Id_DetalleLibro"]);
            detalle_Libro.Id_isbn = Convert.ToInt32(item["Id_isbn"]);
            detalle_Libro.Indice = Convert.ToString(item["Indice"]);
            detalle_Libro.Sinopsis = Convert.ToString(item["Sinopsis"]);
            return detalle_Libro;
        }
        #endregion
    }
}













}

