using System;

namespace Entidades {

    /// <summary>
    /// Representa un número. Incluye sobrecarga de instancias de Numero
    /// para operaciones básicas y conversiones entre números decimales y binarios.
    /// </summary>
    public class Numero {

        private double numero;

        //////////////////////////////////////////////////////////////////  Propiedades

        private string SetNumero {
            set {
                this.numero = ValidarNumero(value);
            }
        }

        //////////////////////////////////////////////////////////////////  Constructores

        public Numero() : this(0) { }

        public Numero(double numero) : this(numero.ToString()) { }

        public Numero(string strNumero) {
            this.SetNumero = strNumero;
        }

        //////////////////////////////////////////////////////////////////  Métodos

        /// <summary>
        /// Valida un string numérico, lo convierte a double.
        /// </summary>
        /// <param name="strNumero">Número a validar</param>
        /// <returns>(double) Devuelve el valor original si es válido.
        /// 0 si strNumero es inválido.</returns>
        private double ValidarNumero(string strNumero) {
            double aux = 0;
            double.TryParse(strNumero, out aux);
            return aux;                
        }

        /// <summary>
        /// Convierte un número binario en decimal.
        /// Ambos de tipo string.
        /// </summary>
        /// <param name="binario">Número a convertir a decimal</param>
        /// <returns>(string) Número convertido a decimal.
        /// "Valor inválido" si no se puede convertir.</returns>
        public static string BinarioDecimal(string binario) {

            if (binario == "")
                return "Valor inválido";

            byte f;
            for (f = 0; f < binario.Length; f++) {
                if (binario[f] != '0' && binario[f] != '1')
                    return "Valor inválido";
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

        /// <summary>
        /// Convierte un número decimal (double) a binario (string).
        /// Trabaja con el valor absoluto e ignora la parte decimal.
        /// </summary>
        /// <param name="numero">Número a convertir a binario</param>
        /// <returns>(string) Número convertido a binario.
        /// "Valor inválido" si numero = double.MinValue.</returns>
        public static string DecimalBinario(double numero) {

            if (numero == double.MinValue)
                return "Valor inválido";

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

        /// <summary>
        /// Convierte un número decimal (string) a binario (string).
        /// Trabaja con el valor absoluto e ignora la parte decimal.
        /// </summary>
        /// <param name="numero">Número a convertir a binario</param>
        /// <returns>(string) Número convertido a binario.
        /// "Valor inválido" si numero contiene letras.</returns>
        public static string DecimalBinario(string numero) {
            double aux;
            if (double.TryParse(numero, out aux))
                return Numero.DecimalBinario(aux);
            else
                return "Valor inválido";
        }


        //////////////////////////////////////////////////////////////////  Operadores


        /// <summary>
        /// Suma objetos de tipo Numero
        /// </summary>
        /// <param name="n1">Sumando</param>
        /// <param name="n2">Sumando</param>
        /// <returns>(double) Resultado</returns>
        public static double operator +(Numero n1, Numero n2) {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Resta objetos de tipo Numero
        /// </summary>
        /// <param name="n1">Minuendo</param>
        /// <param name="n2">Sustraendo</param>
        /// <returns>(double) Resultado</returns>
        public static double operator -(Numero n1, Numero n2) {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Multiplica objetos de tipo Numero
        /// </summary>
        /// <param name="n1">Factor</param>
        /// <param name="n2">Factor</param>
        /// <returns>(double) Resultado</returns>
        public static double operator *(Numero n1, Numero n2) {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Divide objetos de tipo Numero.
        /// Devuelve double.MinValue si el divisor es 0
        /// </summary>
        /// <param name="n1">Dividendo</param>
        /// <param name="n2">Divisor</param>
        /// <returns>(double) Resultado</returns>
        public static double operator /(Numero n1, Numero n2) {
            if (n2.numero == 0)
                return double.MinValue;
            else
                return n1.numero / n2.numero;
        }
    }
}
