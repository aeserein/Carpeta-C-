using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_31 {

    class PuestoAtencion {

        private static int numeroActual;
        private Puesto puesto;


        static PuestoAtencion() {
            PuestoAtencion.NumeroActual = 0;
        }
        public PuestoAtencion(Puesto puesto) {
            this.puesto = puesto;
        }


        public static int NumeroActual {
            get {
                PuestoAtencion.numeroActual++;
                return PuestoAtencion.numeroActual;
            }
            set {
                PuestoAtencion.numeroActual = value;
            }
        }


        public bool Atender(Cliente cli) {
            Thread.Sleep(1000 * 7);
            return true;
        }
    }

    enum Puesto {
        Caja1,
        Caja2
    }
}
