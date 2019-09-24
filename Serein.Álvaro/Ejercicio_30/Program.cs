using System;

namespace Ejercicio_30 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Carrera de autos. Creo \"Competencia\" y le agrego \"AutoF1\"s\n");

            Competencia competencia = new Competencia(6, 10);

            Console.WriteLine(competencia.Mostrar());

            if(competencia + new AutoF1(111, "Red Bull")) {
                Console.WriteLine(competencia.Mostrar());
                Console.ReadKey();
                Console.Clear();
            }

            if (competencia + new AutoF1(222, "Ferrari")) {
                Console.WriteLine(competencia.Mostrar());
                Console.ReadKey();
                Console.Clear();
            }

            if (competencia + new AutoF1(333, "McLaren")) {
                Console.WriteLine(competencia.Mostrar());
                Console.ReadKey();
                Console.Clear();
            }

            if (competencia + new AutoF1(444, "Mercedez Benz")) {
                Console.WriteLine(competencia.Mostrar());
                Console.ReadKey();
                Console.Clear();
            }

            AutoF1 a5 = new AutoF1(555, "Williams");
            if (competencia + a5) {
                Console.WriteLine(competencia.Mostrar());
                Console.ReadKey();
                Console.Clear();
            }

            if (competencia + new AutoF1(666, "Lotus")) {
                Console.WriteLine(competencia.Mostrar());
                Console.ReadKey();
                Console.Clear();
            }

            if (competencia - a5) {
                Console.WriteLine(competencia.Mostrar());
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
