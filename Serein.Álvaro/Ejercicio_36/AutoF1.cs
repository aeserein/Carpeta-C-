using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_36 {

    public class AutoF1 : VehiculoDeCarrera {

        private short caballosDeFuerza;

        #region Propiedades
        public short CaballosDeFuerza {
            get { return this.caballosDeFuerza; }
            set { this.caballosDeFuerza = value; }
        }
        #endregion

        #region Constructores
        public AutoF1(short numero, string escuderia) : this (numero, escuderia, 0) { }

        public AutoF1(short numero, string escuderia, short caballosDeFuerza) : base(0, false, escuderia, numero, 0) {
            this.CaballosDeFuerza = caballosDeFuerza;
        }
        #endregion

        #region Operadores
        public static bool operator ==(AutoF1 a1, AutoF1 a2) {
            return (a1.Numero == a2.Numero &&
                    a1.Escuderia == a2.Escuderia &&
                    a1.CaballosDeFuerza==a2.CaballosDeFuerza);
        }
        public static bool operator !=(AutoF1 a1, AutoF1 a2) {
            return !(a1 == a2);
        }
        #endregion

        #region Métodos
        new public string MostrarDatos() {
            string s = base.MostrarDatos();
            s += "Caballos de fuerza: " + this.CaballosDeFuerza;
            return s;
        }
        #endregion
    }
}
