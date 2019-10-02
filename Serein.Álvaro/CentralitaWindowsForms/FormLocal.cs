using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clase_12.CentralitaPolimorfismo;

namespace CentralitaWindowsForms {

    internal partial class FormLocal : Llamada {

        public FormLocal() {
            InitializeComponent();
        }

        protected override void btnAceptar_Click(object sender, EventArgs e) {
            string origen, destino;
            float duracion, costo;

            if (VerificarCampos() &&
                float.TryParse(this.txtDuracion.Text, out duracion) &&
                float.TryParse(this.txtCosto.Text, out costo)) {

                origen = this.txtOrigen.Text;
                destino = this.txtDestino.Text;

                this.llamada = new Local(origen, destino, duracion, costo);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        protected override bool VerificarCampos() {
            float aux;
            if (base.VerificarCampos() &&
                this.txtCosto.Text == "" &&
                !float.TryParse(this.txtDestino.Text, out aux)) {

                this.txtCosto.Focus();
                return false; ;
            }
            return true;
        }
    }
}
