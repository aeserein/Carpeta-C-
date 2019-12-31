using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.SP
{
    public interface ISerializa
    {
        bool Xml();
        string Path{ get; }
    }
}
