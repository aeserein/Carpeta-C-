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

    internal partial class FormProvincial : Llamada {

        public FormProvincial() {
            InitializeComponent();
            this.cmbFranja.DataSource = Enum.GetValues(typeof(Franja));
        }

        protected override void btnAceptar_Click(object sender, EventArgs e) {
            string origen, destino;
            float duracion;
            Franja franja;

            if (VerificarCampos() &&
                float.TryParse(this.txtDuracion.Text, out duracion)) {

                origen = this.txtOrigen.Text;
                destino = this.txtDestino.Text;
                franja = (Franja)cmbFranja.SelectedValue;

                this.llamada = new Provincial(origen, destino, duracion, franja);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
