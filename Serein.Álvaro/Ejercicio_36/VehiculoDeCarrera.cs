using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_36 {

    public class VehiculoDeCarrera {

        private short cantidadCombustible;
        private bool enCompetencia;
        private protected string escuderia;
        private protected short numero;
        private short vueltasRestantes;

        #region Constructores
        public VehiculoDeCarrera(short cantidadCombustible, bool enCompetencia, string escuderia, short numero, short vueltasRestantes) {
            CantidadCombustible = cantidadCombustible;
            EnCompetencia = enCompetencia;
            Escuderia = escuderia;
            Numero = numero;
            VueltasRestantes = vueltasRestantes;
        }
        #endregion

        #region Propiedades
        public short CantidadCombustible {
            get { return this.cantidadCombustible; }
            set { this.cantidadCombustible = value; }
        }
        public bool EnCompetencia {
            get { return this.enCompetencia;}
            set { enCompetencia = value; }
        }
        public string Escuderia {
            get { return this.escuderia; }
            set { this.escuderia = value;}
        }
        public short Numero {
            get { return this.numero; }
            set { this.numero = value; }
        }
        public short VueltasRestantes {
            get { return this.vueltasRestantes; }
            set { this.vueltasRestantes = value; }
        }
        #endregion

        #region Métodos
        public string MostrarDatos() {
            return "Escudería: " + this.Escuderia + "\n" +
                   "Número: " + this.Numero + "\n" +
                   "En competencia: " + this.EnCompetencia + "\n" +
                   "Vueltas restantes: " + this.VueltasRestantes + "\n" +
                   "Cantidad de combustible: " + this.CantidadCombustible + "\n";

        }
        #endregion
    }
}
