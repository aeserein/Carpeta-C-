using System;
using Ejercicio_13_lib;

namespace Ejercicio_22 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Números binarios y decimales. Conversiones y sobrecargas de operadores.\n");

            NumeroDecimal dec;
            NumeroBinario bin;
            string resString;
            double resDouble;

            dec = 15;
            bin = "000001101";   // 13

            Console.WriteLine("Decimal: {0}\nBinario: {1}", dec.GetNumero(), bin.GetNumero());
            Console.WriteLine("Son iguales? " + (bin == dec));

            resString = bin + dec;
            resDouble = dec + bin;

            Console.WriteLine("Suma decimal: " + resDouble);
            Console.WriteLine("Suma binario: " + resString);

            dec = 18;
            bin = "00010010";

            Console.WriteLine("Decimal: {0}\nBinario: {1}", dec.GetNumero(), bin.GetNumero());
            Console.WriteLine("Son iguales? " + (bin == dec));

            dec = 10;

            Console.WriteLine("Decimal: {0}\nBinario: {1}", dec.GetNumero(), bin.GetNumero());
            Console.WriteLine("Son iguales? " + (bin == dec));

            resString = bin - dec;
            resDouble = dec - bin;

            Console.WriteLine("Suma decimal: " + resDouble);
            Console.WriteLine("Suma binario: " + resString);
        }

    }

}
