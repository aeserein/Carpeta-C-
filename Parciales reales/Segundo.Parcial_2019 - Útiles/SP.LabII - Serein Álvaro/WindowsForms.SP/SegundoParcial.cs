using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Entidades.SP;
using System.Data.SqlClient;
using System.IO;

namespace WindowsForms.SP {

    public partial class SegundoParcial : Form {

        private Lapiz lapiz;
        private Goma goma;
        private Sacapunta sacapunta;

        private Cartuchera<Utiles> c_utiles;
        private Cartuchera<Lapiz> c_lapices;
        private Cartuchera<Goma> c_gomas;


        private SqlConnection cn;
        private SqlDataAdapter da;
        private DataTable dt;

        public SegundoParcial() {
            InitializeComponent();

            this.dt = new DataTable("utiles");
            this.dt.Columns.Add("id", typeof(int));
            this.dt.Columns["id"].AutoIncrement = true;
            this.dt.Columns["id"].AutoIncrementSeed = 1;
            this.dt.Columns["id"].AutoIncrementStep = 1;

            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.AllowUserToAddRows = false;
        }

        private void SegundoParcial_Load(object sender, EventArgs e) {
            MessageBox.Show("Serein Álvaro Enuel");
        }

        //Crear la siguiente jerarquía de clases:
        //Utiles-> marca:string y precio:double (publicos); PreciosCuidados:bool (prop. s/l, abstracta);
        //constructor con 2 parametros y UtilesToString():string (protegido y virtual, retorna los valores del útil)
        //ToString():string (polimorfismo; reutilizar código)
        //Lapiz-> color:ConsoleColor(publico); trazo:ETipoTrazo(enum {Fino, Grueso, Medio}; publico); PreciosCuidados->true; 
        //Reutilizar UtilesToString en ToString() (mostrar todos los valores).
        //Goma-> soloLapiz:bool(publico); PreciosCuidados->true; 
        //Reutilizar UtilesToString en ToString() (mostrar todos los valores).
        //Sacapunta-> deMetal:bool(publico); 
        //Reutilizar UtilesToString en ToString() (mostrar todos los valores).
        private void btnPunto1_Click(object sender, EventArgs e) {
            //Crear una instancia de cada clase e inicializar los atributos del form lapiz, goma y sacapunta. 
            this.lapiz = new Lapiz(ConsoleColor.Green, Lapiz.ETipoTrazo.Grueso, "Sylvapen", 25.50);
            this.goma = new Goma(true, "Pelican", 30);
            this.sacapunta = new Sacapunta(true, 55.90, "Afiladitos");

            MessageBox.Show(this.lapiz.ToString());
            MessageBox.Show(this.goma.ToString());
            MessageBox.Show(this.sacapunta.ToString());            
        }

        //Crear la clase Cartuchera<T> -> restringir para que solo lo pueda usar Utiles o clases que deriven de Utiles
        //atributos: capacidad:int y elementos:List<T> (todos protegidos)        
        //Propiedades
        //Elementos:(sólo lectura) expone al atributo de tipo List<T>.
        //PrecioTotal:(sólo lectura) retorna el precio total de la cartuchera (la suma de los precios de sus elementos).
        //Constructor
        //Cartuchera(), Cartuchera(int); 
        //El constructor por default es el único que se encargará de inicializar la lista.
        //Métodos
        //ToString: Mostrará en formato de tipo string: 
        //el tipo de cartuchera, la capacidad, la cantidad actual de elementos, el precio total y el listado completo 
        //de todos los elementos contenidos en la misma. Reutilizar código.
        //Sobrecarga de operador
        //(+) Será el encargado de agregar elementos a la cartuchera siempre y cuando no supere la capacidad máxima de la misma.
        private void btnPunto2_Click(object sender, EventArgs e) {
            this.c_lapices = new Cartuchera<Lapiz>(3);
            this.c_gomas = new Cartuchera<Goma>(3);
            this.c_utiles = new Cartuchera<Utiles>(2);

            this.c_lapices += new Lapiz(ConsoleColor.Red, Lapiz.ETipoTrazo.Medio, "Faber-Castell", 32.25);
            this.c_lapices += new Lapiz(ConsoleColor.Blue, Lapiz.ETipoTrazo.Fino, "Paper Mate", 30);
            this.c_lapices += this.lapiz;

            this.c_gomas += this.goma;
            this.c_gomas += new Goma(false, "Dos banderas", 25);

            this.c_utiles += this.lapiz;
            this.c_utiles += this.goma;

            MessageBox.Show(this.c_lapices.ToString());
            MessageBox.Show(this.c_gomas.ToString());
            MessageBox.Show(this.c_utiles.ToString());            
        }

        //Agregar un elemento a la cartuchera de útiles, al superar la cantidad máxima, lanzará un CartucheraLlenaException (diseñarla), 
        //cuyo mensaje explicará lo sucedido.
        private void btnPunto3_Click(object sender, EventArgs e) {
            try {
                this.c_utiles += this.lapiz;
            } catch (CartucheraLlenaException ex) {
                //Agregar, para la clase CartucheraLlenaException, un método de extensión (InformarNovedad():string)
                //que retorne el mensaje de error
                MessageBox.Show(ex.InformarNovedad());
            }
        }

        //Si el precio total de la cartuchera supera los 85 pesos, se disparará el evento EventoPrecio. 
        //Diseñarlo (de acuerdo a las convenciones vistas) en la clase cartuchera. 
        //Adaptar la sobrecarga del operador +, para que lance el evento, según lo solicitado.
        //Crear el manejador necesario para que, una vez capturado el evento, se imprima en un archivo de texto: 
        //la fecha (con hora, minutos y segundos) y el total de la cartuchera (en un nuevo renglón). 
        //Se deben acumular los mensajes. El archivo se guardará con el nombre tickets.log en la carpeta 'Mis documentos' del cliente.
        //El manejador de eventos (c_gomas_EventoPrecio) invocará al método (de clase) 
        //ImprimirTicket (se alojará en la clase Ticketeadora), que retorna un booleano indicando si se pudo escribir o no
        private void btnPunto4_Click(object sender, EventArgs e) {
            this.c_gomas.eventoPrecio += c_gomas_EventoPrecio;
            this.c_gomas += new Goma(false, "Faber-Castell", 31);
        }

        private void c_gomas_EventoPrecio(object sender, EventArgs e) {
            bool todoOK = Ticketeadora.ImprimirTicket(this.c_gomas.PrecioTotal);    //Reemplazar por la llamada al método de clase ImprimirTicket

            if (todoOK) {
                MessageBox.Show("Ticket impreso correctamente!!!");
            } else {
                MessageBox.Show("No se pudo imprimir el ticket!!!");
            }
        }

        //configurar el OpenFileDialog, para poder seleccionar el log de tickets
        private void btnVerLog_Click(object sender, EventArgs e) {
            try {
                OpenFileDialog rta = new OpenFileDialog(); // para abrir
                rta.Filter = "Archivo|*.log";
                rta.Title = "Abrir archivo de tickets";
                rta.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if(rta.ShowDialog() == DialogResult.OK) {
                    StreamReader streamReader = new StreamReader(rta.FileName);
                    this.txtVisorTickets.Text = streamReader.ReadToEnd();
                }
            } catch(Exception x) {
                MessageBox.Show(x.Message);
            }            

            //titulo -> 'Abrir archivo de tickets'
            //directorio por defecto -> Mis documentos
            //tipo de archivo (filtro) -> .log
            //extensión por defecto -> .log
            //nombre de archovo (defecto) -> tickets            
        }

        //Crear las interfaces: 
        //#.-ISerializa -> Xml() : bool
        //              -> Path{ get; } : string
        //#.-IDeserializa -> Xml(out Lapiz) : bool
        //Implementar (implícitamente) ISerializa lápiz
        //Implementar (explícitamente) IDeserializa en lápiz
        //El archivo .xml guardarlo en el escritorio del cliente con el nombre formado con su apellido.nombre.lapiz.xml
        //Ejemplo: Alumno Juan Pérez -> perez.juan.lapiz.xml
        private void btnPunto5_Click(object sender, EventArgs e) {
            Lapiz aux = null;

            if (this.lapiz.Xml()) {
                MessageBox.Show("Lápiz serializado OK");
            } else {
                MessageBox.Show("Lápiz NO serializado");
            }

            if (((IDeserializa)this.lapiz).Xml(out aux)) {
                MessageBox.Show("Lápiz deserializado OK");
                MessageBox.Show(aux.ToString());
            } else {
                MessageBox.Show("Lápiz NO deserializado");
            }
        }

        //Obtener de la base de datos (sp_lab_II_utiles) el listado de útiles:
        //Tabla - utiles { id(autoincremental - numérico) - marca(cadena) - precio(numérico) - tipo(cadena) }.
        private void btnPunto6_Click(object sender, EventArgs e) {
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.ConexiónSQL);
            SqlCommand comandoSelect = new SqlCommand("SELECT * FROM utiles");

            da = new SqlDataAdapter(comandoSelect.CommandText, sqlConnection);

            this.da.Fill(this.dt);
            this.dataGridView1.DataSource = this.dt;            
        }

        private void btnPunto7_Click(object sender, EventArgs e) {
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.ConexiónSQL);
            SqlCommand comandoInsert = new SqlCommand();
            comandoInsert.CommandType = CommandType.Text;
            comandoInsert.CommandText = "INSERT INTO utiles VALUES(@arg1,@arg2,@arg3)";
            comandoInsert.Connection = sqlConnection;

            this.da.InsertCommand = comandoInsert;
            this.da.InsertCommand.Parameters.Add("@arg1", SqlDbType.VarChar, 50, "marca");
            this.da.InsertCommand.Parameters.Add("@arg2", SqlDbType.Float, 10, "precio");
            this.da.InsertCommand.Parameters.Add("@arg3", SqlDbType.VarChar, 50, "tipo");

            DataRow dr1 = this.dt.NewRow();
            dr1["marca"] = this.lapiz.marca;
            dr1["precio"] = this.lapiz.precio;
            dr1["tipo"] = this.lapiz.GetType().Name;

            DataRow dr2 = this.dt.NewRow();
            dr2["marca"] = this.goma.marca;
            dr2["precio"] = this.goma.precio;
            dr2["tipo"] = this.goma.GetType().Name;

            DataRow dr3 = this.dt.NewRow();
            dr3["marca"] = this.sacapunta.marca;
            dr3["precio"] = this.sacapunta.precio;
            dr3["tipo"] = this.sacapunta.GetType().Name;

            this.dt.Rows.Add(dr1);
            this.dt.Rows.Add(dr2);
            this.dt.Rows.Add(dr3);
        }

        //Eliminar del dataTable el primer registro
        private void btnPunto8_Click(object sender, EventArgs e) {
            //Configurar el deleteCommand del SqlDataAdapter y sus parametros
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.ConexiónSQL);
            SqlCommand comandoDelete = new SqlCommand();
            comandoDelete.CommandType = CommandType.Text;
            comandoDelete.CommandText = "DELETE FROM utiles WHERE id = @arg1";
            comandoDelete.Connection = sqlConnection;

            this.da.DeleteCommand = comandoDelete;
            this.da.DeleteCommand.Parameters.Add("@arg1", SqlDbType.Int, 10, "id");

            //Borrar el primer registro del dataTable
            this.dt.Rows[0].Delete();
        }

        //Modificar del dataTable el ultimo registro, cambiarlo por: marca:barrilito; precio:72
        private void btnPunto9_Click(object sender, EventArgs e) {

            //Configurar el updateCommand del SqlDataAdapter y sus parametros
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.ConexiónSQL);
            SqlCommand comandoUpdate = new SqlCommand();
            comandoUpdate.CommandType = CommandType.Text;
            comandoUpdate.CommandText = "UPDATE utiles SET marca=@arg1, precio=@arg2, tipo=@arg3 WHERE id=@arg0";
            comandoUpdate.Connection = sqlConnection;

            this.da.UpdateCommand = comandoUpdate;
            this.da.UpdateCommand.Parameters.Add("@arg1", SqlDbType.VarChar, 50, "marca");
            this.da.UpdateCommand.Parameters.Add("@arg2", SqlDbType.Float, 10, "precio");
            this.da.UpdateCommand.Parameters.Add("@arg3", SqlDbType.VarChar, 50, "tipo");
            this.da.UpdateCommand.Parameters.Add("@arg0", SqlDbType.Int, 10, "id");

            this.dt.Rows[this.dt.Rows.Count - 1]["marca"] = "Barrilito";
            this.dt.Rows[this.dt.Rows.Count - 1]["precio"] = 72;
            
        }

        //Sincronizar los cambios (sufridos en el dataTable) con la base de datos
        private void btnPunto10_Click(object sender, EventArgs e) {
            try {
                this.da.Update(this.dt);
                MessageBox.Show("Datos sincronizados!!!");
            } catch (Exception ex) {
                MessageBox.Show("No se ha sincronizado!!!\n" + ex.Message);
            }
        }
    }
}
