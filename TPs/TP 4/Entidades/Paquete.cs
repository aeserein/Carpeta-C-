using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace Entidades {

    class Paquete : IMostrar<Paquete> {

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        public event DelegadoEstado InformaEstado;

        #region Propiedades
        public string DireccionEntrega {
            get => direccionEntrega;
            set => direccionEntrega = value;
        }
        public string TrackingID {
            get => trackingID;
            set => trackingID = value;
        }
        public EEstado Estado {
            get => estado;
            set => estado = value;
        }
        #endregion

        #region Constructores
        public Paquete(string direccionEntrega, string trackingID) {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.estado = EEstado.Ingresado;
        }
        #endregion

        #region Métodos
        public override string ToString() {
            return this.MostrarDatos(this) + "\n" +
                   this.Estado.ToString();
        }
        public void MockCicloDeVida() {

            Thread.Sleep(4 * 1000);
            this.Estado = EEstado.EnViaje;
            this.InformaEstado(this, null);

            Thread.Sleep(4 * 1000);
            this.Estado = EEstado.Entregado;
            this.InformaEstado(this, null);

            ////////////////// Qué corren?
            ////////////////// Con Invoke?

            try {
                PaqueteDAO.Insertar(this);
            } catch (Exception e) {
                throw e;
            }

        }
        #endregion

        #region IMostrar
        public string MostrarDatos(IMostrar<Paquete> elemento) {
            return string.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
        }
        #endregion

        #region Operadores
        public static bool operator == (Paquete p1, Paquete p2) {
            return (p1.TrackingID == p2.TrackingID);
        }
        public static bool operator != (Paquete p1, Paquete p2) {
            return !(p1==p2);
        }
        #endregion

        #region Delegado
        public delegate void DelegadoEstado(object sender, EventArgs e);
        #endregion

        #region Enumerados
        public enum EEstado {
            Ingresado,  // 0
            EnViaje,    // 1
            Entregado   // 2
        }
        #endregion

    }
}
