using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Autores
    {
        #region Propiedades

        public int? id_autor { get; set; }
        public int id_pais { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Email { get; set; }
        #endregion

        #region Constructores
        public Autores()
        { }
        public Autores(int idAutor, Paises idPais, string nombre, string apellido, DateTime fechaDeNacimiento, string email)
        {
            id_autor = idAutor;
            id_pais = id_autor;
            Nombre = nombre;
            Apellido = apellido;
            FechaDeNacimiento = fechaDeNacimiento;
            Email = email;
        }
        #endregion


    }
}
