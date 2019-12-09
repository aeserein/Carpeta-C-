using System;

namespace Entidades {

    /// <summary>
    /// Representa un número. Incluye sobrecarga de instancias de Numero
    /// para operaciones básicas y conversiones entre números decimales y binarios.
    /// </summary>
    public class Numero {

        private double numero;

        #region Propiedades
        /// <summary>
        /// Asigna valor al Número, previa validación.
        /// </summary>
        private string SetNumero {
            set {
                this.numero = ValidarNumero(value);
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa el valor del Número en 0.
        /// </summary>
        public Numero() : this(0) {
        }

        /// <summary>
        /// Inicializa el valor del Número.
        /// </summary>
        /// <param name="numero">Número a asignar.</param>
        public Numero(double numero) : this(numero.ToString()) {
        }

        /// <summary>
        /// Inicializa el valor del Número.
        /// </summary>
        /// <param name="strNumero">Número a asignar.</param>
        public Numero(string strNumero) {
            this.SetNumero = strNumero;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Comprueba que el valor recibido sea numérico y lo retorna.
        /// </summary>
        /// <param name="strNumero">Cadena de caracteres que representa un número a validar.</param>
        /// <returns>El número original si es válido, o 0 si es inválido.</returns>
        private double ValidarNumero(string strNumero) {
            double aux = 0;
            double.TryParse(strNumero, out aux);
            return aux;
        }
        
        /// <summary>
        /// Convierte un número binario a decimal.
        /// </summary>
        /// <param name="binario">Cadena de caracteres que representa el número en sistema binario.</param>
        /// <returns>El número decimal como cadena de caracteres, o "Valor inválido" si no se pudo convertir.</returns>
        public static string BinarioDecimal(string binario) {
            if (binario == "")
                return "Valor inválido";

            for (byte f = 0; f < binario.Length; f++) {
                if (binario[f] != '0' && binario[f] != '1')
                    return "Valor inválido";
            }

            string aux;
            aux = Convert.ToInt32(binario, 2).ToString();
            return aux;
        }

        /// <summary>
        /// Convierte un número decimal a binario. Solo convierte el valor entero y absoluto.
        /// </summary>
        /// <param name="numero">Número a convertir.</param>
        /// <returns>Cadena de caracteres que representa el número en sistema binario, o "Valor inválido" si no se pudo convertir.</returns>
        public static string DecimalBinario(double numero) {

            long parteEntera = (long)numero;
            parteEntera = Math.Abs(parteEntera);

            return Convert.ToString(parteEntera, 2);
        }

        /// <summary>
        /// Convierte un número decimal a binario. Solo convierte el valor entero y absoluto.
        /// </summary>
        /// <param name="numero">Cadena de caracteres que representa el número a convertir.</param>
        /// <returns>Cadena de caracteres que representa el número en sistema binario, o "Valor inválido" si no se pudo convertir.</returns>
        public static string DecimalBinario(string numero) {
            double aux;
            if (double.TryParse(numero, out aux))
                return Numero.DecimalBinario(aux);
            else
                return "Valor inválido";
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Suma dos Números.
        /// </summary>
        /// <param name="n1">Número a sumar.</param>
        /// <param name="n2">Número a sumar.</param>
        /// <returns>Resultado de la suma.</returns>
        public static double operator +(Numero n1, Numero n2) {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Resta dos Números.
        /// </summary>
        /// <param name="n1">Minuendo.</param>
        /// <param name="n2">Sustraendo.</param>
        /// <returns>Resultado de la resta.</returns>
        public static double operator -(Numero n1, Numero n2) {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Multiplica dos Números.
        /// </summary>
        /// <param name="n1">Número a multiplicar.</param>
        /// <param name="n2">Número a multiplicar.</param>
        /// <returns>Resultado de la multiplicación.</returns>
        public static double operator *(Numero n1, Numero n2) {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Divide dos Números.
        /// </summary>
        /// <param name="n1">Dividendo.</param>
        /// <param name="n2">Divisor</param>
        /// <returns>Resultado de la división.</returns>
        public static double operator /(Numero n1, Numero n2) {
            if (n2.numero == 0)
                return double.MinValue;
            else
                return n1.numero / n2.numero;
        }
        #endregion
    }
}
