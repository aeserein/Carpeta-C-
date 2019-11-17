using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Clase_22.Entidades;
using Clase_22;

namespace Clase_22.WF {

    public partial class frmEmpleado : Form {

        private Empleado empeladoDeEstaInstancia;

        public frmEmpleado() {
            InitializeComponent();
            this.cmbManejador.DataSource = Enum.GetValues(typeof(TipoManejador));
        }

        private void btnAceptar_Click(object sender, EventArgs e) {
            TipoManejador tipoManejador = (TipoManejador)this.cmbManejador.SelectedValue;

            int legajoAux;
            if (int.TryParse(txtLegajo.Text, out legajoAux)) {
                empeladoDeEstaInstancia = new Empleado(txtNombre.Text, txtApellido.Text, legajoAux);
            }

            switch (tipoManejador) {
                case TipoManejador.limiteSueldo :
                    this.empeladoDeEstaInstancia.limiteSueldo += new Delegado_LimiteSueldo(this.ManejadorLimiteSueldo);
                    break;
                case TipoManejador.limiteSueldoMejorado :
                    this.empeladoDeEstaInstancia.limiteSueldoMejorado += new Delegado_ConEventArgs(frmEmpleado.ManejadorDeLimiteSueldoMejorado);
                    this.empeladoDeEstaInstancia.limiteSueldoMejorado += new Delegado_ConEventArgs(this.ManejadorDeLimiteSueldoMejorado2);
                    break;
                case TipoManejador.Todos :
                    this.empeladoDeEstaInstancia.limiteSueldo += new Delegado_LimiteSueldo(this.ManejadorLimiteSueldo);
                    this.empeladoDeEstaInstancia.limiteSueldoMejorado += new Delegado_ConEventArgs(frmEmpleado.ManejadorDeLimiteSueldoMejorado);
                    this.empeladoDeEstaInstancia.limiteSueldoMejorado += new Delegado_ConEventArgs(this.ManejadorDeLimiteSueldoMejorado2);
                    break;
            }

            double sueldoAux;
            if (double.TryParse(txtSueldo.Text, out sueldoAux)) {
                this.empeladoDeEstaInstancia.Sueldo = sueldoAux;
            }
        }


        public void ManejadorLimiteSueldo(double sueldo, Empleado empleado) {
            MessageBox.Show("El empleado " + empleado.Nombre + " " + empleado.Apellido + "\n" +
                            "se rateó y se asignó un sueldo de " + sueldo + " mangos");
        }

        public static void ManejadorDeLimiteSueldoMejorado(Empleado empleado, EmpleadoEventArgs eea) {
            MessageBox.Show("Mejorado estático" + "\n" +
                            "El empleado " + empleado.Nombre + " " + empleado.Apellido + "\n" +
                            "se rateó y se asignó un sueldo de " + eea.SueldoAsignar + " mangos");
        }

        public void ManejadorDeLimiteSueldoMejorado2(Empleado empleado, EmpleadoEventArgs eea) {
            MessageBox.Show("Mejorado de instancia" + "\n" +
                            "El empleado " + empleado.Nombre + " " + empleado.Apellido + "\n" +
                            "se rateó y se asignó un sueldo de " + eea.SueldoAsignar + " mangos");
        }
    }
}
