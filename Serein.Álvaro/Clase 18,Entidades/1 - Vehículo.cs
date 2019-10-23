using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_18_Entidades {

    abstract public class Vehiculo {

        protected double _precio;

        #region Constructores
        public Vehiculo(double precio) {
            this._precio = precio;
        }
        #endregion

        #region Métodos
        public string MostrarPrecio() {
            return "Precio: " + this._precio;
        }
        #endregion
    }
}
