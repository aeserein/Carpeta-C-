using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace Entidades {

    public class Paquete : IMostrar<Paquete> {

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #region Propiedades
        /// <summary>
        /// Lee o devuelve dirección de entrega.
        /// </summary>
        public string DireccionEntrega {
            get => this.direccionEntrega;
            set => this.direccionEntrega = value;
        }

        /// <summary>
        /// Lee o devuelve el ID.
        /// </summary>
        public string TrackingID {
            get => this.trackingID;
            set => this.trackingID = value;
        }

        /// <summary>
        /// Lee o devuelve el estado.
        /// </summary>
        public EEstado Estado {
            get => this.estado;
            set => this.estado = value;
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Crea una instancia de Paquete.
        /// </summary>
        /// <param name="direccionEntrega">Dirección de entrega</param>
        /// <param name="trackingID">ID del paquete</param>
        public Paquete(string direccionEntrega, string trackingID) {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.estado = EEstado.Ingresado;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Muestra una instancia de Paquete.
        /// </summary>
        /// <returns>Cadena de caracteres con los datos del Paquete.</returns>
        public override string ToString() {
            return this.MostrarDatos(this);
        }

        /// <summary>
        /// Simula el ciclo de vida de un Paquete y lo guarda en la base de datos.
        /// </summary>
        public void MockCicloDeVida() {

            while (this.Estado != EEstado.Entregado) {
                Thread.Sleep(4 * 1000);
                this.Estado++;
                this.InformaEstado(this, null);
            }
            try {
                PaqueteDAO.Insertar(this);
            } catch (Exception e) {
                this.InformaException(e);
            }
        }
        #endregion

        #region IMostrar
        /// <summary>
        /// Muestra una instancia de Paquete.
        /// </summary>
        /// <param name="elemento">Instancia de Paquete</param>
        /// <returns>Cadena de caracteres con los datos del Paquete.</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento) {
            return string.Format("{0} para {1}",
                                 ((Paquete)elemento).TrackingID,
                                 ((Paquete)elemento).DireccionEntrega);
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Compara dos instancias de Paquete.
        /// </summary>
        /// <param name="p1">Una instancia de Paquete</param>
        /// <param name="p2">Una instancia de Paquete</param>
        /// <returns>Verdadero, si tienen mismo TrackingID.</returns>
        public static bool operator == (Paquete p1, Paquete p2) {
            return (p1.TrackingID == p2.TrackingID);
        }

        /// <summary>
        /// Compara dos instancias de Paquete.
        /// </summary>
        /// <param name="p1">Una instancia de Paquete</param>
        /// <param name="p2">Una instancia de Paquete</param>
        /// <returns>Verdadero, si tienen diferente TrackingID.</returns>
        public static bool operator != (Paquete p1, Paquete p2) {
            return !(p1==p2);
        }
        #endregion

        #region Delegados / Eventos
        /// <summary>
        /// Delegado para informar estado del Paquete.
        /// </summary>
        public delegate void DelegadoEstado(object sender, EventArgs e);

        /// <summary>
        /// Evento para informar estado del Paquete.
        /// </summary>
        public event DelegadoEstado InformaEstado;

        /// <summary>
        /// Delegado para informar excepciones.
        /// </summary>
        public delegate void DelegadoException (Exception e);

        /// <summary>
        /// Evento para informar excepciones.
        /// </summary>
        public event DelegadoException InformaException;
        #endregion

        #region Enumerados
        /// <summary>
        /// Estados de un Paquete.
        /// </summary>
        public enum EEstado {
            Ingresado,  // 0
            EnViaje,    // 1
            Entregado   // 2
        }
        #endregion
    }
}