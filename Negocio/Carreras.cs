using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Negocio
{
    public class Carreras
    {


        #region Metodos publicos
        public static List<Entidades.Carreras> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Carreras.Listar();

            List<Entidades.Carreras> listaCarreras = new List<Entidades.Carreras>();

            foreach (DataRow item in dt.Rows)
            {
                listaCarreras.Add(ArmarDatos(item));
            }


            return listaCarreras;
        }

        public static Entidades.Carreras Obtener(int idCarrera)
        {
            DataTable dt = new DataTable();
            dt = Datos.Carreras.ObtenerPorId(idCarrera);

            return ArmarDatos(dt.Rows[0]);
        }

        public int Grabar(Entidades.Carreras carreras)
        {
            try
            {
                if (esValida(carreras, out string error))
                {
                    if (carreras.Id_carreras == null)
                    {
                        return Insertar(carreras);
                    }
                    else
                    {
                        return Modificar(carreras);
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
        private int Insertar(Entidades.Carreras carreras)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                return Datos.Carreras.Insertar(carreras);
            }

        }

        private int Modificar(Entidades.Carreras carreras)
        {
            Datos.Carreras.Modificar(carreras);

            return carreras.Id_carreras.Value;
        }

        private static bool esValida(Entidades.Carreras carreras, out string error)
        {
            error = "";

            if (string.IsNullOrEmpty(carreras.Nombre))
                error += "La carrera ingresado se encuentra vacio; ";


            if (carreras.Duracion <= 0)
                error += "La duracion ingresada no es válida. Tiene que ser mayor a 0; ";



            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }


        private static Entidades.Carreras ArmarDatos(DataRow item)
        {


            Entidades.Carreras carreras = new Entidades.Carreras();


            carreras.Id_carreras = Convert.ToInt32(item["IdCarreras"]);
            carreras.Nombre = item["Nombre"].ToString();
            carreras.Duracion = Convert.ToInt32(item["Duracion"]);


            return carreras;
        }


        #endregion


    }
}
