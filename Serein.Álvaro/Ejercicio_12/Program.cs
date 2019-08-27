using System;
using lib_flow;

namespace Ejercicio_12 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Lee números hasta que decide el usuario. Devuelve la suma de ellos.");
            int numero, aNumero = 0;
            char respuesta;

            do {

                Console.Write("\nIngresar número: ");
                numero = int.Parse(Console.ReadLine());
                aNumero += numero;

                Console.Write("¿Continuar? S/N ");
                respuesta = Console.ReadKey().KeyChar;
                Console.Write("\n");

            } while (ValidarRespuesta.ValidaS_N(respuesta));

            Console.WriteLine("\nSuma de todos los números: " + aNumero);
        }

    }

}