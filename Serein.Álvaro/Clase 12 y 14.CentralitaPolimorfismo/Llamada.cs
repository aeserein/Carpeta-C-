using System;
using System.Collections.Generic;
using System.Text;

namespace Clase_12.CentralitaPolimorfismo {

    public abstract class Llamada {

        private float _duracion;
        private string _nroDestino;
        private string _nroOrigen;

        #region Propiedades
        public float Duracion {
            get => _duracion;
        }
        public string NroDestino {
            get => _nroDestino;
        }
        public string NroOrigen {
            get => _nroOrigen;
        }
        public abstract float CostoLlamada {
            get;
        }
        #endregion

        #region Constructores
        public Llamada(string origen, string destino, float duracion) {
            this._nroOrigen = origen;
            this._nroDestino = destino;
            this._duracion = duracion;
        }
        #endregion

        #region Métodos
        protected virtual string Mostrar() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nº Origen: " + this.NroOrigen + "  ");
            sb.AppendLine("Nº Destino: " + this.NroDestino + "  ");
            sb.AppendLine("Duración: " + this.Duracion + "  ");
            return sb.ToString();
        }
        public static int OrdenarPorDuracionAscendente(Llamada l1, Llamada l2) {
            if (l1.Duracion > l2.Duracion)
                return 1;
            else if (l1.Duracion < l2.Duracion)
                return -1;
            else
                return 0;
        }
        public static int OrdenarPorDuracionDescendente(Llamada l1, Llamada l2) {
            return OrdenarPorDuracionAscendente(l1, l2) * (-1);
        }
        #endregion

        #region Operadores
        public static bool operator == (Llamada l1, Llamada l2) {
            return (Object.Equals(l1, l2) &&
                    l1.NroOrigen == l2.NroOrigen &&
                    l1.NroDestino == l2.NroDestino);
        }
        public static bool operator != (Llamada l1, Llamada l2) {
            return !(l1 == l2);
        }
        #endregion
    }
}
