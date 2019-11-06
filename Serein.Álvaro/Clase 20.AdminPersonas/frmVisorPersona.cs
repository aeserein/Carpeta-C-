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

namespace AdminPersonas
{
    public partial class frmVisorPersona : Form
    {
        List<Persona> lista;

        public List<Persona> Lista
        {
            get
            {
                return this.lista;
            }
        }

        public frmVisorPersona(List<Persona> lista)
        {
            InitializeComponent();
            this.lista = lista;
            this.Actualizar();
        }

        private void btnAgregar_Click(object sender, EventArgs e) {
            frmPersona frm = new frmPersona();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();

            if (DialogResult.OK == frm.DialogResult) {
                this.lista.Add(frm.Persona);
                this.Actualizar();

                try {
                    SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.ConexiónSQL);
                    SqlCommand sqlCommand = new SqlCommand();
                    string consulta = "INSERT INTO Persona VALUES('{frm.Persona.nombre}','{frm.Persona.apellido}',{frm.Persona.edad})";

                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = consulta;
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                } catch (Exception E) {
                    MessageBox.Show(E.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnModificar_Click(object sender, EventArgs e) {

            int index = lstVisor.SelectedIndex;

            if(lstVisor.SelectedIndex >= 0) {
                Persona persona = lista[index];
                frmPersona frm = new frmPersona(persona);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();

                if(frm.DialogResult == DialogResult.OK) {
                    this.lista.Remove(persona);
                    lista.Add(frm.Persona);

                    try {
                        SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.ConexiónSQL);
                        SqlCommand sqlCommand = new SqlCommand();
                        string consulta = "UPDATE Persona SET nombre = '{frm.Persona.nombre}', apellido = '{frm.Persona.apellido}', edad = {frm.Persona.edad}  WHERE id = {indice + 1}";

                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = consulta;
                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();

                    } catch (Exception E) {
                        MessageBox.Show(E.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                this.Actualizar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) {

            frmPersona frm = new frmPersona();
            frm.StartPosition = FormStartPosition.CenterScreen;
            int index = this.lstVisor.SelectedIndex;

            if(index >= 0) {
                this.lista.Remove(lista[index]);
                this.Actualizar();

                try {
                    SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.ConexiónSQL);
                    SqlCommand sqlCommand = new SqlCommand();
                    string consulta = "DELETE FROM Persona WHERE id = {index + 1}";

                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = consulta;
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();

                } catch (Exception E) {
                    MessageBox.Show(E.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Actualizar()
        {
            this.lstVisor.Items.Clear();
            foreach(Persona value in lista)
            {
                this.lstVisor.Items.Add(value.ToString());
            }
        }
    }
}
