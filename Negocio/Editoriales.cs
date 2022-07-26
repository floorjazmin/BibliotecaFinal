using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Negocio
{
    public class Editoriales    
    {

        #region Metodos publicos
        public static List<Entidades.Editoriales> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Editoriales.Listar();

            List<Entidades.Editoriales> listaEditoriales = new List<Entidades.Editoriales>();

            foreach (DataRow item in dt.Rows)
            {
                listaEditoriales.Add(ArmarDatos(item));
            }


            return listaEditoriales;
        }

        public static Entidades.Editoriales Obtener(int ideditorial)
        {
            DataTable dt = new DataTable();
            dt = Datos.Editoriales.ObtenerPorId(ideditorial);

            return ArmarDatos(dt.Rows[0]);
        }

        public int Grabar(Entidades.Editoriales editoriales)
        {
            try
            {
                if (esValida(editoriales, out string error))
                {
                    if (editoriales.Id_Editorial == null)
                    {
                        return Insertar(editoriales);
                    }
                    else
                    {
                        return Modificar(editoriales);
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
        private int Insertar(Entidades.Editoriales editoriales)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                return Datos.Editoriales.Insertar(editoriales);
            }

        }

        private int Modificar(Entidades.Editoriales editoriales)
        {
            Datos.Editoriales.Modificar(editoriales);

            return editoriales.Id_Editorial.Value;
        }

        private static bool esValida(Entidades.Editoriales editoriales, out string error)
        {
            error = "";

            if (string.IsNullOrEmpty(editoriales.Nombre))
                error += "El nombre ingresado se encuentra vacio; ";

            if (string.IsNullOrEmpty(editoriales.Direccion))
                error += "El direccion ingresado se encuentra vacio; ";

            if (string.IsNullOrEmpty(editoriales.Email))
                error += "El Email ingresado se encuentra vacio; ";

            if (editoriales.Id_Pais <= 0)
                error += "La id pais ingresado se encuentra vacia; ";

            if (editoriales.Telefono <= 0)
                error += "El telefono ingresado se encuentra vacia; ";



            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }


        private static Entidades.Editoriales ArmarDatos(DataRow item)
        {


            Entidades.Editoriales editoriales = new Entidades.Editoriales();


            editoriales.Id_Editorial = Convert.ToInt32(item["IdEditorial"]);
            editoriales.Nombre = item["Descripcion"].ToString();
            editoriales.Id_Pais = Convert.ToInt32(item["IdPais"]);
            editoriales.Email = item["Descripcion"].ToString(); 
            editoriales.Id_Editorial = Convert.ToInt32(item["IdEditorial"]);



            return editoriales;
        }


        #endregion


    }
}
