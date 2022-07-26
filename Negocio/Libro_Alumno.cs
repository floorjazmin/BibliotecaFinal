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
    public class Libro_Alumno
    {
        #region Metodos publicos
        public static List<Entidades.Libro_Alumnos> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Paises.Listar();

            List<Entidades.Libro_Alumnos> listalibro_alumnos = new List<Entidades.Libro_Alumnos>();

            foreach (DataRow item in dt.Rows)
            {
                listalibro_alumnos.Add(ArmarDatos(item));
            }


            return listalibro_alumnos;
        }


        public static void Eliminar(int idLibro_Alumnos)
        {
            Datos.Paises.Eliminar(idLibro_Alumnos);
        }


        public static int Grabar(Entidades.Libro_Alumnos libro_Alumnos)
        {

            if (libro_Alumnos.Id_isbn == null)
                return Datos.Libro_Alumno.Insertar(libro_Alumnos);
            else
            {
                Datos.Libro_Alumno.Modificar(libro_Alumnos);
                return libro_Alumnos.Id_isbn.Value;
            }



        }

        #endregion

        #region Metodos privados
        private static Entidades.Libro_Alumnos ArmarDatos(DataRow item)
        {
            Entidades.Libro_Alumnos libro_Alumnos = new Entidades.Libro_Alumnos();
            libro_Alumnos.Id_isbn = Convert.ToInt32(item["Id_isbn"]);
            libro_Alumnos.Id_dni = Convert.ToInt32(item["Id_dni"]);
            libro_Alumnos.Fecha_Entrega = Convert.ToDateTime(item["fecha_entrega"]);
            libro_Alumnos.Fecha_Devolucion = Convert.ToDateTime(item["fecha_devolucion"]);

            return libro_Alumnos;
        }
        #endregion
    }


}

