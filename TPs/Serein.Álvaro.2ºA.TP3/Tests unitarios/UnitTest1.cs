using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Clases_Instanciables;
using EntidadesAbstractas;
using Excepciones;

namespace Tests_unitarios {

    [TestClass]
    public class UnitTest1 {

        [TestMethod]
        public void Test_AlumnoRepetidoException() {
            Universidad universidad = new Universidad();
            Alumno a1 = new Alumno(1, "Nombre1", "Apellido1", "1111111", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno a2 = new Alumno(2, "Nombre2", "Apellido2", "2222222", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno a3 = new Alumno(3, "Nombre3", "Apellido3", "3333333", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno repetido = new Alumno(1, "Nombre1", "Apellido1", "1111111", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            try {
                universidad += a1;
                universidad += a2;
                universidad += a3;
                universidad += repetido;
            } catch (Exception e) {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        [TestMethod]
        public void Test_SinProfesorException() {
            Universidad universidad = new Universidad();
            try {
                universidad += Universidad.EClases.Programacion;
            } catch (Exception e) {
                Assert.IsInstanceOfType(e, typeof(SinProfesorException));
            }
        }

        [TestMethod]
        public void Test_ValorNumerico() {
            Alumno a1 = new Alumno(1, "Nombre1", "Apellido1", "1111111", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Assert.AreEqual(1111111, a1.DNI);
        }

        [TestMethod]
        public void Test_ValoresNulos() {
            Alumno alumno = new Alumno(1, "Nombre1", "Apellido1", "1111111", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Profesor profesor = new Profesor(1, "Nombre1", "Apellido1", "1111111", Persona.ENacionalidad.Argentino);
            Jornada jornada = new Jornada(Universidad.EClases.Laboratorio, profesor);
            Universidad universidad = new Universidad();
            Assert.IsNotNull(alumno);
            Assert.IsNotNull(profesor);
            Assert.IsNotNull(jornada);
            Assert.IsNotNull(universidad);
        }
    }
}
