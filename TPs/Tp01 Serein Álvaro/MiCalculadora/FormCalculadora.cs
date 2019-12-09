using System;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora {

    /// <summary>
    /// Interfaz de la calculadora.
    /// </summary>
    public partial class FormCalculadora : Form {
        
        /// <summary>
        /// Inicializa el formulario y sus campos.
        /// </summary>
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

        /// <summary>
        /// Cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCerrar_Click(object sender, EventArgs e) {
            this.Close();
        }

        /// <summary>
        /// Convierte el resultado a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConvertirABinario_Click(object sender, EventArgs e) {
            string mensaje;
            mensaje = Numero.DecimalBinario(this.lblResultado.Text);
            this.lblResultado.Text = mensaje;
        }

        /// <summary>
        /// Convierte el resultado a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConvertirADecimal_Click(object sender, EventArgs e) {
            string mensaje;
            mensaje = Numero.BinarioDecimal(this.lblResultado.Text);
            this.lblResultado.Text = mensaje;
        }

        /// <summary>
        /// Limpia los campos del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLimpiar_Click(object sender, EventArgs e) {
            this.Limpiar();
        }

        /// <summary>
        /// Realiza la operación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOperar_Click(object sender, EventArgs e) {
            string n1, n2, operador;
            double resultado;

            #region Chequear campos vacíos y asignar
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
            #endregion
            #region Corregir TextBoxes si tienen letras
            double aux = 0;
            if (!double.TryParse(n1, out aux))
                txtNumero1.Text = "0";
            if (!double.TryParse(n2, out aux))
                txtNumero2.Text = "0";
            #endregion

            resultado = FormCalculadora.Operar(n1, n2, operador);
            lblResultado.Text = resultado.ToString();

            /*
             * Esto fue corregido como mal,
             * tal que la implementación correcta supuestamente sea x / 0 = double.MinValue;
             * En lugar de un resultado "Error" o "E"
             * 
            if (resultado != double.MinValue)
                lblResultado.Text = resultado.ToString();
            else
                lblResultado.Text = "Error";
            */
        }

        /// <summary>
        /// Limpia los campos del formulario.
        /// </summary>
        private void Limpiar() {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.ResetText();
            this.lblResultado.Text = "";
            this.txtNumero1.Focus();
        }

        /// <summary>
        /// Realiza la operación.
        /// </summary>
        /// <param name="numero1">Primer número a operar.</param>
        /// <param name="numero2">Segundo número a operar.</param>
        /// <param name="operador">Operación a realizar.</param>
        /// <returns>Resultado de la operación.</returns>
        private static double Operar(string numero1, string numero2, string operador) {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);
            return Calculadora.Operar(n1, n2, operador);
        }
    }
}