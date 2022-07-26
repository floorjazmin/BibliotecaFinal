using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    
    public class Idiomas
    {
        #region Propiedades
        public int? Id_Idioma { get; set; }
        public string Descripcion { get; set; }
        #endregion

        #region Constructores
        public Idiomas()
        { }
        public Idiomas(int idIdioma, string descripcion)
        {
            Id_Idioma = idIdioma;
            Descripcion = descripcion;
        }
        #endregion


    }



}
