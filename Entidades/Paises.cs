using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paises
    {
        #region Propiedades
        public int? Id_Pais { get; set; }
        public string Nombre { get; set; }
        #endregion

        #region Constructores
        public Paises()
        { }
        public Paises(int idPais,string nombre)
        {
            Nombre = nombre;
            Id_Pais = idPais;
        }
        #endregion
    }
}
