using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;

namespace UnitTestNegocio
{
    [TestClass]
    public class Alumnos
    {
        [TestMethod]
        public void Alta()
        {
            Entidades.Alumnos alumnos = new Entidades.Alumnos();
            alumnos.Nombre = "Florencia";
            alumnos.Apellido = "Marino";
            alumnos.Edad = 21;
            alumnos.Direccion = "Av Congreso 3896";
            alumnos.Localidad = "CABA";
            alumnos.FechaNacimiento = DateTime.Now;
            alumnos.Telefono = 1234455131;
            alumnos.Email = "florencia.jazmin08@gmail.com";


            Negocio.Alumnos.Grabar(alumnos);


        }


        [TestMethod]
        public void Listar()
        {
            Negocio.Alumnos.Listar();

        }


        [TestMethod]
        public void Modificacion()
        {
            Entidades.Alumnos alumnos = new Entidades.Alumnos();
            alumnos.Id_dni = 1;
            alumnos.Nombre = "Juana";
            alumnos.Apellido = "Lopez";

            Negocio.Alumnos.Grabar(alumnos);
        }

        [TestMethod]
        public void Baja()
        {

            Negocio.Alumnos.Eliminar(3);
        }

    }
}
