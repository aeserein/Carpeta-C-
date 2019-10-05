using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2019 {

    /// <summary>
    /// Define un Producto de tipo Snack
    /// </summary>
    public class Snacks : Producto {

        #region Propiedades
        /// <summary>
        /// Los Snacks tienen 104 calorías.
        /// </summary>
        protected override short CantidadCalorias {
            get {
                return 104;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa una instancia de Snacks.
        /// </summary>
        /// <param name="marca">Marca del Producto</param>
        /// <param name="codigo">Código de barras del Producto</param>
        /// <param name="color">Color del envase del Producto</param>
        public Snacks(EMarca marca, string codigo, ConsoleColor color)
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
            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}\r\n", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
        #endregion
    }
}
