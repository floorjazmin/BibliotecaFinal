using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Negocio
{
    public class Alumnos
    {
     

        #region Metodos publicos
        public static List<Entidades.Alumnos> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Alumnos.Listar();

            List<Entidades.Alumnos> listaAlumnos = new List<Entidades.Alumnos>();

            foreach (DataRow item in dt.Rows)
            {
                listaAlumnos.Add(ArmarDatos(item));
            }


            return listaAlumnos;
        }

        public static Entidades.Alumnos Obtener(int id_dni)
        {
            DataTable dt = new DataTable();
            dt = Datos.Alumnos.ObtenerPorId(id_dni);

            return ArmarDatos(dt.Rows[0]);
        }


        public static int Grabar(Entidades.Alumnos alumnos)
        {
            try
            {
                if (esValida(alumnos, out string error))
                {
                    if (alumnos.Id_dni == null)
                    {
                        return Insertar(alumnos);
                    }
                    else
                    {
                        return Modificar(alumnos);
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
        public static int Insertar(Entidades.Alumnos alumnos)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                return Datos.Alumnos.Insertar(alumnos);
            }
            
        }
        public static void Eliminar(int idAlumnos)
        {
            Datos.Alumnos.Eliminar(idAlumnos);
        }

        public static int Modificar(Entidades.Alumnos alumnos)
        {
            Datos.Alumnos.Modificar(alumnos);

            return alumnos.Id_dni.Value;
        }

        private static bool esValida(Entidades.Alumnos alumnos, out string error)
        {
            error = "";

            if (string.IsNullOrEmpty(alumnos.Nombre))
                error += "El nombre ingresado se encuentra vacio; ";


            if (string.IsNullOrEmpty(alumnos.Apellido))
                error += "El Apellido ingresado se encuentra vacio; ";


            if (string.IsNullOrEmpty(alumnos.Email))
                error += "La Direccion email ingresado se encuentra vacia; ";


            if (string.IsNullOrEmpty(alumnos.Localidad))
                error += "La Localidad ingresado se encuentra vacia; ";


            if (string.IsNullOrEmpty(alumnos.Direccion))
                error += "La Direccion ingresado se encuentra vacia; ";


            if (alumnos.Edad <= 0)
                error += "La Edad ingresada no es válida. Tiene que ser mayor a 0; ";

            if (alumnos.Telefono <= 0)
                error += "El telefono ingresada no es válida. Tiene que ser mayor a 0; ";


            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }


        private static Entidades.Alumnos ArmarDatos(DataRow item)
        {
            
           
                Entidades.Alumnos alumnos = new Entidades.Alumnos();


                alumnos.Id_dni = Convert.ToInt32(item["IdDni"]);
                alumnos.Nombre = item["Nombre"].ToString();
                alumnos.Apellido = item["Apellido"].ToString();
                alumnos.Edad = (Convert.ToInt32(item["Edad"]));
                alumnos.Email = item["Email"].ToString();
                alumnos.Direccion = item["Direccion"].ToString();
                alumnos.Localidad = item["Localidad"].ToString();
                alumnos.Telefono = (Convert.ToInt32(item["Telefono"]));

                
                return alumnos;
        }
            
        
        #endregion

    }
}
