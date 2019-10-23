using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_18_Entidades {

    public class Familiar : Auto {

        private int _cantidadAsientos;

        #region Propiedades
        public int CantidadAsientos {
            get {
                return this._cantidadAsientos;
            }
        }
        #endregion

        #region Constructores
        public Familiar(double precio, string patente, int cantidadAsientos)
            : base(precio, patente) {
            this._cantidadAsientos = cantidadAsientos;
        }
        #endregion
    }
}
