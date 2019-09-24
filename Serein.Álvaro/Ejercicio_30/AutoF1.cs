using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_30 {

    class AutoF1 {

        private short cantidadCombustible;
        private bool enCompetencia;
        private string escuderia;
        private short numero;
        private short vueltasRestantes;


        public AutoF1(short numero, string escuderia) {
            this.numero = numero;
            this.escuderia = escuderia;

            this.enCompetencia = false;
            this.cantidadCombustible = 0;
            this.vueltasRestantes = 0;
        }


        public short CantidadCombustible {
            get {
                return this.cantidadCombustible;
            }
            set {
                this.cantidadCombustible = value;
            }
        }
        public bool EnCompetencia {
            get {
                return this.enCompetencia;
            }
            set {
                this.enCompetencia = value;
            }
        }
        public short VueltasRestantes {
            get {
                return this.vueltasRestantes;
            }
            set {
                this.vueltasRestantes = value;
            }
        }

        public static bool operator ==(AutoF1 a1, AutoF1 a2) {
            return (a1.numero == a2.numero && a1.escuderia == a2.escuderia);
        }
        public static bool operator !=(AutoF1 a1, AutoF1 a2) {
            return !(a1 == a2);
        }

        public string MostrarDatos() {
            return "Escudería: " + this.escuderia + "\n" +
                   "Número: " + this.numero + "\n" +
                   "En competencia: " + this.EnCompetencia + "\n" +
                   "Vueltas restantes: " + this.VueltasRestantes + "\n" +
                   "Cantidad de combustible: " + this.CantidadCombustible;

        }
    }
}
