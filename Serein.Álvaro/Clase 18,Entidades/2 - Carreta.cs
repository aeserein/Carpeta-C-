using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_18_Entidades {

    public class Carreta : Vehiculo, IARBA {

        #region Propiedades
        public double PrecioConImpuesto {
            get { return this._precio + this.CalcularImpuesto(); }
        }
        #endregion

        #region Constructores
        public Carreta(double precio) : base(precio) {
        }
        #endregion

        #region IARBA
        public double CalcularImpuesto() {
            return this._precio * 0.18;
        }
        #endregion
    }
}
