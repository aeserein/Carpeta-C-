using System;

namespace Ejercicio_33 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Un libro. Le sumo páginas con un indexador y las imprimo.\n");

            Libro libro = new Libro();
            int f;

            libro[int.MaxValue] = "Pag 1";
            libro[int.MaxValue] = "Pag 2";
            libro[int.MaxValue] = "Pag 3";
            libro[int.MaxValue] = "Pag 4";
            libro[int.MaxValue] = "Pag 5";
            libro[int.MaxValue] = "Pag 6";
            libro[int.MaxValue] = "Pag 7";

            for(f=0; f<10; f++) {
                Console.WriteLine(libro[f]);
            }

            libro[4] = "Página modificada";
            libro[-1] = "Página que no debería agregar";

            for (f=0; f< 10; f++) {
                Console.WriteLine(libro[f]);
            }
        }
    }
}
