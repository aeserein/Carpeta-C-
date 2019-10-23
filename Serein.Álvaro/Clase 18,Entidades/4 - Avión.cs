using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_18_Entidades {

    public class Avion : Vehiculo, IAFIP, IARBA {

        protected double _velocidadMaxima;

        #region Propiedades
        public double VelocidadMaxima {
            get { return this._velocidadMaxima; }
        }
        public double PrecioConImpuesto {
            get { return this._precio + Gestion.MostrarImpuestoNacional(this) + Gestion.MostrarImpuestoProvincial(this); }
        }
        #endregion

        #region Constructores
        public Avion(double precio, double velMax) : base(precio) {
            this._velocidadMaxima = velMax;
        }
        #endregion

        #region IAFIP
        public double CalcularImpuesto() {
            return base._precio * 0.33;
        }
        #endregion

        #region IARBA
        double IARBA.CalcularImpuesto() {
            return base._precio * 0.27;
        }
        #endregion
    }
}
