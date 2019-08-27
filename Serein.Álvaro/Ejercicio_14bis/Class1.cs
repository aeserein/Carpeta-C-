using System;

namespace Ejercicio_14bis {

    public class CalculoDeArea {

        public static double CalcularCuadrado(double tamanio) {
            return Math.Pow(tamanio, 2);
        }

        public static double CalcularTriangulo(double vase, double altura) {
            return vase*altura/2;
        }

        public static double CalcularCirculo(double radio) {
            return Math.PI * Math.Pow(radio, 2);
        }

    }

}
