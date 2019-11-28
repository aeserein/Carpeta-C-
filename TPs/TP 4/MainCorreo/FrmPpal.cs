using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entidades;

namespace MainCorreo {

    public partial class FrmPpal : Form {

        private Correo correo;

        #region Constructores
        /// <summary>
        /// Crea la interfaz de usuario.
        /// </summary>
        public FrmPpal() {
            InitializeComponent();
            this.correo = new Correo();
        }
        #endregion

        #region Métodos de interacción
        /// <summary>
        /// Agrega un Paquete al sistema.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregar_Click(object sender, EventArgs e) {
            Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
            paquete.InformaEstado += new Paquete.DelegadoEstado(paq_InformaEstado);
            paquete.InformaException += new Paquete.DelegadoException(paq_InformaException);
            try {
                correo += paquete;
            } catch (TrackingIdRepetidoException E) {
                MessageBox.Show(E.Message, "Paquete repetido", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            this.ActualizarEstados();
        }

        /// <summary>
        /// Cierra todos los hilos de ciclos de vida de Paquetes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e) {
            this.correo.FinEntregas();
        }

        /// <summary>
        /// Muestra todos los Paquetes en el sistema.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMostrarTodos_Click(object sender, EventArgs e) {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Muestra el Paquete seleccionado de la lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MostrarToolStripMenuItem_Click(object sender, EventArgs e) {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
        #endregion

        #region Métodos internos
        /// <summary>
        /// Actualiza las ListBox llamando al método ActualizarEstados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e) {
            if (this.InvokeRequired) {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            } else {
                this.ActualizarEstados();
            }
        }

        /// <summary>
        /// Actualiza las ListBox de acuerdo al estado de cada Paquete.
        /// </summary>
        private void ActualizarEstados() {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach (Paquete paquete in this.correo.Paquetes) {
                switch (paquete.Estado) {
                    case Paquete.EEstado.Ingresado: {
                        lstEstadoIngresado.Items.Add(paquete);
                        break;
                    }
                    case Paquete.EEstado.EnViaje: {
                        lstEstadoEnViaje.Items.Add(paquete);
                        break;
                    }
                    case Paquete.EEstado.Entregado: {
                        lstEstadoEntregado.Items.Add(paquete);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Muestra un Paquete o una lista de Paquetes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento) {
            if (!Object.Equals(elemento, null)) {
                if (elemento is Paquete)
                    this.rtbMostrar.Text = ((Paquete)elemento).MostrarDatos((Paquete)elemento);
                else if (elemento is Correo)
                    this.rtbMostrar.Text = ((Correo)elemento).MostrarDatos((Correo)elemento);

                if (!(this.rtbMostrar.Text.Guardar("salida.txt")))
                    MessageBox.Show("No se pudo guardar archivo de texto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Notifica que no se ha podido subir Paquetes a la base de datos.
        /// </summary>
        /// <param name="e">Excepción creada al no poder subir Paquetes a la base de datos.</param>
        private void paq_InformaException(Exception e) {
            MessageBox.Show(e.Message, "Error relacionado a la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        #endregion
    }
}