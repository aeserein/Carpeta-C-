using System;

namespace Ejercicio_05 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Lee un número positivo. Devuelve todos los números centrales hasta ese número.\n");

            int numero;
            int f, i;
            int acumuladorDePrevios, acumuladorDePosteriores;

            Console.Write("Ingrese un número: ");
            numero = int.Parse(Console.ReadLine());

            while (numero <= 0) {
                Console.WriteLine("ERROR. ¡Reingresar número!");
                numero = int.Parse(Console.ReadLine());
            }

            for (f=2; f<=numero; f++) {

                acumuladorDePrevios = 0;
                acumuladorDePosteriores = 0;

                for (i=1; i<f; i++) {
                    acumuladorDePrevios += i;
                }

                while (acumuladorDePosteriores<acumuladorDePrevios) {

                    i++;
                    acumuladorDePosteriores += i;
                }

                if (acumuladorDePrevios == acumuladorDePosteriores)
                    Console.WriteLine(f);
            }

        }

    }

}
