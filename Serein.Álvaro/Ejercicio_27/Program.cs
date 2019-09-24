using System;
using System.Collections.Generic;

namespace Ejercicio_27 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Carga 3 colecciones (pila, cola y lista) de números aleatorios.\n" +
                              "Las muestro. Las muestro ordenadas\n");

            #region Stack
            Console.WriteLine("----------- STACK -----------");
            Stack<int> pila = new Stack<int>();
            byte f;

            for (f=0; f<10; f++) {
                pila.Push(f);
            }
            foreach (int i in pila) {
                Console.WriteLine("{0,6}", i);
            }
            #endregion

            #region Queue
            Console.WriteLine("\n----------- QUEUE -----------");
            Queue<int> cola = new Queue<int>();

            for (f = 0; f < 10; f++) {
                cola.Enqueue(f);
            }
            foreach (int i in cola) {
                Console.WriteLine("{0,6}", i);
            }
            #endregion

            #region ArrayList
            Console.WriteLine("\n----------- ARRAYLIST -----------");
            Random random = new Random();
            List<int> lista = new List<int>();
            int aux;
            byte len;

            for (f = 0; f < 10; f++) {
                do {
                    aux = random.Next(-1000, 1001);
                } while (aux == 0);
                lista.Add(aux);
            }

            Console.WriteLine("Muestro el array como se cargó");
            foreach (int numero in lista) {
                Console.WriteLine("{0, 6}", numero);
            }
            len = (byte)lista.Count;

            lista.Sort();
            lista.Reverse();

            Console.WriteLine("\n\nMuestro positivos decreciente");

            for (f = 0; f < len; f++) {
                if (lista[f] > 0)
                    Console.WriteLine("{0, 6}", lista[f]);
                else
                    break;
            }

            Console.WriteLine("\n\nMuestro negativos creciente");

            len--;
            for (/*len*/; len >= f; len--) {
                Console.WriteLine("{0, 6}", lista[len]);
            }
            #endregion
        }
    }
}
