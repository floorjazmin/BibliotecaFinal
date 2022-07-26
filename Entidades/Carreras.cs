using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Carreras
    {
        #region Propiedades
        public int? Id_carreras{ get; set; }
        public string Nombre { get; set; }
        public int Duracion { get; set; }
        #endregion

        #region Constructores
        public Carreras()
        { }
        public Carreras(int idCarreras,string nombre, int duracion)
        {
            Id_carreras = idCarreras;
            Nombre = nombre;
            Duracion = duracion;
        }
        #endregion
    }
}
