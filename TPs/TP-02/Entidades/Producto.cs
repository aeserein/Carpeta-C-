using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2019 {

    /// <summary>
    /// Define un Producto no instanciable.
    /// </summary>
    public abstract class Producto {

        protected string codigoDeBarras;
        protected ConsoleColor colorPrimarioEmpaque;
        protected EMarca marca;

        #region Propiedades
        /// <summary>
        /// Retorna las calorías del Producto
        /// </summary>
        protected abstract short CantidadCalorias {
            get;
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa los campos de Producto que heredarán las clases derivadas.
        /// </summary>
        /// <param name="codigo">Código de barras del Producto</param>
        /// <param name="marca">Marca del Producto</param>
        /// <param name="color">Color del envase del Producto</param>
        public Producto(string codigo, EMarca marca, ConsoleColor color) {
            this.codigoDeBarras = codigo;
            this.colorPrimarioEmpaque = color;
            this.marca = marca;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Expone los datos del Producto.
        /// </summary>
        /// <returns>Representación en texto de los datos del Producto.</returns>
        public virtual string Mostrar() {
            return (string)this;
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Expone los datos del Producto.
        /// </summary>
        /// <returns>Representación en texto de los datos del Producto.</returns>
        public static explicit operator string(Producto p) {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p.codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");
            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras.
        /// </summary>
        /// <param name="v1">Producto a comparar</param>
        /// <param name="v2">Producto a comparar</param>
        /// <returns>'true' si tienen el mísmo código de barras.</returns>
        public static bool operator == (Producto v1, Producto v2) {
            return (v1.codigoDeBarras == v2.codigoDeBarras);
        }

        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto.
        /// </summary>
        /// <param name="v1">Producto a comparar</param>
        /// <param name="v2">Producto a comparar</param>
        /// <returns>'true' si tienen diferente código de barras.</returns>
        public static bool operator != (Producto v1, Producto v2) {
            return !(v1 == v2);
        }
        #endregion

        #region Enumerados
        /// <summary>
        /// Marcas de Productos
        /// </summary>
        public enum EMarca {
            Serenisima, // 0
            Campagnola, // 1
            Arcor,      // 2
            Ilolay,     // 3
            Sancor,     // 4
            Pepsico     // 5
        }
        #endregion
    }
}