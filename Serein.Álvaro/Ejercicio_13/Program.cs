using System;
using Ejercicio_13_lib;

namespace Ejercicio_13 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Lee un número. Lo pasa de decimal a binario y de vuelta a decimal.\n");
            int numero;
            string numeroEnBinario;
            double numeroEnDecimal;

            Console.Write("Ingrese número: ");
            numero = int.Parse(Console.ReadLine());

            numeroEnBinario = Conversor.DecimalABinario(numero);
            Console.WriteLine("\nNúmero en binario: " + numeroEnBinario);

            numeroEnDecimal = Conversor.BinarioADecimal(numeroEnBinario);
            Console.WriteLine("Número en decimal: " + numeroEnDecimal);

        }

    }

}
