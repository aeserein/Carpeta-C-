using System;
using System.Collections.Generic;
using System.Text;

namespace Práctica_Parcial_01 {

    public abstract class Mascota {

        private string raza;
        private string nombre;

        #region Propiedades
        protected string Raza {
            get { return this.raza; }
        }
        protected string Nombre {
            get { return this.nombre; }
        }
        #endregion

        #region Constructores
        protected Mascota(string nombre, string raza) {
            this.raza = raza;
            this.nombre = nombre;
        }
        #endregion

        #region Métodos
        abstract protected string Ficha();

        virtual protected string DatosCompletos() {
            return String.Format("{0} {1}", this.Nombre, this.Raza);
        }
        #endregion

    }
}
