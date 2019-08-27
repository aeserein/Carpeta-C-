using System;

namespace lib_numeros {

    public class Validacion {

        public static bool Validar(int valor, int min, int max) {
            return (valor >= min && valor <= max);
        }

        public static bool Validar(float valor, float min, float max) {
            return (valor >= min && valor <= max);
        }

        public static bool Validar(short valor, short min, short max) {
            return (valor >= min && valor <= max);
        }

        public static bool Validar(double valor, double min, double max) {
            return (valor >= min && valor <= max);
        }

        public static bool Validar(char valor, char min, char max) {
            return (valor >= min && valor <= max);
        }
    }

}
