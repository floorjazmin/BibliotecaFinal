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
    public class Alumnos
    {
        public static DataTable Listar()
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Alumnos_Listar", cn);

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
                throw new Exception("Error al obtener la lista de Alumnos: " + ex.Message);
            }
        }

        public static int Insertar(Entidades.Alumnos alumnos)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Alumnos_Insertar", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@nombre", alumnos.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@apellido", alumnos.Apellido));
                    cmd.Parameters.Add(new SqlParameter("@edad", alumnos.Edad));
                    cmd.Parameters.Add(new SqlParameter("@direccion", alumnos.Direccion));
                    cmd.Parameters.Add(new SqlParameter("@localidad", alumnos.Localidad));
                    cmd.Parameters.Add(new SqlParameter("@fechaDeNacimiento", alumnos.FechaNacimiento));
                    cmd.Parameters.Add(new SqlParameter("@telefono", alumnos.Telefono));
                    cmd.Parameters.Add(new SqlParameter("@email", alumnos.Email));

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
                throw new Exception("Error al insertar el Alumno: " + ex.Message);
            }

        }
        public static DataTable Buscar(string nombre)
        {
            return Listar();
        }
        public static DataTable ObtenerPorId(int id_dni)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Alumnos_ObtenerPorId", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@id_dni", id_dni));

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
                throw new Exception("Error al obtener el Alumno: " + ex.Message);
            }
        }

        public static void Modificar(Entidades.Alumnos alumnos)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Alumnos_Modificar", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@Id_dni", alumnos.Id_dni));
                    cmd.Parameters.Add(new SqlParameter("@nombre", alumnos.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@apellido", alumnos.Apellido));
                    cmd.Parameters.Add(new SqlParameter("@edad", alumnos.Edad));
                    cmd.Parameters.Add(new SqlParameter("@direccion", alumnos.Direccion));
                    cmd.Parameters.Add(new SqlParameter("@localidad", alumnos.Localidad));
                    cmd.Parameters.Add(new SqlParameter("@fechaDeNacimiento", alumnos.FechaNacimiento));
                    cmd.Parameters.Add(new SqlParameter("@telefono", alumnos.Telefono));
                    cmd.Parameters.Add(new SqlParameter("@email", alumnos.Email));

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Modificar el Alumno: " + ex.Message);
            }

        }

        public static void Eliminar(int idDni)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Alumnos_Eliminar", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@Id_dni", idDni));

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Eliminar el Alumno: " + ex.Message);
            }
        }
    }













}

