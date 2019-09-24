using System;

namespace Ejercicio_36 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Carrera de autos y motos." +
                              "Creo 2 \"Competencia\" y le agrego \"AutoF1\"s y \"MotoCross\"s\n");

            #region Competencia F1
            Competencia competenciaF1 = new Competencia(6, 10, Competencia.TipoCompetencia.F1);

            Console.WriteLine(competenciaF1.Mostrar());

            if(competenciaF1 + new AutoF1(111, "Red Bull", 1000)) {
                Console.WriteLine(competenciaF1.Mostrar());
                Console.ReadKey();
                Console.Clear();
            }

            if (competenciaF1 + new AutoF1(222, "Ferrari", 1000)) {
                Console.WriteLine(competenciaF1.Mostrar());
                Console.ReadKey();
                Console.Clear();
            }

            if (competenciaF1 + new AutoF1(333, "McLaren", 1000)) {
                Console.WriteLine(competenciaF1.Mostrar());
                Console.ReadKey();
                Console.Clear();
            }

            if (competenciaF1 + new AutoF1(444, "Mercedez Benz", 1000)) {
                Console.WriteLine(competenciaF1.Mostrar());
                Console.ReadKey();
                Console.Clear();
            }

            AutoF1 a5 = new AutoF1(555, "Williams", 1000);
            if (competenciaF1 + a5) {
                Console.WriteLine(competenciaF1.Mostrar());
                Console.ReadKey();
                Console.Clear();
            }

            if (competenciaF1 + new AutoF1(666, "Lotus", 1000)) {
                Console.WriteLine(competenciaF1.Mostrar());
                Console.ReadKey();
                Console.Clear();
            }

            if (competenciaF1 - a5) {
                Console.WriteLine(competenciaF1.Mostrar());
                Console.ReadKey();
                Console.Clear();
            }

            MotoCross motoPrueba = new MotoCross(111, "Yamaha", 700);
            if (competenciaF1 + motoPrueba) {
                Console.WriteLine(competenciaF1.Mostrar());
                Console.ReadKey();
                Console.Clear();
            }
            #endregion

            #region Competencia MotoCross
            Competencia competenciaMoto = new Competencia(6, 10, Competencia.TipoCompetencia.MotoCross);

            Console.WriteLine(competenciaMoto.Mostrar());

            if (competenciaMoto + new MotoCross(111, "Yamaha", 700)) {
                Console.WriteLine(competenciaMoto.Mostrar());
                Console.ReadKey();
                Console.Clear();
            }

            if (competenciaMoto + new MotoCross(222, "Aprilia", 700)) {
                Console.WriteLine(competenciaMoto.Mostrar());
                Console.ReadKey();
                Console.Clear();
            }

            if (competenciaMoto + new MotoCross(333, "McLaren", 700)) {
                Console.WriteLine(competenciaMoto.Mostrar());
                Console.ReadKey();
                Console.Clear();
            }

            if (competenciaMoto + new MotoCross(444, "Kawasaki", 700)) {
                Console.WriteLine(competenciaMoto.Mostrar());
                Console.ReadKey();
                Console.Clear();
            }

            MotoCross m5 = new MotoCross(555, "Suzuki", 700);
            if (competenciaMoto + m5) {
                Console.WriteLine(competenciaMoto.Mostrar());
                Console.ReadKey();
                Console.Clear();
            }

            if (competenciaMoto + new MotoCross(666, "Honda", 700)) {
                Console.WriteLine(competenciaMoto.Mostrar());
                Console.ReadKey();
                Console.Clear();
            }

            if (competenciaMoto - m5) {
                Console.WriteLine(competenciaMoto.Mostrar());
                Console.ReadKey();
                Console.Clear();
            }

            AutoF1 autoPrueba = new AutoF1(111, "Renault", 1000);
            if (competenciaMoto + autoPrueba) {
                Console.WriteLine(competenciaMoto.Mostrar());
                Console.ReadKey();
                Console.Clear();
            }
            #endregion
        }
    }
}
