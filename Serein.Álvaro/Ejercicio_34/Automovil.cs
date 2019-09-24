using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_34 {

    class Automovil : VehiculoTerrestre {

        private short cantidadMarchas;
        private int cantidadPasajeros;

        public Automovil(short cantidadRuedas, short cantidadPuertas, Colores color, short cantidadMarchas, int cantidadPasajeros)

            : base(cantidadRuedas, cantidadPuertas, color) {

            this.cantidadMarchas = cantidadMarchas;
            this.cantidadPasajeros = cantidadPasajeros;
        }

        public string Mostrar() {
            return "Ruedas:\t\t" + this.cantidadRuedas + "\n" +
                   "Puertas:\t" + this.cantidadPuertas + "\n" +
                   "Color:\t\t" + this.color + "\n" +
                   "Marchas:\t" + this.cantidadMarchas + "\n" +
                   "Pasajeros:\t" + this.cantidadPasajeros;
        }
    }
}
