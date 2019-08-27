using System;

namespace Ejercicio_09 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Imprime una pirámide del tamaño que diga el usuario\n");
            int tamaño;
            short f=1, i;

            Console.Write("Ingrese tamaño: ");
            tamaño = int.Parse(Console.ReadLine());

            while (tamaño <= 0) {
                Console.WriteLine("ERROR. ¡Reingresar número!");
                tamaño = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("\n");

            for ( ; tamaño>0; tamaño--) {
                for (i=0; i<f; i++) {
                    Console.Write("*");
                }
                Console.Write("\n");
                f += 2;
            }

            Console.WriteLine("\n");
            Console.Read();

        }

    }

}
