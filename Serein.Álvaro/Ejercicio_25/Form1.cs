using System;
using System.Windows.Forms;
using Ejercicio_13_lib;

namespace Ejercicio_25 {

    public partial class CBinDec : Form {

        Conversor conversor;
        NumeroBinario nBin;
        NumeroDecimal nDec;

        public CBinDec() {
            this.conversor = new Conversor();
            this.nBin = "";
            this.nDec = 0;
            InitializeComponent();
        }

        private void BtnDecimalABinario_Click(object sender, EventArgs e) {
            double aux;
            if (double.TryParse(txtDecimalABinario.Text, out aux)) {
                this.nDec = aux;
                txtResDecimalABinario.Text = Conversor.DecimalABinario((double)this.nDec);
            } else {
                txtDecimalABinario.Focus();
            }
        }

        private void BtnBinarioADecimal_Click(object sender, EventArgs e) {
            this.nBin = txtBinarioADecimal.Text;
            if (this.nBin.Validar())
                txtResBinarioADecimal.Text = Conversor.BinarioADecimal(this.nBin.GetNumero()).ToString();
            else
                txtBinarioADecimal.Focus();
        }
    }
}
