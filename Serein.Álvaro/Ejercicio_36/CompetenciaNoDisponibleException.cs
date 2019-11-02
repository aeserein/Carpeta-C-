using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_36 {

    class CompetenciaNoDisponibleException : Exception {

        private string nombreClase;
        private string nombreMetodo;

        #region Propiedades
        public string NombreClase {
            get => nombreClase;
        }
        public string NombreMetodo {
            get => nombreMetodo;
        }
        #endregion

        #region Constructores
        public CompetenciaNoDisponibleException(string mensaje, string nombreClase, string nombreMetodo)
            : base(mensaje) {
            this.nombreClase = nombreClase;
            this.nombreMetodo = nombreMetodo;
        }

        public CompetenciaNoDisponibleException(string mensaje, string nombreClase, string nombreMetodo, Exception innerException)
            : base(mensaje, innerException) {
            this.nombreClase = nombreClase;
            this.nombreMetodo = nombreMetodo;
        }
        #endregion

        #region Métodos
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Excepción en el método {0} de la clase {1}: ", this.NombreMetodo, this.NombreClase);
            sb.AppendLine(base.Message);

            Exception e = this;
            while(e.InnerException!=null) {
                sb.Append(e.InnerException.Message + "\t");
                e = e.InnerException;
            }
            return sb.ToString();
        }
        #endregion
    }
}
