using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_18_Entidades {

    public class Privado : Avion {

        private int _valoracionSevicioDeABordo;

        #region Propiedades
        public int Valoracion {
            get { return this._valoracionSevicioDeABordo; }
        }
        #endregion

        #region Constructores
        public Privado(double precio, double velocidad, int valoracion)
            : base(precio, velocidad) {
            this._valoracionSevicioDeABordo = valoracion;
        }
        #endregion
    }
}
