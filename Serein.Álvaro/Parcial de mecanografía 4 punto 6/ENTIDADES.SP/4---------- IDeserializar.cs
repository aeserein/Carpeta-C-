using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENTIDADES.SP {

    public interface IDeserializar {

        bool Xml(string path, out Base NOMBRE_DE_BASE);
    }
}
