using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_31 {

    class Negocio {

        private PuestoAtencion caja;
        private Queue<Cliente> clientes;
        private string nombre;


        private Negocio() {
            this.clientes = new Queue<Cliente>();
            this.caja = new PuestoAtencion(Puesto.Caja1);
        }
        public Negocio(string nombre) : this() {
            this.nombre = nombre;
        }

        public Cliente Cliente {
            get {
                return this.clientes.Dequeue();
            }
            set {
                if (this!=value) {
                    this.clientes.Enqueue(value);
                }
            }
        }
        public int ClientesPendientes {
            get {
                return this.clientes.Count;
            }
        }


        public static bool operator +(Negocio n, Cliente c) {
            if (n!=c) {
                n.clientes.Enqueue(c);
                return true;
            } else {
                return false;
            }
        }
        public static bool operator ==(Negocio n, Cliente c) {
            foreach (Cliente cliente in n.clientes) {
                if (c == cliente)
                    return true;
            }
            return false;
        }
        public static bool operator !=(Negocio n, Cliente c) {
            return !(n==c);
        }
        public static bool operator~(Negocio n) {
            Cliente c = n.Cliente;
            return n.caja.Atender(c);
        }
    }
}
