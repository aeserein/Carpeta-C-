using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_48.Entidades;

namespace Ejercicio_48 {

  class Program {

    static void Main(string[] args) {

      Contabilidad<Factura, Recibo> contabilidad = new Contabilidad<Factura, Recibo>();
      Factura f1 = new Factura(5);
      Recibo r1 = new Recibo();

      contabilidad += f1;
      contabilidad += r1;

    }
  }
}
