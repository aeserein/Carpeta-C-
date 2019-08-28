using System;

namespace Ejercicio_15 {

    class Program {

        static void Main(string[] args) {

            int n1, n2;
            char operacion;
            float resultado;
            char respuesta;

            do {

                Console.Clear();

                Console.WriteLine("Mini calculadora\n");

                Console.Write("       N1: ");
                n1 = int.Parse(Console.ReadLine());

                do {
                    Console.Write("Operación: ");
                    operacion = Console.ReadKey().KeyChar;
                } while (operacion != '+' && operacion != '-' && operacion != '*' && operacion != '/');

                Console.Write("\n       N2: ");
                n2 = int.Parse(Console.ReadLine());

                resultado = Calculadora.Calcular(n1, operacion, n2);
                if (!float.IsNaN(resultado)) {
                    Console.WriteLine("\nResultado: " + resultado + "\n");
                } else {
                    Console.WriteLine("\nERROR\n");
                }

                Console.Write("¿Continuar? S/N ");
                respuesta = Console.ReadKey().KeyChar;
                Console.Write("\n");

            } while (lib_flow.ValidarRespuesta.ValidaS_N(respuesta));
        }

    }

    class Calculadora {

        public static float Calcular (float n1, char operacion, float n2) {

            switch (operacion) {
                case '+':
                    return n1 + n2;
                case '-':
                    return n1 - n2;
                case '*':
                    return n1 * n2;
                case '/': {
                    if (Validar(n2)) {
                        return n1 / n2;
                    } else {
                        return float.NaN;
                    }
                }
                default:
                    return float.NaN;
            }
        }
        
        private static bool Validar (float numero) {
            return (numero != 0);
        }
    }
}
