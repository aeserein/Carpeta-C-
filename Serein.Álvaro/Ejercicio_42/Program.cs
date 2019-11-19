using System;

namespace Ejercicio_42 {

    class Program  {


        private Program(int n, int m) {

            Console.WriteLine("En primer constructor");
            try {
                Program.DividirPorCero(n);
            } catch (DivideByZeroException e) {
                throw e;
            }
        }

        private Program(int n) {
            Console.WriteLine("En segundo constructor");

            try {
                new Program(n, n);
            } catch (DivideByZeroException e) {
                UnaException ue = new UnaException(e);

                throw ue;
            }
        }

        private Program() {
        }



        static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            Program test = new Program();
            try {
                test.AgarradorDeExcepcion(5);
            } catch (MiException e) {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException.Message);
                Console.WriteLine(e.InnerException.InnerException.Message);
            }
        }

        static private int DividirPorCero(int n) {
            Console.WriteLine("En Método DividirPorCero");
            throw new DivideByZeroException();
        }

        private void AgarradorDeExcepcion(int n) {
            Console.WriteLine("En AgarradorDeExcepción");
            try {
                Program test = new Program(n);
            } catch (UnaException e) {
                MiException me = new MiException(e);
                throw me;
            }
        }



        public class MiException : Exception {

            public MiException(Exception e)
                : base("MiException", e) {
            }
        }

        public class UnaException : Exception {

            public UnaException(Exception e)
                : base("UnaException", e) {
            }
        }
    }
}
