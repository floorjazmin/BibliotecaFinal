using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Editoriales
    {
        #region Propiedades
        public int? Id_Editorial { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Id_Pais { get; set; }
        public string Email { get; set; }
    
        public int Telefono { get; set; }

        #endregion
    
        #region Constructores
         public Editoriales()
        {
        }

        public Editoriales(int idEditorial,  string nombre, string direccion, Paises idpais, string email, int telefono)
        {
            Id_Editorial = idEditorial;
            Nombre = nombre;
            Direccion = direccion;
            Id_Pais = idpais;
            Email = email;
            Telefono = telefono;
        }
        #endregion
    }
}
