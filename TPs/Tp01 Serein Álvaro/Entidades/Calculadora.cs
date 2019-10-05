using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades {

    /// <summary>
    /// Calculadora de Operaciones básicas. No requiere instanciación..
    /// </summary>
    public static class Calculadora {

        /// <summary>
        /// Realiza la operación entre las dos instancias de Numero. Si el operador es inválido, suma los parámetros.
        /// </summary>
        /// <param name="num1">Operando</param>
        /// <param name="num2">Operando</param>
        /// <param name="operador">(double) Resultado</param>
        /// <returns></returns>
        public static double Operar(Numero num1, Numero num2, string operador) {
            operador = ValidarOperador(operador);
            double resultado;
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
                default:
                    resultado = double.MinValue;
                    break;
            }
            return resultado;
        }

        /// <summary>
        /// Valida operador entre "+", "-", "*" o "/"
        /// </summary>
        /// <param name="operador">Operador</param>
        /// <returns>(string) Mismo operador si es válido. "+" si no lo es.</returns>
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