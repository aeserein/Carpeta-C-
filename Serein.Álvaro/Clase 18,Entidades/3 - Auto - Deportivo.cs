using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_18_Entidades {

    public class Deportivo : Auto, IAFIP, IARBA {

        private int _caballosFuerza;

        #region Propiedades
        public int CaballosDeFuerza {
            get { return this._caballosFuerza; }
        }
        public double PrecioConImpuesto {
            get { return this._precio + Gestion.MostrarImpuestoNacional(this) + Gestion.MostrarImpuestoProvincial(this); }
        }
        #endregion

        #region Constructores
        public Deportivo(double precio, string patente, int hp)
            : base(precio, patente) {
            this._caballosFuerza = hp;
        }
        #endregion

        #region IAFIP
        public double CalcularImpuesto() {
            return base._precio * 0.28;
        }
        #endregion

        #region IARBA
        double IARBA.CalcularImpuesto() {
            return base._precio * 0.23;
        }
        #endregion
    }
}
