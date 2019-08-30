using System;

namespace Billetes {

    class Program {

        static void Main(string[] args) {

            Peso pesos = new Peso(50);
            Dolar dolares = new Dolar(10);
            Euro euros = new Euro(5);
            double unDoble = 2;

            Dolar resultadoDolar;
            Euro resultadoEuro;
            Peso resultadoPeso;

            resultadoDolar = dolares + pesos;
            Console.WriteLine("Resultado dolar: {0}", resultadoDolar.GetCantidad());
            resultadoDolar = resultadoDolar + euros;
            Console.WriteLine("Plata total (50 pesos + 10 dólares + 5 euros): {0} dólares", resultadoDolar.GetCantidad());
            resultadoEuro = (Euro)dolares + pesos;
            Console.WriteLine("10 dólares + 50 pesos: {0} euros", resultadoEuro.GetCantidad());
            resultadoPeso = pesos + euros;
            Console.WriteLine("50 pesos + 5 euros: {0} pesos", resultadoPeso.GetCantidad());
        }

    }

    class Euro {

        private double cantidad;
        private static double cotizRespectoDolar;

        /////////////////////////////////////////////////////

        static Euro() {
            cotizRespectoDolar = 1.16;
        }
        public Euro(double cantidad) {
            this.cantidad = cantidad;
        }
        public Euro(double cantidad, double cotizacion) {
            this.cantidad = cantidad;
            Euro.cotizRespectoDolar = cotizacion;
        }

        /////////////////////////////////////////////////////

        public double GetCantidad() {
            return this.cantidad;
        }
        public static double GetCotizacion() {
            return Euro.cotizRespectoDolar;
        }

        /////////////////////////////////////////////////////

        public static implicit operator Euro(double d) {
            return new Euro(d);
        }
        public static explicit operator Dolar(Euro p) {
            return new Dolar(p.GetCantidad() * Euro.GetCotizacion());
        }
        public static explicit operator Peso(Euro p) {
            return new Peso(p.GetCantidad() * Euro.GetCotizacion() / Peso.GetCotizacion());
        }

        /////////////////////////////////////////////////////

        public static bool operator ==(Euro e1, Euro e2) {
            return (e1.GetCantidad() == e2.GetCantidad());
        }
        public static bool operator ==(Euro e, Peso p) {
            return (e.GetCantidad() == p.GetCantidad());
        }
        public static bool operator ==(Euro e, Dolar d) {
            return (e.GetCantidad() == d.GetCantidad());
        }

        public static bool operator !=(Euro e1, Euro e2) {
            return (e1.GetCantidad() == e2.GetCantidad());
        }
        public static bool operator !=(Euro e, Peso p) {
            return (e.GetCantidad() != p.GetCantidad());
        }
        public static bool operator !=(Euro e, Dolar d) {
            return (e.GetCantidad() != e.GetCantidad());
        }

        public static Euro operator +(Euro e, Peso p) {
            return e.GetCantidad() + (p.GetCantidad() * Peso.GetCotizacion() / Euro.GetCotizacion());
        }
        public static Euro operator +(Euro e, Dolar d) {
            return e.GetCantidad() + (d.GetCantidad() / Euro.GetCotizacion());
        }
        public static Euro operator -(Euro e, Peso p) {
            return e.GetCantidad() - (p.GetCantidad() * Peso.GetCotizacion() / Euro.GetCotizacion());
        }
        public static Euro operator -(Euro e, Dolar d) {
            return e.GetCantidad() - (d.GetCantidad() / Euro.GetCotizacion());
        }

    }


    class Dolar {

        private double cantidad;
        private static double cotizRespectoDolar;

        static Dolar() {
            cotizRespectoDolar = 1;
        }
        public Dolar(double cantidad) {
            this.cantidad = cantidad;
        }
        public Dolar(double cantidad, double cotizacion) {
            this.cantidad = cantidad;
            Dolar.cotizRespectoDolar = cotizacion;
        }

        /////////////////////////////////////////////////////

        public double GetCantidad() {
            return this.cantidad;
        }
        public static double GetCotizacion() {
            return Dolar.cotizRespectoDolar;
        }

        /////////////////////////////////////////////////////

        public static implicit operator Dolar(double d) {
            return new Dolar(d);
        }
        public static explicit operator Peso(Dolar p) {
            return new Peso(p.GetCantidad() / Peso.GetCotizacion());
        }
        public static explicit operator Euro(Dolar p) {
            return new Euro(p.GetCantidad() / Euro.GetCotizacion());
        }

        /////////////////////////////////////////////////////

        public static bool operator ==(Dolar d1, Dolar d2) {
            return (d1.GetCantidad() == d2.GetCantidad());
        }
        public static bool operator ==(Dolar d, Peso p) {
            return (d.GetCantidad() == p.GetCantidad());
        }
        public static bool operator ==(Dolar d, Euro e) {
            return (d.GetCantidad() == e.GetCantidad());
        }

        public static bool operator !=(Dolar d1, Dolar d2) {
            return (d1.GetCantidad() == d2.GetCantidad());
        }
        public static bool operator !=(Dolar d, Peso p) {
            return (d.GetCantidad() != p.GetCantidad());
        }
        public static bool operator !=(Dolar d, Euro e) {
            return (d.GetCantidad() != e.GetCantidad());
        }

        /////////////////////////////////////////////////////

        public static Dolar operator +(Dolar d, Peso p) {
            return d.GetCantidad() + (p.GetCantidad()*Peso.GetCotizacion());
        }
        public static Dolar operator +(Dolar d, Euro e) {
            return d.GetCantidad() + (e.GetCantidad()*Euro.GetCotizacion());
        }
        public static Dolar operator -(Dolar d, Peso p) {
            return d.GetCantidad() - (p.GetCantidad() * Peso.GetCotizacion());
        }
        public static Dolar operator -(Dolar d, Euro e) {
            return d.GetCantidad() - (e.GetCantidad() * Euro.GetCotizacion());
        }
    }


    class Peso {

        private double cantidad;
        private static double cotizRespectoDolar;

        /////////////////////////////////////////////////////

        static Peso() {
            cotizRespectoDolar = 0.026089226;
        }
        public Peso(double cantidad) {
            this.cantidad = cantidad;
        }
        public Peso(double cantidad, double cotizacion) {
            this.cantidad = cantidad;
            Peso.cotizRespectoDolar = cotizacion;
        }

        /////////////////////////////////////////////////////

        public double GetCantidad() {
            return this.cantidad;
        }
        public static double GetCotizacion() {
            return Peso.cotizRespectoDolar;
        }

        /////////////////////////////////////////////////////

        public static implicit operator Peso(double d) {
            return new Peso(d);
        }
        public static explicit operator Dolar(Peso p) {
            return new Dolar(p.GetCantidad() * Peso.GetCotizacion());
        }
        public static explicit operator Euro(Peso p) {
            return new Euro (p.GetCantidad() * Peso.GetCotizacion() / Euro.GetCotizacion());
        }

        /////////////////////////////////////////////////////
        
        public static bool operator ==(Peso p1, Peso p2) {
            return (p1.GetCantidad() == p2.GetCantidad());
        }
        public static bool operator ==(Peso p, Dolar d) {
            return (p.GetCantidad() == d.GetCantidad());
        }
        public static bool operator ==(Peso p, Euro e) {
            return (p.GetCantidad() == e.GetCantidad());
        }

        public static bool operator !=(Peso p1, Peso p2) {
            return (p1.GetCantidad() == p2.GetCantidad());
        }
        public static bool operator !=(Peso p, Dolar d) {
            return (p.GetCantidad() != d.GetCantidad());
        }
        public static bool operator !=(Peso p, Euro e) {
            return (p.GetCantidad() != e.GetCantidad());
        }

        public static Peso operator +(Peso p, Dolar d) {
            return p.GetCantidad() + (d.GetCantidad() / Peso.GetCotizacion());
        }
        public static Peso operator +(Peso p, Euro e) {
            return p.GetCantidad() + (e.GetCantidad() * Euro.GetCotizacion() / Peso.GetCotizacion());
        }
        public static Peso operator -(Peso p, Dolar d) {
            return p.GetCantidad() - (d.GetCantidad() / Peso.GetCotizacion());
        }
        public static Peso operator -(Peso p, Euro e) {
            return p.GetCantidad() - (e.GetCantidad() * Euro.GetCotizacion() / Peso.GetCotizacion());
        }
    }

}


/* PREGUNTAS
    Falta conversor de suma para sumar de cantidades de la misma moneda?
    Tengo que calcular la conversion en los casteos y tambien en las conversiones de las operaciones?
    No puedo castear dentro de la operacion + para no recalcular lo mismo?
    Los warnings de sobre la sobrecarga de metodos de object
    */