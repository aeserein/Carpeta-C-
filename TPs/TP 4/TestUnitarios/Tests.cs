using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Entidades;

namespace TestUnitarios {

    [TestClass]
    public class Tests {

        [TestMethod]
        public void Test_CorreoPaquetes() {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void Test_MismoTrackingID() {
            Paquete p1 = new Paquete("Dirección 1", "123123123");
            Paquete p2 = new Paquete("Dirección 2", "123123123");
            Correo correo = new Correo();

            correo += p1;
            correo += p2;
        }
    }
}
