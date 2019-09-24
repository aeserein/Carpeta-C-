using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_34 {

    class VehiculoTerrestre {

        protected short cantidadRuedas;
        protected short cantidadPuertas;
        protected Colores color;

        public VehiculoTerrestre(short cantidadRuedas, short cantidadPuertas, Colores color) {
            this.cantidadRuedas = cantidadRuedas;
            this.cantidadPuertas = cantidadPuertas;
            this.color = color;
        }
    }
}
