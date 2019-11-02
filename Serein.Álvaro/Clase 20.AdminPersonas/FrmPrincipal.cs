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

using Entidades;

namespace AdminPersonas
{
    public partial class FrmPrincipal : Form
    {
        private List<Persona> lista;

        public FrmPrincipal()
        {
            InitializeComponent();

            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;

            this.lista = new List<Persona>();
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

        private void guardarEnArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //implementar...
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog(); //para guardar
                saveFileDialog.Filter = "Archivo|*.xml";
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Persona>));
                    using (XmlTextWriter stream = new XmlTextWriter(saveFileDialog.FileName, Encoding.UTF8))
                    {
                        xmlSerializer.Serialize(stream, lista);
                    }
                }
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void visualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVisorPersona frm = new frmVisorPersona(lista);

            frm.StartPosition = FormStartPosition.CenterScreen;

            //implementar

            frm.Show();

            this.lista = frm.Lista;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //implementar
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
