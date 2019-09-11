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
                this.listboxTemperas.Items.Add((string)paleta);
                this.listboxTemperas.Visible = true;
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