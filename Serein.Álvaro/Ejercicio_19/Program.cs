using System;

namespace Ejercicio_19 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Sumador con sobrecarga de constructores y métodos\n");

            Sumador sumador = new Sumador();

            int n1 = 2;
            int n2 = 5;
            int resultado;
            string s1 = "Vote por ";
            string s2 = "El Donaldo";
            string resultadoString;

            resultado = (int)sumador.Sumar(n1, n2);
            resultadoString = sumador.Sumar(s1, s2);

            Console.WriteLine(resultado + " - " + resultadoString + "\n");

            Sumador otroSumador = new Sumador(2);
            Console.WriteLine("Test conversor explícito de Sumador a int:\n" +
                              (int)otroSumador + " + " + 5 + " = " + ((int)otroSumador+5));
            Console.WriteLine("Test conversor explícito de +:\n" +
                               sumador + " + " + otroSumador + " = " + (sumador+otroSumador));
            Console.WriteLine("Test conversor explícito de |:\n" +
                              (sumador|otroSumador));
        }

    }

    class Sumador {

        private int cantidadDeSumas;

        ///////////////////////////////////////////////////////

        public Sumador(int cantidadDeSumas) {
            this.cantidadDeSumas = cantidadDeSumas;
        }
        public Sumador() {
            new Sumador(0);
        }

        ///////////////////////////////////////////////////////

        public static explicit operator int(Sumador s) {
            return s.cantidadDeSumas;
        }

        public static long operator +(Sumador s1, Sumador s2) {
            return (int)s1 + (int)s2;
        }
        public static bool operator |(Sumador s1, Sumador s2) {
            return (s1.cantidadDeSumas == s2.cantidadDeSumas);
        }

        ///////////////////////////////////////////////////////

        public long Sumar(long n1, long n2) {
            this.cantidadDeSumas++;
            return n1 + n2;
        }
        public string Sumar(string s1, string s2) {
            this.cantidadDeSumas++;
            return s1 + s2;
        }
    }

}
