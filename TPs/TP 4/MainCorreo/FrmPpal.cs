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

        public FrmPpal() {
            InitializeComponent();
            this.correo = new Correo();
        }

        private void BtnAgregar_Click(object sender, EventArgs e) {
            Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
            paquete.InformaEstado += new Paquete.DelegadoEstado(paq_InformaEstado);
            try {
                correo += paquete;
            } catch (TrackingIdRepetidoException E) {
                MessageBox.Show(E.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.ActualizarEstados();
        }

        private void paq_InformaEstado(object sender, EventArgs e) {
            if (this.InvokeRequired) {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            } else {
                this.ActualizarEstados();
            }
        }

        private void ActualizarEstados() {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach(Paquete paquete in this.correo.Paquetes) {
                switch (paquete.Estado) {
                    case Paquete.EEstado.Ingresado : {
                        lstEstadoIngresado.Items.Add(paquete);
                        break;
                    }
                    case Paquete.EEstado.EnViaje : {
                        lstEstadoEnViaje.Items.Add(paquete);
                        break;
                    }
                    case Paquete.EEstado.Entregado : {
                        lstEstadoEntregado.Items.Add(paquete);
                        break;
                    }
                }
            }
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e) {
            this.correo.FinEntregas();
        }

        private void BtnMostrarTodos_Click(object sender, EventArgs e) {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void MostrarToolStripMenuItem_Click(object sender, EventArgs e) {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento) {
            if (!Object.Equals(elemento, null)) {
                if (elemento is Paquete)
                    rtbMostrar.Text = ((Paquete)elemento).MostrarDatos((Paquete)elemento);
                else if (elemento is Correo)
                    rtbMostrar.Text = ((Correo)elemento).MostrarDatos((Correo)elemento);

                rtbMostrar.Text.Guardar("salida.txt");
            }
        }
    }
}
