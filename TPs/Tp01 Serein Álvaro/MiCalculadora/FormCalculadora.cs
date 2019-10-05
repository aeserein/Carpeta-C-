using System;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora {

    /// <summary>
    /// Interfaz de la calculadora.
    /// </summary>
    public partial class FormCalculadora : Form {
        
        public FormCalculadora() {
            /* La consiga pide un constructor "public LaCalculadora()",
             * pero también pide que la clase se llame "FormCalculadora",
             * así que no uno de los dos tiene que cambiar para coincidir con el otro.
             */
            InitializeComponent();
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");
            this.cmbOperador.SelectedIndex = 0;
        }

        // Botón "Cerrar"
        private void BtnCerrar_Click(object sender, EventArgs e) {
            this.Close();
        }

        // Botón "Convertir a binario"
        private void BtnConvertirABinario_Click(object sender, EventArgs e) {
            string mensaje;
            double aux;
            long parteEntera;
            mensaje = Numero.DecimalBinario(this.lblResultado.Text);

            if (mensaje!="Valor inválido") {
                double.TryParse(this.lblResultado.Text, out aux);
                parteEntera = (long)aux;
                mensaje = "Decimal:\t" + parteEntera + "\n" +
                          "Binario:\t" + mensaje;
            }
            MessageBox.Show(mensaje);
        }

        // Botón "Convertir a decimal"
        private void BtnConvertirADecimal_Click(object sender, EventArgs e) {
            string mensaje;
            mensaje = Numero.BinarioDecimal(this.lblResultado.Text);

            if (mensaje!="Valor inválido") {
                mensaje = "Binario:\t" + this.lblResultado.Text + "\n" +
                          "Decimal:\t" + mensaje;
            }
            MessageBox.Show(mensaje);
        }

        // Botón "Limpiar"
        private void BtnLimpiar_Click(object sender, EventArgs e) {
            this.Limpiar();
        }

        // Botón "Operar"
        private void BtnOperar_Click(object sender, EventArgs e) {
            string n1, n2, operador;
            double resultado;

            if (this.txtNumero1.Text == "") {
                this.txtNumero1.Focus();
                return;
            } else {
                n1 = this.txtNumero1.Text;
            }

            if (this.cmbOperador.SelectedItem == null) {
                this.cmbOperador.Focus();
                return;
            } else {
                operador = this.cmbOperador.SelectedItem.ToString();
            }                

            if (this.txtNumero2.Text == "") {
                this.txtNumero2.Focus();
                return;
            } else {
                n2 = this.txtNumero2.Text;
            }

            double aux = 0;
            if (!double.TryParse(n1, out aux))
                txtNumero1.Text = "0";
            if (!double.TryParse(n2, out aux))
                txtNumero2.Text = "0";

            resultado = Operar(n1, n2, operador);

            if (resultado != double.MinValue)
                lblResultado.Text = resultado.ToString();
            else
                lblResultado.Text = "Error";
        }

        /// <summary>
        /// Limpia los campos de los operandos, la operación y el resultado.
        /// </summary>
        private void Limpiar() {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.ResetText();
            this.lblResultado.Text = "";
        }

        /// <summary>
        /// Realiza la operación entre los números y un operador. Todos strings.
        /// </summary>
        /// <param name="numero1">Operando</param>
        /// <param name="numero2">Operando</param>
        /// <param name="operador">Signo de la operación (+, -, *, /)</param>
        /// <returns>(double) Resultado</returns>
        private static double Operar(string numero1, string numero2, string operador) {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);
            double resultado;
            resultado = Calculadora.Operar(n1, n2, operador);
            return resultado;
        }
    }
}