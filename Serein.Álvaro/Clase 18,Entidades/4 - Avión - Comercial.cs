using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_18_Entidades {

    public class Comercial : Avion {

        private int _cantidadDePasajeros;

        #region Propiedades
        public int CantidadDePasajeros {
            get { return this._cantidadDePasajeros; }
        }
        #endregion

        #region Constructores
        public Comercial(double precio, double velocidad, int pasajeros)
            : base(precio, velocidad) {
            this._cantidadDePasajeros = pasajeros;
        }
        #endregion
    }
}
