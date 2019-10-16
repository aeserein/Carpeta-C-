using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {

    public abstract class Vehiculo {

        protected Fabricante fabricante;
        protected static Random generadorDeVelocidades;
        protected string modelo;
        protected float precio;
        protected int velocidadMaxima;

        #region Propiedades
        protected int VelocidadMaxima {
            get {
                if (this.velocidadMaxima == 0)
                    this.velocidadMaxima = generadorDeVelocidades.Next(100, 281);
                return this.velocidadMaxima;
            }
        }
        #endregion

        #region Constructores
        static Vehiculo() {
            generadorDeVelocidades = new Random();
        }
        public Vehiculo(float precio, string modelo, Fabricante fabri) {
            this.precio = precio;
            this.modelo = modelo;
            this.fabricante = fabri;
        }
        public Vehiculo(string marca, EPais pais, string modelo, float precio)
            : this(precio, modelo, new Fabricante(marca, pais)) {
        }
        #endregion

        #region Métodos
        private static string Mostrar(Vehiculo v) {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("FABRICANTE: " + v.fabricante);
            sb.AppendLine("MODELO: " + v.modelo);
            sb.AppendLine("VELOCIDAD MÁXIMA: " + v.VelocidadMaxima);
            sb.Append("PRECIO: " + v.precio);
            return sb.ToString();
        }
        #endregion

        #region Operadores
        public static bool operator ==(Vehiculo a, Vehiculo b) {
            return (a.fabricante == b.fabricante &&
                    a.modelo == b.modelo);
        }
        public static bool operator !=(Vehiculo a, Vehiculo b) {
            return !(a == b);
        }
        public static explicit operator string(Vehiculo v) {
            return Vehiculo.Mostrar(v);
        }
        #endregion
    }
}
