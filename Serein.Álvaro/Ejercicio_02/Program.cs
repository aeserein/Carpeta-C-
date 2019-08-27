using System;

namespace Ejercicio_02 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Lee un número mayor a 0. Calcula el cuadrado y el cubo del mismo.\n");

            int numero;
            double cuadrado, cubo;

            Console.Write("Ingrese un número: ");
            numero = int.Parse(Console.ReadLine());

            while (numero<=0) {
                Console.WriteLine("ERROR. ¡Reingresar número!");
                numero = int.Parse(Console.ReadLine());
            }

            cuadrado = Math.Pow(numero, 2);
            cubo = Math.Pow(numero, 3);

            Console.WriteLine("\nCuadrado: " + cuadrado + "");
            Console.WriteLine("Cubo: " + cubo + "\n");

            Console.Read();

        }
    }
}
