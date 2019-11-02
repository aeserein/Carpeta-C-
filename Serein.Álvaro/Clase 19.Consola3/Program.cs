using System;
using Clase_19.Entidades_2;

namespace Clase_19.Consola3 {

    class Program {

        static void Main(string[] args) {

            Auto autoOriginal = new Auto("Donaldo", 69420);
            Auto autoCopiado = new Auto("Macri es comunista", 1917);
            Object obj;

            Console.WriteLine(autoOriginal + "\n" +
                              autoCopiado + "\n\n" + 
                              "----------------------------------------\n\n");

            if (Serializadora.Serializar(autoOriginal))
                Console.WriteLine("Serializado");
            else
                Console.WriteLine("No serializado");

            if (Serializadora.Deserializar(autoCopiado, out obj)) {
                Console.WriteLine("Deserializado");
                autoCopiado = (Auto)obj;
            } else {
                Console.WriteLine("No deserializado");
            }

            Console.WriteLine("\n\n" +
                              autoOriginal + "\n" +
                              autoCopiado + "\n");


        }
    }
}
