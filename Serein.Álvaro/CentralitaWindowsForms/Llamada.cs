using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CentralitaWindowsForms {

    internal abstract partial class Llamada : Form {

        internal Clase_12.CentralitaPolimorfismo.Llamada llamada;

        public Llamada() {
            InitializeComponent();
        }

        protected void btnCancelar_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected abstract void btnAceptar_Click(object sender, EventArgs e);

        protected virtual bool VerificarCampos() {
            float aux;
            if (this.txtOrigen.Text == "") {
                this.txtOrigen.Focus();
                return false;
            }
            if (this.txtDestino.Text == "") {
                this.txtDestino.Focus();
                return false;
            }
            if (this.txtDuracion.Text == "" ||
                !float.TryParse(this.txtDestino.Text, out aux)) {
                this.txtDuracion.Focus();
                return false;
            }
            return true;
        }
    }
}
