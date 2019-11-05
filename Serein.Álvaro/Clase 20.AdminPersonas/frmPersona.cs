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
    public partial class frmPersona : Form
    {
        private Persona miPersona;

        public Persona Persona
        {
            get { return this.miPersona; }
            
        }

        public frmPersona()
        {
            InitializeComponent();
        }

        public frmPersona(Persona per):this()
        {
            miPersona = per;
            this.txtNombre.Text = per.nombre;
            this.txtApellido.Text = per.apellido;
            this.txtEdad.Text = per.edad.ToString();
        }

        protected void btnAceptar_Click(object sender, EventArgs e) {
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.ConexiónSQL);
            miPersona = new Persona(txtNombre.Text, txtApellido.Text, int.Parse(txtEdad.Text));
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
