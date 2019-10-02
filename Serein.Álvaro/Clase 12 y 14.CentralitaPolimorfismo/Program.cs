using System;

namespace Clase_12.CentralitaPolimorfismo {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Centralita\n");

            Centralita telefonica = new Centralita("Telefónica");

            Llamada l1 = new Local("1111", "2222", 30, (float)2.65);
            Llamada l2 = new Provincial("3333", "4444", 21, Franja.Franja_1);
            Llamada l3 = new Local("5555", "6666", 45, (float)1.99);
            Llamada l4 = new Provincial(l2, Franja.Franja_3);

            telefonica += l1;
            telefonica += l2;
            telefonica += l3;
            telefonica += l4;

            Console.WriteLine(telefonica.ToString());

            telefonica.OrdenarLlamadas();
            Console.WriteLine(telefonica.ToString());
        }
    }
}
