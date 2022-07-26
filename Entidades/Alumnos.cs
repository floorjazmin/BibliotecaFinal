using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Alumnos
    {
        #region Propiedades
        public int? Id_dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public int Edad { get; set; }
        public int Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }

        #endregion

        #region Constructores
        public Alumnos()
        { }
        public Alumnos(int idDni, string nombre, string apellido, string email, string direccion, string localidad, int edad,int telefono, DateTime fechaDeNacimiento)
        {
            Id_dni = idDni;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Direccion = direccion;
            Localidad = localidad;
            Edad = edad;
            Telefono = telefono;
            FechaNacimiento = fechaDeNacimiento;
        }
        #endregion

    }
}
