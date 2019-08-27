using System;

namespace Ejercicio_03 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Lee un número mayor a 1.\nMuestra todos los números primos entre 1 y ese número.\n");
            int numero;
            short f, i;
            bool esPrimo;

            Console.Write("Ingrese un número: ");
            numero = int.Parse(Console.ReadLine());

            while (numero <= 1) {
                Console.WriteLine("ERROR. ¡Reingresar número!");
                numero = int.Parse(Console.ReadLine());
            }

            for (f=2; f<=numero; f++) {

                esPrimo = true;

                for (i=2; i<f-1; i++) {

                    if (f % i == 0) {
                        esPrimo = false;
                        break;
                    }
                }

                if (esPrimo) {
                    Console.WriteLine(f);
                }
            }

        }

    }

}
