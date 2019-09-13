using System;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora {

    public partial class FormCalculadora : Form {

        public FormCalculadora() {
            InitializeComponent();
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");
        }

        private void BtnCerrar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void BtnConvertirABinario_Click(object sender, EventArgs e) {
            string mensaje;

            switch (this.lblResultado.Text) {
                case "": {
                    mensaje = "Calcule una operación antes de convertir el resultado.";
                    break;
                }
                case "Error": {
                    mensaje = "No se puede convertir a binario.";
                    break;
                }
                default: {
                    mensaje = this.lblResultado.Text + " (decimal)\n" +
                              Numero.DecimalBinario(this.lblResultado.Text) + " (binario)";
                    break;
                }
            }
            MessageBox.Show(mensaje);
        }

        private void BtnConvertirADecimal_Click(object sender, EventArgs e) {
            string mensaje;

            switch (this.lblResultado.Text) {
                case "": {
                    mensaje = "Calcule una operación antes de convertir el resultado.";
                    break;
                }
                case "Error": {
                    mensaje = "Solo números compuestos por unos y ceros son convertibles a decimal.";
                    break;
                }
                default: {
                    mensaje = this.lblResultado.Text + " (binario)\n" +
                              Numero.BinarioDecimal(this.lblResultado.Text) + " (decimal)";
                    break;
                }
            }
            MessageBox.Show(mensaje);
        }

        private void BtnLimpiar_Click(object sender, EventArgs e) {
            this.Limpiar();
        }

        private void BtnOperar_Click(object sender, EventArgs e) {
            string n1, n2, operador;
            double resultado;

            n1 = this.txtNumero1.Text;
            n2 = this.txtNumero2.Text;
            operador = this.cmbOperador.SelectedItem.ToString();
            resultado = Operar(n1, n2, operador);

            if (resultado != double.MinValue)
                lblResultado.Text = resultado.ToString();
            else
                lblResultado.Text = "Error";
        }

        private void Limpiar() {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.ResetText();
            this.lblResultado.Text = "";
        }

        private static double Operar(string numero1, string numero2, string operador) {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);
            double resultado;
            resultado = Calculadora.Operar(n1, n2, operador);
            return resultado;
        }
    }
}
