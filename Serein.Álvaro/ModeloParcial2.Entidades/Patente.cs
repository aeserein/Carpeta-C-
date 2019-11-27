using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial2.Entidades {

    public class Patente {

        private string codPatente;
        private Tipo tipoCodigo;



        #region Propiedeades
        public string CodigoPatente { get => codPatente; set => codPatente = value; }
        public Tipo TipoCodigo { get => tipoCodigo; set => tipoCodigo = value; }
        #endregion



        #region Constructores
        public Patente() {
        }
        public Patente(string codPatente, Tipo tipoCodigo) {
            this.CodigoPatente = codPatente;
            this.TipoCodigo = tipoCodigo;
        }
        #endregion


        #region Métodos
        public override string ToString() {
            return string.Format("Patente: {0} - Tipo: {1}",
                                 this.CodigoPatente, this.TipoCodigo.ToString());
        }
        #endregion


        public enum Tipo {
            Vieja,
            Mercosur
        }
    }
}
