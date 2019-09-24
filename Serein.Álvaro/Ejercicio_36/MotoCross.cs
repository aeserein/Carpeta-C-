using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_36 {

    public class MotoCross : VehiculoDeCarrera {

        private short cilindrada;

        #region Propiedades
        public short Cilindrada {
            get { return this.cilindrada; }
            set { this.cilindrada = value; }
        }
        #endregion

        #region Constructores
        public MotoCross(short numero, string escuderia) : this(numero, escuderia, 0) { }

        public MotoCross(short numero, string escuderia, short cilindrada) : base(0, false, escuderia, numero, 0) {
            this.Cilindrada = cilindrada;
        }
        #endregion

        #region Operadores
        public static bool operator ==(MotoCross m1, MotoCross m2) {
            return (m1.Numero == m2.Numero &&
                    m1.Escuderia == m2.Escuderia &&
                    m1.Cilindrada == m2.Cilindrada);
        }
        public static bool operator !=(MotoCross m1, MotoCross m2) {
            return !(m1 == m2);
        }
        #endregion

        #region Métodos
        new public string MostrarDatos() {
            string s = base.MostrarDatos();
            s += "Cilindrada: " + this.Cilindrada;
            return s;
        }
        #endregion
    }
}
