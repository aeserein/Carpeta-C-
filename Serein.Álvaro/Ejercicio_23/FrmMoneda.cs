using System;
using System.Windows.Forms;
using Moneda;

namespace Ejercicio_23 {

    public partial class FrmMoneda : Form {

        private Euro euro;
        private Dolar dolar;
        private Peso peso;
        private bool CotizacionLock;

        public FrmMoneda() {
            euro = 0;
            dolar = 0;
            peso = 0;
            this.CotizacionLock = false;
            InitializeComponent();
            txtCotizacionDolar.Text = Dolar.GetCotizacion().ToString();
            txtCotizacionEuro.Text = Euro.GetCotizacion().ToString();
            txtCotizacionPeso.Text = Peso.GetCotizacion().ToString();
        }

        private void BtnLockCotizacion_Click(object sender, EventArgs e) {
            this.CotizacionLock = !this.CotizacionLock;
            if (this.CotizacionLock == true) {
                lbl4.ImageIndex = 1;
                Campos_Enabled(false);
            } else {
                lbl4.ImageIndex = 0;
                Campos_Enabled(true);
            }
            
        }

        private void Campos_Enabled(bool modo) {
            txtCotizacionDolar.Enabled = modo;
            txtCotizacionPeso.Enabled = modo;
            txtCotizacionEuro.Enabled = modo;
        }

        ///////////////////////////////////////////////////////

        private void TxtCotizacionEuro_Leave(object sender, EventArgs e) {
            double aux = 0;
            if (double.TryParse(txtCotizacionEuro.Text, out aux))
                Euro.SetCotizacion(aux);
            else
                txtCotizacionEuro.Focus();
        }

        private void TxtCotizacionDolar_Leave(object sender, EventArgs e) {
            double aux = 0;
            if (double.TryParse(txtCotizacionDolar.Text, out aux))
                Dolar.SetCotizacion(aux);
            else
                txtCotizacionDolar.Focus();
        }

        private void TxtCotizacionPeso_Leave(object sender, EventArgs e) {
            double aux = 0;
            if (double.TryParse(txtCotizacionPeso.Text, out aux))
                Peso.SetCotizacion(aux);
            else
                txtCotizacionPeso.Focus();
        }

        ///////////////////////////////////////////////////////

        private void BtnConvertEuro_Click(object sender, EventArgs e) {
            double aux = 0;
            if (double.TryParse(txtEuro.Text, out aux)) {
                euro = aux;
                txtEuroAEuro.Text = euro;
                txtEuroADolar.Text = (Dolar)euro;
                txtEuroAPeso.Text = (Peso)euro;
            } else {
                txtEuro.Focus();
            }
        }

        private void BtnConvertDolar_Click(object sender, EventArgs e) {
            double aux = 0;
            if (double.TryParse(txtDolar.Text, out aux)) {
                dolar = aux;
                txtDolarADolar.Text = dolar;
                txtDolarAEuro.Text = (Euro)dolar;
                txtDolarAPeso.Text = (Peso)dolar;
            } else {
                txtEuro.Focus();
            }
        }

        private void BtnConvertPeso_Click(object sender, EventArgs e) {
            double aux = 0;
            if (double.TryParse(txtPeso.Text, out aux)) {
                peso = aux;
                txtPesoAPeso.Text = peso;
                txtPesoADolar.Text = (Dolar)peso;
                txtPesoAEuro.Text = (Euro)peso;
            } else {
                txtEuro.Focus();
            }
        }
    }
}
