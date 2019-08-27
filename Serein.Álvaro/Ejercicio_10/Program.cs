using System;

namespace Ejercicio_10 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Imprime una pirámide centrada del tamaño ingresado.\n");
            int tamaño, anchoDeString;
            short f = 1, i, h;

            Console.Write("Ingrese tamaño: ");
            tamaño = int.Parse(Console.ReadLine());

            while (tamaño <= 0) {
                Console.WriteLine("ERROR. ¡Reingresar número!");
                tamaño = int.Parse(Console.ReadLine());
            }
            anchoDeString = (tamaño * 2) - 1;

            for (h=0; h<tamaño; h++) {

                Console.SetCursorPosition((Console.WindowWidth / 2)-(f/2), 5+f);

                for (i = 0; i < f; i++) {
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