using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_33 {

    class Libro {

        private List<string> paginas = new List<string>();
        
        public string this[int index] {
            get {
                if (index >= 0 && index < paginas.Count)
                    return this.paginas[index];
                else
                    return "";
            }
            set {
                if (index >= 0 && index < paginas.Count)
                    this.paginas[index] = value;
                else if (index >= paginas.Count)
                    this.paginas.Add(value);
            }
        }
    }
}
