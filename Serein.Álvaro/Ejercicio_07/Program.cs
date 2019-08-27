using System;

namespace Ejercicio_07 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Lee una fecha de nacimiento. Devuelve cuántos días vivió es persona hasta hoy.");
            int año, mes, dia;
            int diasDeMes;
            TimeSpan diasEntreFechas;
            DateTime nacimiento, hoy;

            Console.Write("Año (1900-2019):\t\t");
            año = int.Parse(Console.ReadLine());
            while (año < 1900 || año>2019) {
                Console.WriteLine("ERROR. ¡Reingresar año!");
                año = int.Parse(Console.ReadLine());
            }

            Console.Write("Mes (1-12):\t\t");
            mes = int.Parse(Console.ReadLine());
            while (mes<1 || mes>12) {
                Console.WriteLine("ERROR. ¡Reingresar mes!");
                mes = int.Parse(Console.ReadLine());
            }

            switch (mes) {
                case 2 :
                    diasDeMes = 29;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    diasDeMes = 30;
                    break;
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    diasDeMes = 31;
                    break;
                default:
                    diasDeMes = 1;
                    break;
            }

            Console.Write("dia (1-{0}):\t", diasDeMes);
            dia = int.Parse(Console.ReadLine());
            while (dia < 1 || dia> diasDeMes) {
                Console.WriteLine("ERROR. ¡Reingresar día!");
                dia = int.Parse(Console.ReadLine());
            }

            nacimiento = new DateTime(año, mes, dia);
            hoy = DateTime.Now;
            diasEntreFechas = hoy - nacimiento;

            Console.Write("\n" + diasEntreFechas.Days + " días");
            Console.Read();

        }

    }

}
