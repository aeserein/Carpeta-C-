using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {

    public class Moto : Vehiculo {

        public ECilindrada cilindrada;

        #region Constructores
        public Moto(string marca, EPais pais, string modelo, float precio, ECilindrada cilindrada)
            : base(marca, pais, modelo, precio) {
            this.cilindrada = cilindrada;
        }
        #endregion

        #region Métodos
        public override bool Equals(object obj) {
            return (this == (Moto)obj);
        }
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine((string)this);
            sb.AppendLine("CILINDRADA: " + this.cilindrada.ToString());
            return sb.ToString();
        }
        #endregion

        #region Operadores
        public static bool operator ==(Moto a, Moto b) {
            return ((Vehiculo)a == (Vehiculo)b &&
                    a.cilindrada == b.cilindrada);
        }
        public static bool operator !=(Moto a, Moto b) {
            return !(a == b);
        }
        public static implicit operator Single(Moto m) {
            return m.precio;
        }
        #endregion
    }
}
