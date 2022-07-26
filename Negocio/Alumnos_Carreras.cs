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
    public class Alumnos_Carreras
    {

        #region Metodos publicos
        public static List<Entidades.Alumnos_Carreras> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Alumnos_Careras.Listar();

            List<Entidades.Alumnos_Carreras> listaAlumnos_Carreras = new List<Entidades.Alumnos_Carreras>();

            foreach (DataRow item in dt.Rows)
            {
                listaAlumnos_Carreras.Add(ArmarDatos(item));
            }


            return listaAlumnos_Carreras;
        }


        public static int Grabar(Entidades.Alumnos_Carreras alumnos_Carreras)
        {
            try
            {
                if (esValida(alumnos_Carreras, out string error))
                {
                    if (alumnos_Carreras.idAlumnos_Carreras == null)
                    {
                        return Insertar(alumnos_Carreras);
                    }
                    else
                    {
                        return Modificar(alumnos_Carreras);
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
        public static int Insertar(Entidades.Alumnos_Carreras alumnos_Carreras)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                return Datos.Alumnos.Insertar(alumnos_Carreras);
            }

        }
        public static void Eliminar(int idAlumnos_carreras)
        {
            Datos.Alumnos.Eliminar(idAlumnos_carreras);
        }

        public static int Modificar(Entidades.Alumnos_Carreras alumnos_Carreras)
        {
            Datos.Alumnos.Modificar(alumnos_Carreras);

            return alumnos_Carreras.idAlumnos_Carreras.Value;
        }

        private static bool esValida(Entidades.Alumnos_Carreras alumnos_Carreras, out string error)
        {
            error = "";


            if (alumnos_Carreras.idAlumnos_Carreras <= 0)
                error += "El id alumnos_carreras no es válida. Tiene que ser mayor a 0; ";

            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }


        private static Entidades.Alumnos_Carreras ArmarDatos(DataRow item)
        {


            Entidades.Alumnos_Carreras alumnos_Carreras = new Entidades.Alumnos_Carreras();


            alumnos_Carreras.idAlumnos_Carreras = Convert.ToInt32(item["idAlumnos_Carreras"]);
            alumnos_Carreras.id_carreras = Convert.ToInt32(item["id_carreras"]);
            alumnos_Carreras.id_dni = Convert.ToInt32(item["id_dni"]);
           

            return alumnos_Carreras;
        }


        #endregion
    }
}













}

