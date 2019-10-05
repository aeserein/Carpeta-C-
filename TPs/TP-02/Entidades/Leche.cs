using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2019 {

    /// <summary>
    /// Define un Producto de tipo Leche
    /// </summary>
    public class Leche : Producto {

        private ETipo tipo;

        #region Propiedades
        /// <summary>
        /// Las Leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias {
            get {
                return 20;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa una instancia de Snacks de tipo Entera por defecto.
        /// </summary>
        /// <param name="marca">Marca del Producto</param>
        /// <param name="codigo">Código de barras del Producto</param>
        /// <param name="color">Color del envase del Producto</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color)
            : this(marca, codigo, color, ETipo.Entera) {
        }

        /// <summary>
        /// Inicializa una instancia de Snacks.
        /// </summary>
        /// <param name="marca">Marca del Producto</param>
        /// <param name="codigo">Código de barras del Producto</param>
        /// <param name="color">Color del envase del Producto</param>
        /// <param name="tipo">Tipo de leche</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo)
            : base(codigo, marca, color) {
            this.tipo = tipo;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Expone los datos del elemento.
        /// </summary>
        /// <returns>Representación en texto de los datos del elemento.</returns>
        public override string Mostrar() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}\r\n", this.CantidadCalorias);
            sb.AppendFormat("TIPO : {0}\r\n", this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
        #endregion

        #region Enumerados
        /// <summary>
        /// Tipo de Leche.
        /// </summary>
        public enum ETipo {
            Entera,     // 0
            Descremada  // 1
        }
        #endregion
    }
}
