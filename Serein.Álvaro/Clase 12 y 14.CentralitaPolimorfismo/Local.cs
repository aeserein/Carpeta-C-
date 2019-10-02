using System;
using System.Collections.Generic;
using System.Text;

namespace Clase_12.CentralitaPolimorfismo {

    public class Local : Llamada {

        protected float _costo;

        #region Propiedades
        public override float CostoLlamada {
            get {
                return this.CalcularCosto();
            }
        }
        #endregion

        #region Constructores
        public Local(string origen, string destino, float duracion, float costo)
            : base(origen, destino, duracion) {
            this._costo = costo;
        }
        public Local(Llamada unaLlamada, float costo)
            : this(unaLlamada.NroOrigen, unaLlamada.NroDestino, unaLlamada.Duracion, costo) {
        }
        #endregion

        #region Métodos
        private float CalcularCosto() {
            return this.Duracion * this._costo;
        }
        public override bool Equals(object obj) {
            return obj is Local;
        }
        protected override string Mostrar() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("Costo: " + this.CostoLlamada + " ");
            return sb.ToString();
        }
        public override string ToString() {
            return this.Mostrar();
        }
        #endregion
    }
}
