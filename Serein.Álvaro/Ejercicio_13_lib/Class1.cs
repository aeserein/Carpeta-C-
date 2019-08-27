using System;

namespace Ejercicio_13_lib {

    public class Conversor {

        public static string DecimalABinario(double numero) {

            // no trabaja con parte decimal
            // y ni siquiera existe binario con coma
            // acepta tipo doble por consigna pero no funciona con numeros con coma

            string binario = "";
            int parteEntera;
            int len = 0;

            while (numero>=1) {
                binario = (int)numero % 2 + binario;
                parteEntera = (int)(numero /= 2);
            }

            len = binario.Length;

            while (len%8 > 0) {
                binario = '0' + binario;
                len = binario.Length;
            }

            return binario;

        }

        public static double BinarioADecimal(string binario) {

            double numero=0;

            int f, exponente;
            exponente = binario.Length;

            for (f=0 ; f<binario.Length; f++) {

                exponente--;
                if (binario[f] == '1')
                    numero += Math.Pow(2, exponente);
            }

            return numero;  //devuelvo un long que se convierte a doble

        }

    }

}
