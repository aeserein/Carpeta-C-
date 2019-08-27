using System;

namespace Ejercicio_06 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Lee dos años. Imprime los años bisiestos entre ellos.\n");

            int añoMin, añoMax, aux;

            Console.Write("Ingrese un año: ");
            añoMin = int.Parse(Console.ReadLine());

            while (añoMin <= 0) {
                Console.WriteLine("ERROR. ¡Reingresar año!");
                añoMin = int.Parse(Console.ReadLine());
            }

            Console.Write("Ingrese otro año: ");
            añoMax = int.Parse(Console.ReadLine());

            while (añoMax <= 0) {
                Console.WriteLine("ERROR. ¡Reingresar año!");
                añoMax = int.Parse(Console.ReadLine());
            }

            if (añoMax<añoMin) {
                aux = añoMax;
                añoMax = añoMin;
                añoMin = aux;
            }

            while (añoMin<=añoMax) {

                if ((añoMin % 4 == 0 && añoMin % 100 != 0) || (añoMin % 100 == 0 && añoMin % 400 == 0))
                    Console.WriteLine(añoMin);
                añoMin++;
            }
        }

    }

}
