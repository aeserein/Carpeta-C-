using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace Entidades {

    public class Correo : IMostrar<List<Paquete>> {

        private List<Thread> mockPacketes;
        private List<Paquete> paquetes;

        #region Propiedades
        /// <summary>
        /// Lista dinámica de Paquetes.
        /// </summary>
        public List<Paquete> Paquetes {
            get => this.paquetes;
            set => this.paquetes = value;
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Crea una instancia de Correo.
        /// </summary>
        public Correo() {
            this.mockPacketes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Cierra todos los hilos de ciclos de vida de Paquetes.
        /// </summary>
        public void FinEntregas() {
            foreach (Thread thread in this.mockPacketes) {
                if (thread.IsAlive)
                    thread.Abort();
            }
        }
        #endregion

        #region IMostrar
        /// <summary>
        /// Muestra la lista de Paquetes.
        /// </summary>
        /// <param name="elementos">Lista de Paquetes.</param>
        /// <returns>Una cadena de caracteres que representa los Paquetes.</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos) {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete p in ((Correo)elementos).Paquetes) {
                sb.AppendLine(string.Format("{0} para {1} ({2})",
                                            p.TrackingID,
                                            p.DireccionEntrega,
                                            p.Estado.ToString() ));
            }
            return sb.ToString();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Agrega un Paquete a una instancia de Correo. Simula su ciclo de vida en un subproceso.
        /// </summary>
        /// <param name="c">Instancia de Correo</param>
        /// <param name="p">Instancia de Paquete</param>
        /// <returns>La instancia de Correo con el Paquete agregado.</returns>
        public static Correo operator + (Correo c, Paquete p) {
            foreach (Paquete paquete in c.Paquetes) {
                if (paquete == p)
                    throw new TrackingIdRepetidoException("El Tracking ID " + paquete.TrackingID + " ya figura en la lista de envíos.");
            }
            c.Paquetes.Add(p);

            Thread thread = new Thread(p.MockCicloDeVida);
            c.mockPacketes.Add(thread);

            thread.Start();

            return c;
        }
        #endregion
    }
}
