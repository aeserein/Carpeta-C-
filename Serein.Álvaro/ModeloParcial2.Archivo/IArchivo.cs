using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial2.Archivo {

    interface IArchivo<T> {

        void Guardar(string archivo, T datos);
        void Leer(string archivo, out T datos);
    }
}
