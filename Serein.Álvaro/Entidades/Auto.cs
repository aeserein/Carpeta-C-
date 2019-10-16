using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {

    public class Auto : Vehiculo {

        public ETipo tipo;

        #region Constructores
        public Auto(string modelo, float precio, Fabricante fabri, ETipo tipo)
            : base(precio, modelo, fabri) {
            this.tipo = tipo;
        }
        #endregion

        #region Métodos
        public override bool Equals(object obj) {
            return (this==(Auto)obj);
        }
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine((string)this);
            sb.AppendLine("TIPO: " + this.tipo.ToString());
            return sb.ToString();
        }
        #endregion

        #region Operadores
        public static bool operator ==(Auto a, Auto b) {
            return ((Vehiculo)a == (Vehiculo)b &&
                    a.tipo == b.tipo);
        }
        public static bool operator !=(Auto a, Auto b) {
            return !(a == b);
        }
        public static explicit operator Single(Auto a) {
            return a.precio;
        }
        #endregion
    }
}
