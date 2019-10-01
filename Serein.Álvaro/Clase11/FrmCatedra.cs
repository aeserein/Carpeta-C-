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

namespace WindowsForms {

    public partial class FrmCatedra : Form {

        private Catedra catedra;
        private List<AlumnoCalificado> alumnoCalificados;

        public FrmCatedra() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.cmbOrdenar.DataSource = Enum.GetValues(typeof(Catedra.ETipoOrdenamiento));
            this.cmbOrdenar.SelectedIndex = 0;
            this.catedra = new Catedra();
            this.alumnoCalificados = new List<AlumnoCalificado>();
            this.btnCalificar.Enabled = false;
            this.DialogResult = DialogResult.Yes;            
        }

        private void BtnAgregar_Click(object sender, EventArgs e) {
            FrmAlumno frm = new FrmAlumno();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK) {

                if(this.catedra + frm.Alumno) {
                    this.ActualizarListadoAlumnos();
                    this.btnCalificar.Enabled = true;
                    this.DialogResult = DialogResult.Yes;
                } else {
                    MessageBox.Show("Error. No se puede agregar el alumno.");
                }               
            }
        }

        private void ActualizarListadoAlumnos() {
            this.OrdenarAlumnos();
            this.lstAlumnos.Items.Clear();
            foreach(Alumno a in this.catedra.Alumnos) {
                this.lstAlumnos.Items.Add(a);
            }
        }

        private void BtnCalificar_Click(object sender, EventArgs e) {
            int index = this.lstAlumnos.SelectedIndex;

            if(index >= 0) {
                FrmAlumnoCalificado frmCalificado = new FrmAlumnoCalificado(this.catedra.Alumnos[index]);
                frmCalificado.ShowDialog();

                if (frmCalificado.DialogResult == DialogResult.OK &&
                    frmCalificado.AlumnoCalificado.Nota > 5) {

                    this.catedra.Alumnos.RemoveAt(index);
                    this.alumnoCalificados.Add(frmCalificado.AlumnoCalificado);
                    this.ActualizarListadoAlumnos();

                    this.lstAlumnosCalificados.Items.Clear();
                    foreach (AlumnoCalificado a in this.alumnoCalificados) {
                        this.lstAlumnosCalificados.Items.Add(a);
                    }
                }
            }
        }

        private void CmbOrdenar_SelectedIndexChanged(object sender, EventArgs e) {
            if(this.DialogResult == DialogResult.Yes) {
                this.ActualizarListadoAlumnos();
            }
        }

        private void OrdenarAlumnos() {
            switch (this.cmbOrdenar.SelectedIndex) {
                case 0:
                    this.catedra.Alumnos.Sort(Alumno.OrdenarPorLegajoAsc);
                    break;

                case 1:
                    this.catedra.Alumnos.Sort(Alumno.OrdenarPorLegajoDesc);
                    break;

                case 2:
                    this.catedra.Alumnos.Sort(Alumno.OrdenarPorApellidoAsc);
                    break;

                case 3:
                    this.catedra.Alumnos.Sort(Alumno.OrdenarPorApellidoDesc);
                    break;
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e) {

            Alumno alumnoSeleccionado = (Alumno)this.lstAlumnos.SelectedItem;
            int index = this.catedra.Alumnos.IndexOf(alumnoSeleccionado);
            FrmAlumno frmModificar = new FrmAlumno(alumnoSeleccionado);
            frmModificar.ShowDialog();

            if (frmModificar.DialogResult == DialogResult.OK && index>=0) {

                alumnoSeleccionado = frmModificar.Alumno;
                this.catedra.Alumnos[index] = alumnoSeleccionado;
                ActualizarListadoAlumnos();
            }
        }
    }
}