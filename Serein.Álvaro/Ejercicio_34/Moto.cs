using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_34 {

    class Moto : VehiculoTerrestre {

        private short cilindrada;

        public Moto(short cantidadRuedas, short cantidadPuertas, Colores color, short cilindrada)

            : base(cantidadRuedas, cantidadPuertas, color) {

            this.cilindrada = cilindrada;
        }

        public string Mostrar() {
            return "Ruedas:\t\t" + this.cantidadRuedas + "\n" +
                   "Puertas:\t" + this.cantidadPuertas + "\n" +
                   "Color:\t\t" + this.color + "\n" +
                   "Cilindrada:\t" + this.cilindrada;
        }
    }
}
