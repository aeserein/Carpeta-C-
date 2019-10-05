using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2019 {

    /// <summary>
    /// Contiene una lista de objetos de tipo Producto
    /// </summary>
    public sealed class Changuito {

        private List<Producto> productos;
        private int espacioDisponible;

        #region Constructores
        /// <summary>
        /// Inicializa la lista de Productos.
        /// </summary>
        private Changuito() {
            this.productos = new List<Producto>();
        }

        /// <summary>
        /// Inicializa una instancia de Changuito con la capacidad especificada.
        /// </summary>
        /// <param name="espacioDisponible">Cantidad de Productos que puede guardar.</param>
        public Changuito(int espacioDisponible) : this() {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias).
        /// Se puede especificar un tipo de Producto o todos.
        /// </summary>
        /// <param name="c">Changuito a exponer.</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>Representación en texto de los datos del Changuito</returns>
        public static string Mostrar(Changuito c, ETipo tipo) {

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles",
                            c.productos.Count, c.espacioDisponible);
            sb.AppendLine("");

            foreach (Producto p in c.productos) {
                switch (tipo) {
                    case ETipo.Dulce:
                        if (p is Dulce)
                            sb.AppendLine(p.Mostrar());
                        break;
                    case ETipo.Leche:
                        if (p is Leche)
                            sb.AppendLine(p.Mostrar());
                        break;
                    case ETipo.Snacks:
                        if (p is Snacks)
                            sb.AppendLine(p.Mostrar());
                        break;
                    default:
                        sb.AppendLine(p.Mostrar());
                        break;
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Muestra el Changuito y todos sus productos.
        /// </summary>
        /// <returns>Representación en texto de los datos del Changuito.</returns>
        public override string ToString() {
            return Changuito.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Agregará un Producto a la lista del Changuito, si no está previamente en ella.
        /// </summary>
        /// <param name="c">Changuito donde se agregará el Producto</param>
        /// <param name="p">Producto a agregar</param>
        /// <returns>Changuito con el Producto agregado.</returns>
        public static Changuito operator + (Changuito c, Producto p) {
            if (c.productos.Count < c.espacioDisponible) {
                foreach (Producto v in c.productos) {
                    if (v == p)
                        return c;
                }
                c.productos.Add(p);
            }
            return c;
        }
        
        /// <summary>
        /// Quitará un Producto de la lista del Changuito.
        /// </summary>
        /// <param name="c">Changuito donde se quitará el elemento</param>
        /// <param name="p">Producto a quitar</param>
        /// <returns>Changuito con el Producto removido.</returns>
        public static Changuito operator - (Changuito c, Producto p) {
            foreach (Producto v in c.productos) {
                if (v == p) {
                    c.productos.Remove(p);
                    break;
                }
            }
            return c;
        }
        #endregion

        #region Enumerados
        /// <summary>
        /// Tipo de Producto.
        /// </summary>
        public enum ETipo {
            Dulce,  // 0
            Leche,  // 1
            Snacks, // 2
            Todos   // 3
        }
        #endregion
    }
}
