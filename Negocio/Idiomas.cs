using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Negocio
{
    public class Idiomas
    {
     

        #region Metodos publicos
        public static List<Entidades.Idiomas> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Idiomas.Listar();

            List<Entidades.Idiomas> listaIdiomas = new List<Entidades.Idiomas>();

            foreach (DataRow item in dt.Rows)
            {
                listaIdiomas.Add(ArmarDatos(item));
            }


            return listaIdiomas;
        }

        public static Entidades.Idiomas Obtener(int idIdioma)
        {
            DataTable dt = new DataTable();
            dt = Datos.Idiomas.ObtenerPorId(idIdioma);

            return ArmarDatos(dt.Rows[0]);
        }

       
        public int Grabar(Entidades.Idiomas idiomas)
        {
            try
            {
                if (Validar(idiomas, out string error))
                {
                    if (idiomas.Id_Idioma == null)
                    {
                        return Insertar(idiomas);
                    }
                    else
                    {
                        return Modificar(idiomas);
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
        private int Insertar(Entidades.Idiomas idiomas)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                return Datos.Idiomas.Insertar(idiomas);
            }
            
        }

        private int Modificar(Entidades.Idiomas idiomas)
        {
            Datos.Idiomas.Modificar(idiomas);

            return idiomas.Id_Idioma.Value;
        }

        private bool Validar(Entidades.Idiomas idiomas,out string error)
        {
            error = "";


            if (string.IsNullOrEmpty(idiomas.Descripcion))
                error += "La descripcion ingresado se encuentra vacia; ";

            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }

        private static Entidades.Idiomas ArmarDatos(DataRow item)
        {
            Entidades.Idiomas idiomas = new Entidades.Idiomas();
            idiomas.Id_Idioma = Convert.ToInt32(item["IdIdiomas"]);
            idiomas.Descripcion = item["Descripcion"].ToString();

            return idiomas;
        }
        #endregion

    }
}
