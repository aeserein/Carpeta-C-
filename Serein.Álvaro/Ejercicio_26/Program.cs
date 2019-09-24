using System;

namespace Ejercicio_26 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Carga un array con 20 números aleatorios.\n" +
                              "Muestra todos. Muestra los positivos ordenados. Muestra los negativos ordenados.\n");

            Random random = new Random();
            int[] array = new int[20];
            byte f, len;
            len = (byte)array.Length;

            for (f=0; f<len; f++) {
                do {
                    array[f] = random.Next(-1000, 1001);
                } while (array[f] == 0);
            }

            Console.WriteLine("Muestro el array como se cargó");
            foreach (int numero in array) {
                Console.WriteLine("{0, 6}", numero);
            }

            Array.Sort(array);
            Array.Reverse(array);

            Console.WriteLine("\n\nMuestro positivos decreciente");

            for (f=0; f<len; f++) {
                if (array[f] > 0)
                    Console.WriteLine("{0, 6}", array[f]);
                else
                    break;
            }

            Console.WriteLine("\n\nMuestro negativos creciente");

            len--;
            for (/*len*/; len>=f; len--) {
                Console.WriteLine("{0, 6}", array[len]);
            }
        }
    }
}
