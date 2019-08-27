using System;

namespace Ejercicio_14 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Calcula áreas de cuadrado, triángulo y círculo.\n");
            int opcion;
            int numero, otroNumero;

            do {
                Console.WriteLine("1. Área de cuadrado\n" +
                                  "2. Área de triángulo\n" +
                                  "3. Área de círculo\n" +
                                  "   ------------------------\n" +
                                  "4. Salir\n\n");

                opcion = (int)(Console.ReadKey(true).KeyChar)-48;

                switch (opcion) {
                    case 1 : {
                        Console.Write("   CUADRADO\n" +
                                      "   Lado: ");
                        numero = int.Parse(Console.ReadLine());

                        Console.Write("\n   Área: {0}", numero*numero);
                        break;
                    }
                    case 2: {
                        Console.Write("   TRIÁNGULO\n" +
                                      "   Base: ");
                        numero = int.Parse(Console.ReadLine());
                        Console.Write("   Altura: ");
                        otroNumero = int.Parse(Console.ReadLine());

                        Console.Write("\n   Área: {0}", numero*otroNumero/2);
                        break;
                    }
                    case 3: {
                        Console.Write("   CÍRCULO\n" +
                                      "   Radio: ");
                        numero = int.Parse(Console.ReadLine());

                        Console.Write("\n   Área: {0}", Math.PI*(numero*numero));
                        break;
                    }
                    default : break;
                }

                Console.ReadKey();
                Console.Clear();

            } while (opcion != 4);


        }

    }

}
