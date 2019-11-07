using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entidades;
using System.Data.SqlClient;

namespace AdminPersonas {

    public partial class frmVisorDataTable : frmVisorPersona
    {

        private DataTable dataTable;

        public DataTable DataTable { get => dataTable; }

        public frmVisorDataTable(DataTable dataTable) : base()
        {
            this.dataTable = dataTable;
            ActualizarLista();
        }

        protected override void btnAgregar_Click(object sender, EventArgs e) {
            frmPersona frm = new frmPersona();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK) {
                DataRow dataRow = this.dataTable.NewRow();
                ObtenerDatos(dataRow, frm.Persona);
                this.dataTable.Rows.Add(dataRow);
                ActualizarLista();
            }
        }

        protected override void btnModificar_Click(object sender, EventArgs e) {
            int index = lstVisor.SelectedIndex;

            if (lstVisor.SelectedIndex >= 0) {
                DataRow dataRow = this.dataTable.Rows[index];
                int aux = Convert.ToInt32(dataRow["edad"]);
                Persona persona = new Persona(dataRow["nombre"].ToString(),
                                              dataRow["apellido"].ToString(),
                                              aux);
                frmPersona frm = new frmPersona(persona);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK) {
                    this.lstVisor.Items.Remove(lstVisor.SelectedIndex);
                    ObtenerDatos(dataRow, frm.Persona);
                    AgregarAListBox(dataRow);
                }
                ActualizarLista();
            }
        }

        protected override void btnEliminar_Click(object sender, EventArgs e) {
            int index = lstVisor.SelectedIndex;

            if (lstVisor.SelectedIndex >= 0) {
                DataRow dataRow = this.dataTable.Rows[index];
                dataRow.Delete();
            }
            this.ActualizarLista();
        }

        private void AgregarAListBox(DataRow dataRow) {
            this.lstVisor.Items.Add("Nombre: " + dataRow[0] + " - Apellido: " + dataRow[1] + " - Edad: " + dataRow[2]);
        }
        private void ObtenerDatos(DataRow dataRow, Persona persona) {
            dataRow[0] = persona.nombre;
            dataRow[1] = persona.apellido;
            dataRow[2] = persona.edad;
        }
        private void ActualizarLista() {
            this.lstVisor.Items.Clear();
            foreach (DataRow dr in this.dataTable.Rows) {
                if (dr.RowState != DataRowState.Deleted)
                    AgregarAListBox(dr);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
