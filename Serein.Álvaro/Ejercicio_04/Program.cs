using System;

namespace Ejercicio_04 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Calcula los primeros cuatro números naturales perfectos");

            long f = 2;
            int i;
            int acumulador;
            Byte numerosPerfectosEncontrados = 0;

            while (numerosPerfectosEncontrados<5) {


                acumulador = 0;

                for (i=1; i<f; i++) {

                    if (f % i == 0) {
                        acumulador += i;
                    }
                }

                if (acumulador==f) Console.WriteLine(f);
                f++;

            }

        }

    }

}
