using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_18_Entidades {

    public abstract class Auto : Vehiculo {

        protected string _patente;

        #region Constructores
        public Auto(double precio, string patente) : base(precio) {
            this._patente = patente;
        }
        #endregion

        #region Métodos
        public void MostrarPatente() {
            Console.WriteLine("Patente: " + this._patente);
        }
        #endregion
    }
}
