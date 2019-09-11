using System;
using System.Windows.Forms;
using Clase_06.Entidades;

namespace Clase07 {

    public partial class frmPaleta : Form {

        private Paleta paleta;

        public frmPaleta() {
            InitializeComponent();
        }

        private void crearPaletaToolStripMenuItem_Click(object sender, EventArgs e) {
            this.paleta = 5;
            this.gboxPaleta.Visible = true;
            this.tsPaleta.Enabled = false;
        }

        private void tsTempera_Click(object sender, EventArgs e) {
            frmTempera fT = new frmTempera();
            fT.ShowDialog();

            if (fT.DialogResult==DialogResult.OK) {
                this.paleta += fT.UnaTempera;
                this.listboxTemperas.Items.Clear();
                this.PaletaAListBox();
            }
            this.listboxTemperas.Visible = true;
            this.btnMenos.Visible = true;
            this.btnMas.Visible = true;
            this.btnModificar.Visible = true;
        }

        private void btnMas_Click(object sender, EventArgs e) {
            tsTempera_Click(sender, e);
        }

        private void btnMenos_Click(object sender, EventArgs e) {
            frmTempera fT = new frmTempera();
            fT.ShowDialog();

            if (fT.DialogResult == DialogResult.OK) {
                this.paleta -= fT.UnaTempera;
                this.PaletaAListBox();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            int index = this.listboxTemperas.SelectedIndex;
            if (index>=0) {
                frmTempera fT = new frmTempera(this.paleta[index]);
                fT.ShowDialog();

                if (fT.DialogResult == DialogResult.OK) {                    
                    this.paleta[index] = fT.UnaTempera;
                    this.PaletaAListBox();
                }
            } else {
                MessageBox.Show("Seleccione una témpera");
            }
        }

        private void PaletaAListBox() {
            byte f;
            this.listboxTemperas.Items.Clear();
            for (f = 0; f < this.paleta.GetCantidad; f++) {
                if (!Object.Equals(this.paleta[f], null))
                    this.listboxTemperas.Items.Add("" + this.paleta[f]);
            }
        }
    }
}

/*  PROPIEDADES
 *  ENUMERADO
 *  
 *  COMBO BOX
 *  LIST BOX
 *  GROUP BOX
 *  
 *  Pasar un objeto de un formulario a otro por propiedades
 *  Mdi parent
 *  Show y ShowDialog (show no cambia de contexto, showdialog sí)
 */

/*  INDEXADORES
 *  Array de algo que no es un array pero contiene un array (ej array de paleta es array de las temperas de paleta)
 *  public [tipo] this[int index]
 */
