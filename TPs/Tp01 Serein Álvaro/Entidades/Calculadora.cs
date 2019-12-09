using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades {

    /// <summary>
    /// Calculadora de Operaciones básicas. No requiere instanciación..
    /// </summary>
    public static class Calculadora {

        /// <summary>
        /// Realiza la operación, luego de verificar el operador.
        /// </summary>
        /// <param name="num1">Primer Número a operar.</param>
        /// <param name="num2">Segundo Número a operar.</param>
        /// <param name="operador">Operación a realizar.</param>
        /// <returns>Resultado de la operación.</returns>
        public static double Operar(Numero num1, Numero num2, string operador) {
            operador = Calculadora.ValidarOperador(operador);
            double resultado = 0;
            switch(operador) {
                case "+": {
                    resultado = num1 + num2;
                    break;
                }
                case "-": {
                    resultado = num1 - num2;
                    break;
                }
                case "*": {
                    resultado = num1 * num2;
                    break;
                }                    
                case "/": {
                    resultado = num1 / num2;
                    break;
                }
                default: {
                    break;
                }
            }
            return resultado;
        }

        /// <summary>
        /// Valida el operador.
        /// </summary>
        /// <param name="operador">Cadena de caracteres que representa el operador.</param>
        /// <returns>El operador original si es válido, o el de suma si es inválido.</returns>
        private static string ValidarOperador(string operador) {
            if (operador=="+" || operador=="-" ||
                operador=="*" || operador=="/") {
                return operador;
            } else {
                return "+";
            }
        }
    }
}