using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace Entidades {

    public class Correo : IMostrar<List<Paquete>> {

        private List<Thread> mockPacketes;
        private List<Paquete> paquetes;

        #region Propiedades
        public List<Paquete> Paquetes {
            get => paquetes;
            set => paquetes = value;
        }
        #endregion

        #region Constructores
        public Correo() {
            this.mockPacketes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        #endregion

        #region Métodos
        public void FinEntregas() {
            foreach (Thread thread in this.mockPacketes) {
                thread.Abort();
            }
        }
        #endregion

        #region IMostrar
        public string MostrarDatos(IMostrar<List<Paquete>> elementos) {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete p in ((Correo)elementos).Paquetes) {
                sb.AppendLine(string.Format("{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado.ToString() ));
            }
            return sb.ToString();
        }
        #endregion

        #region Operadores
        public static Correo operator + (Correo c, Paquete p) {
            foreach (Paquete paquete in c.Paquetes) {
                if (paquete == p)
                    throw new TrackingIdRepetidoException("El paquete ya se encuentra en la lista.");
            }
            c.Paquetes.Add(p);

            Thread thread = new Thread(p.MockCicloDeVida);
            c.mockPacketes.Add(thread);

            thread.Start();

            return c;
        }
        #endregion
    }
}
