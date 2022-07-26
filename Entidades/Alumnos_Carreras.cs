using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Alumnos_Carreras
    {
        #region Propiedades
        public int? idAlumnos_Carreras { get; set; }
        public int? id_dni { get; set; }
        public int? id_carreras { get; set; }

        #endregion

        #region Constructores
        public Alumnos_Carreras()
        { }
        public Alumnos_Carreras(Alumnos idDni, Carreras idCarreras)
        {
            id_dni = idDni;
            id_carreras = idCarreras;
        }
        #endregion
    }
}
