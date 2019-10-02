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

    public partial class FrmCentralita : Form {

        private List<Clase_12.CentralitaPolimorfismo.Llamada> listaDeLlamadas;

        public FrmCentralita() {
            this.listaDeLlamadas = new List<Clase_12.CentralitaPolimorfismo.Llamada>();
            InitializeComponent();
            this.cboOrdenamiento.Items.Add("Duración - Ascendente");
            this.cboOrdenamiento.Items.Add("Duración - Descendente");
            this.cboOrdenamiento.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e) {
            FormLocal frm = new FormLocal();
            frm.ShowDialog();

            if (frm.DialogResult==DialogResult.OK &&
                !Object.Equals(frm.llamada, null)) {

                this.listaDeLlamadas.Add(frm.llamada);
                this.ActualizarLista();
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            FormProvincial frm = new FormProvincial();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK &&
                !Object.Equals(frm.llamada, null)) {

                this.listaDeLlamadas.Add(frm.llamada);
                this.ActualizarLista();
            }
        }

        private void cboOrdenamiento_SelectedIndexChanged(object sender, EventArgs e) {
            this.ActualizarLista();
        }

        private void ActualizarLista() {
            this.OrdenarLista();
            this.lstVisor.Items.Clear();
            foreach (Clase_12.CentralitaPolimorfismo.Llamada l in listaDeLlamadas)
                this.lstVisor.Items.Add(l);
        }
        
        private void OrdenarLista() {
            switch(this.cboOrdenamiento.SelectedIndex) {
                case 0 : {
                    listaDeLlamadas.Sort(Clase_12.CentralitaPolimorfismo.Llamada.OrdenarPorDuracionAscendente);
                    break;
                }
                case 1 : {
                    listaDeLlamadas.Sort(Clase_12.CentralitaPolimorfismo.Llamada.OrdenarPorDuracionDescendente);
                    break;
                }
            }
        }
    }
}
