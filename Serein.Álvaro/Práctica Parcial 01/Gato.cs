using System;
using System.Collections.Generic;
using System.Text;

namespace Práctica_Parcial_01 {

    public class Gato : Mascota {

        #region Métodos
        protected override string Ficha() {
            return base.DatosCompletos();
        }
        public override bool Equals(object obj) {
            return (this == (Gato)obj);
        }
        public override string ToString() {
            return this.Ficha();
        }
        #endregion

        #region Constructores
        public Gato(string nombre, string raza)
            : base(nombre, raza) {
        }
        #endregion

        #region Operadores
        public static bool operator ==(Gato obj1, Gato obj2) {
            return (obj1.Raza == obj2.Raza &&
                    obj1.Nombre == obj2.Nombre);
        }
        public static bool operator !=(Gato obj1, Gato obj2) {
            return !(obj1 == obj2);
        }
        #endregion
    }
}
