using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_17.Entidades {

  public class Cocina {

    private int _codigo;
    private bool _esIndustrial;
    private double _precio;

    #region Propiedades
    public int Codigo { get => this._codigo; }
    public bool EsIndustrial { get => this._esIndustrial; }
    public double Precio { get => this._precio; }
    #endregion

    #region Constructores
    public Cocina(int codigo, double precio, bool esIndustrial) {
      this._codigo = codigo;
      this._esIndustrial = esIndustrial;
      this._precio = precio;
    }
    #endregion

    #region Métodos
    public override bool Equals(object obj) {
      return (this == (Cocina)obj);
    }

    public override string ToString() {
      return "Código: " + this.Codigo + " - Precio: " + this.Precio + " - Es industrial? " + this._esIndustrial;
    }
    #endregion

    #region Operadores
    public static bool operator ==(Cocina a, Cocina b) {
      try {
        return (a.Codigo == b.Codigo);
      } catch {
        return false;
      }
    }

    public static bool operator !=(Cocina a, Cocina b) {
      try {
        return !(a == b);
      } catch {
        return false;
      };
    }
    #endregion
  }
}
