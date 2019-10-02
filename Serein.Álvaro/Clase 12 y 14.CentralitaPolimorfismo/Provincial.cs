using System;
using System.Collections.Generic;
using System.Text;

namespace Clase_12.CentralitaPolimorfismo {

    public class Provincial : Llamada {

        protected Franja _franjaHoraria;

        #region Propiedades
        public override float CostoLlamada {
            get {
                return this.CalcularCosto();
            }
        }
        #endregion

        #region Constructores
        public Provincial(string origen, string destino, float duracion, Franja miFranja)
            : base(origen, destino, duracion) {
            this._franjaHoraria = miFranja;
        } 
        public Provincial(Llamada unaLlamada, Franja miFranja)
            : this(unaLlamada.NroOrigen, unaLlamada.NroDestino, unaLlamada.Duracion, miFranja) { 
        }
        #endregion
        
        #region Métodos
        protected override string Mostrar() {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.Mostrar());
            sb.Append("Franja Horaria: " + this._franjaHoraria.ToString() + " ");
            return sb.ToString();
        }
        public override bool Equals(object obj) {
            return obj is Provincial;
        }
        public override string ToString() {
            return this.Mostrar();
        }
        private float CalcularCosto() {
            float retFloat = 0;
            switch (this._franjaHoraria) {
                case Franja.Franja_1:
                    retFloat = (float)(this.Duracion * 0.99);
                    break;
                case Franja.Franja_2:
                    retFloat = (float)(this.Duracion * 1.25);
                    break;
                case Franja.Franja_3:
                    retFloat = (float)(this.Duracion * 0.66);
                    break;
            }
            return retFloat;
        }
        #endregion
    }
}