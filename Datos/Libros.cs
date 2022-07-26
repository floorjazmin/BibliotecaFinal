using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Libros
    {
        public static DataTable Listar()
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Libros_Listar", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de libros: " + ex.Message);
            }
        }

        public static int Insertar(Entidades.Libros libros)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Libros_Insertar", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@Id_autor", libros.Id_autor));
                    cmd.Parameters.Add(new SqlParameter("@Id_editorial", libros.Id_editorial));
                    cmd.Parameters.Add(new SqlParameter("@Id_categoria", libros.Id_categorias));
                    cmd.Parameters.Add(new SqlParameter("@Id_idioma", libros.Id_idiomas));
                    cmd.Parameters.Add(new SqlParameter("@titulo", libros.Titulo));
                    cmd.Parameters.Add(new SqlParameter("@stock", libros.Stock));
                    cmd.Parameters.Add(new SqlParameter("@fecha_publicacion", libros.Fecha_publicacion));


                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

                return Convert.ToInt32(dt.Rows[0][0]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el libro: " + ex.Message);
            }
        }
        public static DataTable Buscar(string titulo)
        {
            return Listar();
        }
        public static DataTable ObtenerPorId(int id_isbn)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Libros_ObtenerPorId", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdISBN", id_isbn));

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;


                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el id del libro: " + ex.Message);
            }
        }

        public static void Modificar(Entidades.Libros libros)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Libros_Modificar", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@Id_isbn", libros.Id_isbn));
                    cmd.Parameters.Add(new SqlParameter("@Id_autor", libros.Id_autor));
                    cmd.Parameters.Add(new SqlParameter("@Id_editorial", libros.Id_editorial));
                    cmd.Parameters.Add(new SqlParameter("@Id_categoria", libros.Id_categorias));
                    cmd.Parameters.Add(new SqlParameter("@Id_idioma", libros.Id_idiomas));
                    cmd.Parameters.Add(new SqlParameter("@titulo", libros.Titulo));
                    cmd.Parameters.Add(new SqlParameter("@stock", libros.Stock));
                    cmd.Parameters.Add(new SqlParameter("@fecha_publicacion", libros.Fecha_publicacion));

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Actualizar el libro " + ex.Message);
            }
        }

        public static void Eliminar(int idisbn)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Libros_Eliminar", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@Id_isbn", idisbn));

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Eliminar el libro: " + ex.Message);
            }
        }


    }
}
