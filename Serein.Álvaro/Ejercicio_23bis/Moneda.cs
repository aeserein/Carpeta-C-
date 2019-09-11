using System;

namespace Moneda {

    public class Euro {

        private double cantidad;
        private static double cotizRespectoDolar;

        /////////////////////////////////////////////////////

        static Euro() {
            cotizRespectoDolar = 1.16;
        }
        public Euro(double cantidad) {
            this.cantidad = cantidad;
        }
        public Euro(double cantidad, double cotizacion) : this(cantidad) {
            Euro.cotizRespectoDolar = cotizacion;
        }

        /////////////////////////////////////////////////////

        public double GetCantidad() {
            return this.cantidad;
        }
        public static double GetCotizacion() {
            return Euro.cotizRespectoDolar;
        }
        public static void SetCotizacion(double d) {
            Euro.cotizRespectoDolar = d;
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

        public static implicit operator string(Euro e) {
            return e.GetCantidad().ToString();
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
            return !(e1 == e2);
        }
        public static bool operator !=(Euro e, Peso p) {
            return !(e == p);
        }
        public static bool operator !=(Euro e, Dolar d) {
            return !(e == d);
        }

        /////////////////////////////////////////////////////

        public static Euro operator +(Euro e1, Euro e2) {
            return e1.GetCantidad() + e2.GetCantidad();
        }
        public static Euro operator +(Euro e, Peso p) {
            return e + (Euro)p;
        }
        public static Euro operator +(Euro e, Dolar d) {
            return e + (Euro)d;
        }

        public static Euro operator -(Euro e1, Euro e2) {
            return e1.GetCantidad() - e2.GetCantidad();
        }
        public static Euro operator -(Euro e, Peso p) {
            return e - (Euro)p;
        }
        public static Euro operator -(Euro e, Dolar d) {
            return e - (Euro)d;
        }

    }


    public class Dolar {

        private double cantidad;
        private static double cotizRespectoDolar;

        static Dolar() {
            cotizRespectoDolar = 1;
        }
        public Dolar(double cantidad) {
            this.cantidad = cantidad;
        }
        public Dolar(double cantidad, double cotizacion) : this(cantidad) {
            Dolar.cotizRespectoDolar = cotizacion;
        }

        /////////////////////////////////////////////////////

        public double GetCantidad() {
            return this.cantidad;
        }
        public static double GetCotizacion() {
            return Dolar.cotizRespectoDolar;
        }
        public static void SetCotizacion(double d) {
            Dolar.cotizRespectoDolar = d;
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
        public static implicit operator string(Dolar d) {
            return d.GetCantidad().ToString();
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
            return !(d1 == d2);
        }
        public static bool operator !=(Dolar d, Peso p) {
            return !(d == p);
        }
        public static bool operator !=(Dolar d, Euro e) {
            return !(d == e);
        }

        /////////////////////////////////////////////////////

        public static Dolar operator +(Dolar d1, Dolar d2) {
            return d1.GetCantidad() + d2.GetCantidad();
        }
        public static Dolar operator +(Dolar d, Peso p) {
            return d + (Dolar)p.GetCantidad();
        }
        public static Dolar operator +(Dolar d, Euro e) {
            return d + (Dolar)e;
        }

        public static Dolar operator -(Dolar d1, Dolar d2) {
            return d1.GetCantidad() - d2.GetCantidad();
        }
        public static Dolar operator -(Dolar d, Peso p) {
            return d - (Dolar)p;
        }
        public static Dolar operator -(Dolar d, Euro e) {
            return d - (Dolar)e;
        }
    }


    public class Peso {

        private double cantidad;
        private static double cotizRespectoDolar;

        /////////////////////////////////////////////////////

        static Peso() {
            cotizRespectoDolar = 0.023;
        }
        public Peso(double cantidad) {
            this.cantidad = cantidad;
        }
        public Peso(double cantidad, double cotizacion) : this(cantidad) {
            Peso.cotizRespectoDolar = cotizacion;
        }

        /////////////////////////////////////////////////////

        public double GetCantidad() {
            return this.cantidad;
        }
        public static double GetCotizacion() {
            return Peso.cotizRespectoDolar;
        }
        public static void SetCotizacion(double d) {
            Peso.cotizRespectoDolar = d;
        }

        /////////////////////////////////////////////////////

        public static implicit operator Peso(double d) {
            return new Peso(d);
        }
        public static explicit operator Dolar(Peso p) {
            return new Dolar(p.GetCantidad() * Peso.GetCotizacion());
        }
        public static explicit operator Euro(Peso p) {
            return new Euro(p.GetCantidad() * Peso.GetCotizacion() / Euro.GetCotizacion());
        }
        public static implicit operator string(Peso p) {
            return p.GetCantidad().ToString();
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
            return !(p1 == p2);
        }
        public static bool operator !=(Peso p, Dolar d) {
            return !(p == d);
        }
        public static bool operator !=(Peso p, Euro e) {
            return !(p == e);
        }

        /////////////////////////////////////////////////////

        public static Peso operator +(Peso p1, Peso p2) {
            return p1.GetCantidad() + p2.GetCantidad();
        }
        public static Peso operator +(Peso p, Dolar d) {
            return p + (Peso)d;
        }
        public static Peso operator +(Peso p, Euro e) {
            return p + (Peso)e;
        }

        public static Peso operator -(Peso p1, Peso p2) {
            return p1.GetCantidad() - p2.GetCantidad();
        }
        public static Peso operator -(Peso p, Dolar d) {
            return p - (Peso)d;
        }
        public static Peso operator -(Peso p, Euro e) {
            return p - (Peso)e;
        }
    }
}
