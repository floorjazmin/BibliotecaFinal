using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Negocio
{
    public class Categorias
    {


        #region Metodos publicos
        public static List<Entidades.Categorias> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Categorias.Listar();

            List<Entidades.Categorias> listaCategorias = new List<Entidades.Categorias>();

            foreach (DataRow item in dt.Rows)
            {
                listaCategorias.Add(ArmarDatos(item));
            }


            return listaCategorias;
        }

        public static Entidades.Categorias Obtener(int idcategoria)
        {
            DataTable dt = new DataTable();
            dt = Datos.Categorias.ObtenerPorId(idcategoria);

            return ArmarDatos(dt.Rows[0]);
        }

        public int Grabar(Entidades.Categorias categorias)
        {
            try
            {
                if (esValida(categorias, out string error))
                {
                    if (categorias.Id_categorias == null)
                    {
                        return Insertar(categorias);
                    }
                    else
                    {
                        return Modificar(categorias);
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
        private int Insertar(Entidades.Categorias categorias)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                return Datos.Categorias.Insertar(categorias);
            }

        }

        private int Modificar(Entidades.Categorias categorias)
        {
            Datos.Categorias.Modificar(categorias);

            return categorias.Id_categorias.Value;
        }

        private static bool esValida(Entidades.Categorias categorias, out string error)
        {
            error = "";

            if (string.IsNullOrEmpty(categorias.Descripcion))
                error += "La Descripcion ingresado se encuentra vacio; ";



            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }


        private static Entidades.Categorias ArmarDatos(DataRow item)
        {


            Entidades.Categorias categorias = new Entidades.Categorias();


            categorias.Id_categorias = Convert.ToInt32(item["IdCategorias"]);
            categorias.Descripcion = item["Descripcion"].ToString();
            


            return categorias;
        }


        #endregion


    }
}
