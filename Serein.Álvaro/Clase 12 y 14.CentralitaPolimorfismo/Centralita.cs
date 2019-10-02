using System;
using System.Collections.Generic;
using System.Text;

namespace Clase_12.CentralitaPolimorfismo {

    public class Centralita {

        private List<Llamada> _listaDeLlamadas;
        public string _razonSocial;

        #region Constructores
        public Centralita() : this ("---") {  }
        public Centralita(string nombreEmpresa) {
            this._listaDeLlamadas = new List<Llamada>();
            this._razonSocial = nombreEmpresa;
        }
        #endregion

        #region Métodos
        public override string ToString() {
            StringBuilder sb = new StringBuilder();

            if (!Object.Equals(this, null)) {
                sb.AppendLine(this._razonSocial);
                foreach (Llamada l in this._listaDeLlamadas) {
                    sb.AppendLine(l.ToString());
                }
            }
            return sb.ToString();
        }

        private void AgregarLlamada(Llamada nuevaLlamada) {
            if (!Object.Equals(nuevaLlamada, null))
                this._listaDeLlamadas.Add(nuevaLlamada);
        }

        private float CalcularGanancia(TipoLlamada tipo) {
            float ganancia = 0;

            foreach (Llamada llamada in this._listaDeLlamadas) {

                switch (tipo) {
                    case TipoLlamada.Local : {
                        if (llamada is Local) {
                            ganancia += llamada.CostoLlamada;
                        }
                        break;
                    }
                    case TipoLlamada.Provincial : {
                        if (llamada is Provincial) {
                            ganancia += llamada.CostoLlamada;
                        }
                        break;
                    }
                    case TipoLlamada.Todas : {
                        ganancia += llamada.CostoLlamada;
                        break;
                    }
                }
            }
            return ganancia;
        }

        public void OrdenarLlamadas() {
            this._listaDeLlamadas.Sort(Llamada.OrdenarPorDuracionAscendente);
        }
        #endregion

        #region Operadores
        public static bool operator == (Centralita c, Llamada l) {
            if (!Object.Equals(c, null) && !Object.Equals(l, null)) {
                foreach (Llamada llamada in c._listaDeLlamadas) {
                    if (llamada == l)
                        return true;
                }
            }
            return false;
        }
        public static bool operator != (Centralita c, Llamada l) {
            return !(c==l);
        }
        public static Centralita operator + (Centralita c, Llamada l) {
            if (c!=l) {
                c.AgregarLlamada(l);
            }
            return c;
        }
        #endregion
    }
}
