using System;
using System.Collections.Generic;
using System.Text;

namespace Práctica_Parcial_01 {

    public class Perro : Mascota {

        private int edad;
        private bool esAlfa;

        #region Propiedades
        public int Edad {
            get { return this.edad; }
            set { this.edad = value; }
        }
        public bool EsAlfa {
            get { return this.esAlfa; }
            set { this.esAlfa = value; }
        }
        #endregion

        #region Constructores
        public Perro(string nombre, string raza)
            : this(nombre, raza, 0, false) {
        }

        public Perro(string nombre, string raza, int edad, bool esAlfa)
            : base(nombre, raza) {
            this.Edad = edad;
            this.EsAlfa = esAlfa;            
        }
        #endregion

        #region Métodos
        protected override string Ficha() {
            string s = "";

            s += base.DatosCompletos();
            if (this.EsAlfa)
                s += ", alfa de la manada, ";
            s += "edad " + this.Edad;

            return s;
        }
        public override string ToString() {
            return this.Ficha();
        }
        public override bool Equals(object obj) {
            return (this == (Perro)obj);
        }
        #endregion

        #region Operadores
        public static bool operator ==(Perro j1, Perro j2) {
            return (j1.Nombre == j2.Nombre &&
                    j1.Raza == j2.Raza &&
                    j1.Edad == j2.Edad);
        }
        public static bool operator !=(Perro j1, Perro j2) {
            return !(j1 == j2);
        }
        public static explicit operator int(Perro perro) {
            return perro.Edad;
        }
        #endregion
    }
}
 