using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clase_06.Entidades;

namespace Clase07 {

    public partial class frmTempera : Form {

        private Tempera t;

        public Tempera UnaTempera {
            get {
                return t;
            }
        }

        public frmTempera(Tempera t) : this() {
            this.txtMarca.Text = t.GetMarca;
            this.txtCantidad.Text = t.GetCantidad.ToString();
            this.cbColor.SelectedItem = t.GetColor;
        }

        public frmTempera() {
            InitializeComponent();

            foreach(ConsoleColor c in Enum.GetValues(typeof(ConsoleColor))) {
                this.cbColor.Items.Add(c);
            }
            this.cbColor.SelectedItem = ConsoleColor.Magenta;
        }

        private void btnAceptar_Click(object sender, EventArgs e) {
            string marca;
            if (txtMarca.Text != "") {
                marca = txtMarca.Text;
            } else {
                txtMarca.Focus();
                return;
            }

            int cantidad;
            if (int.TryParse(txtCantidad.Text, out cantidad)) {
                //parsea3
            } else {
                txtCantidad.Focus();
                return;
            }

            ConsoleColor color = (ConsoleColor)cbColor.SelectedItem;

            this.t = new Tempera(color, marca, cantidad);

            MessageBox.Show(this.t);
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
