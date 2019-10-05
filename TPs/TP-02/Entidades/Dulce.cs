using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2019 {

    /// <summary>
    /// Define un Producto de tipo Dulce
    /// </summary>
    public class Dulce : Producto {

        #region Propiedades
        /// <summary>
        /// Los Dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias {
            get {
                return 80;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa una instancia de Dulce
        /// </summary>
        /// <param name="marca">Marca del Producto</param>
        /// <param name="codigo">Código de barras del Producto</param>
        /// <param name="color">Color del envase del Producto</param>
        public Dulce(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color) {
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Expone los datos del elemento.
        /// </summary>
        /// <returns>Representación en texto de los datos del elemento.</returns>
        public override string Mostrar() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}\r\n", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
        #endregion
    }
}
