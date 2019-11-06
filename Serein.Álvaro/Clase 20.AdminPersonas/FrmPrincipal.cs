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

        ////////////////////////////////////////////////////////////////////////////////////////////////

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

                    /*  sqlDataReader[0]  columna ID
                        sqlDataReader[1] columna nombre
                        sqlDataReader[2]  columna apellido
                        sqlDataReader[3]  columna edad
                    */
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
/* Para ejecutar comandos sobre una base de datos se necesita primero tener la conexion establecida
 * con la base de datos
 * 
 * Para ejecutar un comando voy a tener que inicializar "SqlCommand", aca lo instancio con el constructo por defecto
 * El command necesita un objeto de tipo SqlConnection valido y que este abierto, para poder ejecutar un comando, se le asigna la coneccion con .Connection
 * El command  necesita saber que tipo de comando se va ejecutar sobre esa base de datos, se le asigna con .CommandType
 * 
 * */

/* CommandType: va a determinar el tipo de comando que voy a ejecutar a partir del enumerado
*
* .Text: es para indicar que voy a pasar una instruccion de sql, para ejecutarlo en el motor de base de datos, es codigo sql
* .TableDirect: va a esperar recibir el nombre de una tabla y devuelve el contenido de esa tabla 
* .StoredProcedure: es una funcion que se guarda dentro del motor de base de datos, va a esperar que se le pase el nombre de una funcion interna dentro de la base de datos
*/

// sqldatareader son de solo lectura y solo avance, no se puede retroceder
// .ExecuteReader() construye un tipo de dato SqlDataReader
