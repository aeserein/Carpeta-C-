using System;

namespace Entidades {

    public class Numero {

        private double numero;

        ///////////////////////////////////////////////  Propiedades

        public string SetNumero {
            set {
                this.numero = ValidarNumero(value);
            }
        }

        ///////////////////////////////////////////////  Constructores

        public Numero() : this(0) { }

        public Numero(double numero) {
            this.numero = numero;
        }

        public Numero(string strNumero) {

        }

        ///////////////////////////////////////////////  Métodos

        private double ValidarNumero(string strNumero) {
            double aux = 0;
            double.TryParse(strNumero, out aux);
            return aux;                
        }

        public static string BinarioDecimal(string binario) {

            byte f;
            for (f = 0; f < binario.Length; f++) {
                if (binario[f] != '0' && binario[f] != '1')
                    return "Valor inválido\n(En func. string BinarioDecimal(string)";
            }

            double numero = 0;
            int exponente = binario.Length;

            for (f = 0; f < binario.Length; f++) {
                exponente--;
                if (binario[f] == '1')
                    numero += Math.Pow(2, exponente);
            }

            return numero.ToString();
        }

        public static string DecimalBinario(double numero) {

            string binario = "";
            long parteEntera = (long)numero;

            if (parteEntera<0) {
                parteEntera = parteEntera * (-1);
            }

            while (parteEntera >= 1) {
                binario = parteEntera % 2 + binario;
                parteEntera /= 2;
            }

            while (binario.Length % 8 > 0) {
                binario = '0' + binario;
            }

            return binario;
        }

        public static string DecimalBinario(string numero) {
            double aux;
            if (double.TryParse(numero, out aux))
                return Numero.DecimalBinario(aux);
            else
                return "Valor inválido\n(En func. string DecimalBinario(string)";
        }

        ///////////////////////////////////////////////  Operadores

        public static double operator +(Numero n1, Numero n2) {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2) {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2) {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2) {
            if (n2.numero == 0)
                return double.MinValue;
            else
                return n1.numero / n2.numero;
        }
    }
}
