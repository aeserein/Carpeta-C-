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

        private DataTable dataTable;
        // Creo una tabla para trabajar de forma local.
        // Se puede cargar de cualquier forma, no solo por comandos SQL

        private SqlDataAdapter sqlDataAdapter;

        private void CargarDataTable() {

            string consulta = "SELECT * FROM Persona";
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.ConexiónSQL);
            SqlCommand sqlCommand = new SqlCommand();

            /*
            #region Offline
            this.dataTable.Columns.Add("nombre");
            this.dataTable.Columns.Add("apellido");
            this.dataTable.Columns.Add("edad");
            #endregion
            */

            
            #region Online
            try {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = consulta;

                sqlDataAdapter = new SqlDataAdapter(sqlCommand.CommandText, sqlConnection);
                sqlDataAdapter.Fill(this.dataTable);
                //El data adapter abre y cierra la conexión con Fill(dataTable);

                SqlCommand comandoInsert = new SqlCommand();
                comandoInsert.CommandType = CommandType.Text;
                comandoInsert.CommandText = "INSERT INTO Persona VALUES(@arg1,@arg2,@arg3)";
                comandoInsert.Connection = sqlConnection;
                sqlDataAdapter.InsertCommand = comandoInsert;
                sqlDataAdapter.InsertCommand.Parameters.Add("@arg1", SqlDbType.VarChar, 50, "nombre");
                sqlDataAdapter.InsertCommand.Parameters.Add("@arg2", SqlDbType.VarChar, 50, "apellido");
                sqlDataAdapter.InsertCommand.Parameters.Add("@arg3", SqlDbType.Int, 10, "edad");
                // 1º parámetro: Los "argX" deben coincidir con los parámetros del comando sql
                // 2º parámetro: Tipo de variable
                // 3º parámetro: longitud para visualizarse (?)
                // 4º parámetro: nombre de la variable en la base de datos

                SqlCommand comandoUpdate = new SqlCommand();
                comandoUpdate.CommandType = CommandType.Text;
                comandoUpdate.CommandText = "UPDATE Persona SET nombre = @arg1, apellido = @arg2, edad = @arg3 WHERE id = @arg0";
                comandoUpdate.Connection = sqlConnection;
                sqlDataAdapter.UpdateCommand = comandoUpdate;
                sqlDataAdapter.UpdateCommand.Parameters.Add("@arg1", SqlDbType.VarChar, 50, "nombre");
                sqlDataAdapter.UpdateCommand.Parameters.Add("@arg2", SqlDbType.VarChar, 50, "apellido");
                sqlDataAdapter.UpdateCommand.Parameters.Add("@arg3", SqlDbType.Int, 10, "edad");
                sqlDataAdapter.UpdateCommand.Parameters.Add("@arg0", SqlDbType.Int, 10, "id");

                SqlCommand comandoDelete = new SqlCommand();
                comandoDelete.CommandType = CommandType.Text;
                comandoDelete.CommandText = "DELETE FROM Persona WHERE id = @arg0";
                comandoDelete.Connection = sqlConnection;
                sqlDataAdapter.DeleteCommand = comandoDelete;
                sqlDataAdapter.DeleteCommand.Parameters.Add("@arg0", SqlDbType.Int, 10, "id");


                /*  Otra forma más simple de hacerlo
                sqlDataAdapter.InsertCommand = new SqlCommand("INSERT INTO Persona VALUES(@arg1,@arg2,@arg3)", sqlConnection);
                sqlDataAdapter.UpdateCommand = new SqlCommand("UPDATE Persona SET nombre = @arg1, apellido = @arg2, edad = @arg3 WHERE id = @arg0", sqlConnection);
                sqlDataAdapter.DeleteCommand = new SqlCommand("DELETE FROM Persona WHERE id = @arg0", sqlConnection);
                */


                /*
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                dataTable.Load(sqlDataReader);
                sqlDataReader.Close();
                */
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
            }
            sqlConnection.Close();
            #endregion
            
        }

        public FrmPrincipal() {

            InitializeComponent();

            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;

            this.lista = new List<Persona>();
            this.dataTable = new DataTable("Personas"); // Se le pone un nombre
            this.CargarDataTable();

            //lista.Add(new Persona("agus", "mendoza", 23));
            //lista.Add(new Persona("ana", "suarez", 24));
            //lista.Add(new Persona("pepito", "perez", 32));
        }

        private void cargarArchivoToolStripMenuItem_Click(object sender, EventArgs e) {
            //implementar...

            //  OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.ShowDialog();
            // System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Persona));
            // System.Xml.XmlTextWriter xmlTextWriter = new System.Xml.XmlTextWriter(openFileDialog.FileName, Encoding.UTF8);

            try {
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
            } catch(Exception x) {
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
            } catch (Exception eeeeeeeeeeeeeeeeeeeeeeeeeee_yooooooooo) {
                MessageBox.Show(eeeeeeeeeeeeeeeeeeeeeeeeeee_yooooooooo.Message);
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
                    this.lista.Add(persona);
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

        private void visorDTToolStripMenuItem_Click(object sender, EventArgs e) {
            frmVisorDataTable frmVisorDataTable = new frmVisorDataTable(this.dataTable);
            frmVisorDataTable.StartPosition = FormStartPosition.CenterScreen;
            frmVisorDataTable.Text = "Visor data table";
            frmVisorDataTable.Show();
        }

        private void sincronizarToolStripMenuItem_Click(object sender, EventArgs e) {
            this.sqlDataAdapter.Update(dataTable);
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

/*      EVENTOS
 * 
 *      Un método de evento puede tener cualquier modificador
 *      Pero tienen que tener la misma firma
 *          -> void Nombre(Object, Eventargs)
 *                  Object = Emisor del objeto. Se puede castear
 *                  Eventargs o derivada de eventArgs. Contiene información del evento, que es a partir del objeto
 *                      Puede contener cosas como tecla apretada
 *      
 *      DELEGADO
 *      
 *      Contiene direcciones de memoria de funciones
 *      Va a contener las direcciones de memoria de los manejadores de eventos en el formulario.
 *      Es un puntero a una función, solo se llama delegado porque .NET es un lenguaje de putos
 *      No puede alojar otra cosa que la firma con la que se lo define
 *          Para Winfows Forms va a tener la firma de los Windows Forms, pero puede tener otra firma para otras funciones
 *      Un delegado se crea automáticamente para asociar todos los eventos a los objetos de Windows Forms, cuando uno les hace doble click
 *          Es lo que hace el error cuando se hace doble click en algo y se borra el manejador
 */
