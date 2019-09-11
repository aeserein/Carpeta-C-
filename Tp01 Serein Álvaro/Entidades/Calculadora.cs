using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades {

    public static class Calculadora {

        public static double Operar(Numero num1, Numero num2, string operador) {
            operador = ValidarOperador(operador);
            switch(operador) {
                case "+":
            }
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