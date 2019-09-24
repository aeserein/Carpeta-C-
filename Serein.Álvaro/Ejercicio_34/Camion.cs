using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_34 {

    class Camion : VehiculoTerrestre {

        private short cantidadMarchas;
        private int pesoCarga;

        public Camion(short cantidadRuedas, short cantidadPuertas, Colores color, short cantidadMarchas, int pesoCarga)

            : base(cantidadRuedas, cantidadPuertas, color) {

            this.cantidadMarchas = cantidadMarchas;
            this.pesoCarga = pesoCarga;
        }

        public string Mostrar() {
            return "Ruedas:\t\t" + this.cantidadRuedas + "\n" +
                   "Puertas:\t" + this.cantidadPuertas + "\n" +
                   "Color:\t\t" + this.color + "\n" +
                   "Marchas:\t" + this.cantidadMarchas + "\n" +
                   "Peso carga:\t" + this.pesoCarga;
        }
    }
}
