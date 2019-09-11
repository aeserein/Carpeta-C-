using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades {

    public static class Calculadora {

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

        private static string ValidarOperador(string operador) {
            if(operador=="+" || operador=="-" ||
               operador=="*" || operador=="/") {
                return operador;
            } else {
                return "+";
            }
        }
    }
}