using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Data.SqlClient;
using Entidades;

namespace AdminPersonas {

    public partial class FrmPrincipal : Form {

        private List<Persona> lista;

        private DataTable tablaPersonas;
        // Creo una tabla para trabajar de forma local.
        // Se puede cargar de cualquier forma, no solo por comandos SQL

        private void CargarDataTable() {

            string consulta = "SELECT * FROM Persona";
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.ConexiónSQL);
            SqlCommand sqlCommand = new SqlCommand();

            try {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = consulta;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                tablaPersonas.Load(sqlDataReader);
                sqlDataReader.Close();

            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }
            sqlConnection.Close();
        }

        public FrmPrincipal() {

            InitializeComponent();

            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;

            this.lista = new List<Persona>();
            this.tablaPersonas = new DataTable("Personas"); // Se le pone un nombre
            this.CargarDataTable();

            //lista.Add(new Persona("agus", "mendoza", 23));
            //lista.Add(new Persona("ana", "suarez", 24));
            //lista.Add(new Persona("pepito", "perez", 32));
        }

        private void cargarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //implementar...

            //  OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.ShowDialog();
            // System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Persona));
            // System.Xml.XmlTextWriter xmlTextWriter = new System.Xml.XmlTextWriter(openFileDialog.FileName, Encoding.UTF8);

            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog(); // para abrir
                openFileDialog.Filter = "Archivo|*.xml";
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Persona>));
                    using(XmlTextReader xmlTextReader = new XmlTextReader(openFileDialog.FileName))
                    {
                        lista = (List<Persona>)xmlSerializer.Deserialize(xmlTextReader);
                    }
                }
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void guardarEnArchivoToolStripMenuItem_Click(object sender, EventArgs e) {
            //implementar...
            try {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivo|*.xml";

                if(saveFileDialog.ShowDialog() == DialogResult.OK) {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Persona>));
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName, false);
                    xmlSerializer.Serialize(streamWriter, lista);
                    streamWriter.Close();
                }
            } catch(Exception x) {
                MessageBox.Show(x.Message);
            }
        }

        private void visualizarToolStripMenuItem_Click(object sender, EventArgs e) {
            frmVisorPersona frm = new frmVisorPersona(lista);
            frm.StartPosition = FormStartPosition.CenterScreen;
            //implementar
            frm.Show();
            this.lista = frm.Lista;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void conectarToolStripMenuItem_Click(object sender, EventArgs e) {
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.ConexiónSQL);
            
            try {
                sqlConnection.Open();
                MessageBox.Show("Conectado");
            } catch (Exception ee) {
                MessageBox.Show(ee.Message);
            }

            sqlConnection.Close();
        }

        private void traerTodosToolStripMenuItem_Click(object sender, EventArgs e) {
            string consulta = "SELECT * FROM Persona";
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.ConexiónSQL);
            SqlCommand sqlCommand = new SqlCommand();

            try {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = consulta;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while ( sqlDataReader.Read()) {
                    Persona persona = new Persona((string)sqlDataReader["nombre"], (string)sqlDataReader["apellido"], (int)sqlDataReader["edad"]);
                    MessageBox.Show(persona.ToString());
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

            sqlConnection.Close();
        }
    }
}
