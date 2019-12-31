using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería_Segundo_Parcial {

    // Verificar uso de clase genérica
    interface IInterfaz_de_Guardar_Leer<T> {


        // Método de guardar T
        void Guardar(string archivo, T datos);


        // Método de leer T
        void Leer(string archivo, out T datos);

    }
}
