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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmPersona frm = new frmPersona();
            frm.StartPosition = FormStartPosition.CenterScreen;

            //implementar
            frm.ShowDialog();
            if(DialogResult.OK == frm.DialogResult)
            {
                this.lista.Add(frm.Persona);
                this.Actualizar();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int indice = lstVisor.SelectedIndex;
            if(lstVisor.SelectedIndex >= 0)
            {
                Persona per = lista[indice];
                frmPersona frm = new frmPersona(per);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                if(frm.DialogResult == DialogResult.OK)
                {
                    this.lista.Remove(per);
                    lista.Add(frm.Persona);
                }
                this.Actualizar();
            }

            //implementar
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmPersona frm = new frmPersona();
            frm.StartPosition = FormStartPosition.CenterScreen;
            int indice = this.lstVisor.SelectedIndex;
            //implementar
            if(indice >= 0)
            {
                this.lista.Remove(lista[indice]);
                this.Actualizar();
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
