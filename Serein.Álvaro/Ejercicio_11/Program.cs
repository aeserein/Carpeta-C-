using System;
using lib_numeros;

namespace Ejercicio_11 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Lee 10 números. Valida entre -100 y 100.\n" +
                              "Devuelve máximo, mínimo y promedio.\n");
            int numero;
            int max = int.MinValue;
            int min = int.MaxValue;
            float promedio;
            int aNumeros=0;
            byte f;

            for (f=0; f<10; f++) {

                do {
                    Console.Write("Número {0}:\t", f+1);
                    numero = int.Parse(Console.ReadLine());
                } while (!Validacion.Validar(numero, -100, 100));

                aNumeros += numero;
                if (numero > max) max = numero;
                if (numero < min) min = numero;
            }

            promedio = (float)aNumeros / f;
            
            Console.WriteLine("\nMáximo:   " + max);
            Console.WriteLine("Mínimo:   " + min);
            Console.WriteLine("Promedio: " + promedio);
        }

    }

}
