using System;

namespace Ejercicio_01 {

    class Program {

        static void Main(string[] args) {

            short f;
            int numero;
            int min = int.MaxValue;
            int max = int.MinValue;
            int acumulador = 0;
            float promedio;

            Console.WriteLine("Lee 5 números. Devuelve promedio, mayor y menor\n");

            for (f=0; f<5; f++) {

                Console.Write("N{0}: ", f+1);
                numero = int.Parse(Console.ReadLine());

                if (numero > max) max = numero;
                if (numero < min) min = numero;
                acumulador += numero;

            }
            promedio = (float)acumulador / f;

            Console.Write("\nMínimo: {0}\nMáximo: {1}\nPromedio: {2}", min, max, promedio);
            Console.Read();
        }
    }
}
