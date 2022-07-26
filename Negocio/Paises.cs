using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Paises
    {
        #region Metodos publicos
        public static List<Entidades.Paises> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Paises.Listar();

            List<Entidades.Paises> listaPaises = new List<Entidades.Paises>();

            foreach (DataRow item in dt.Rows)
            {
                listaPaises.Add(ArmarDatos(item));
            }


            return listaPaises;
        }

        public static Entidades.Paises Obtener(int idPais)
        {
            DataTable dt = new DataTable();
            dt = Datos.Paises.ObtenerPorId(idPais);

            return ArmarDatos(dt.Rows[0]);
        }


        public static void Eliminar(int idPais)
        {
            Datos.Paises.Eliminar(idPais);
        }


        public static int Grabar(Entidades.Paises pais)
        {

            if (pais.Id_Pais == null)
                return Datos.Paises.Insertar(pais);
            else
            {
                Datos.Paises.Modificar(pais);
                return pais.Id_Pais.Value;
            }
            


        }

        #endregion

        #region Metodos privados
        private static Entidades.Paises ArmarDatos(DataRow item)
        {
            Entidades.Paises pais = new Entidades.Paises(Convert.ToInt32(item["Id_Pais"]), item["Nombre"].ToString());
            return pais;
        }
        #endregion
    }
}
