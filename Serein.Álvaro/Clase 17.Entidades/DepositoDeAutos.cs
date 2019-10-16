using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_17.Entidades {

  public class DepositoDeAutos {

    private int _capacidadMaxima;
    private List<Auto> _lista;

    #region Constructores
    public DepositoDeAutos(int capacidad) {
      this._lista = new List<Auto>();
      this._capacidadMaxima = capacidad;
    }
    #endregion

    #region Métodos
    private int GetIndice(Auto a) {
      for (int f=0; f<this._lista.Count; f++) {
        if (this._lista[f] == a)
          return f;
      }
      return -1;
    }
    #endregion

    #region Operadores
    public static bool operator +(DepositoDeAutos d, Auto a) {
      if (d._lista.Count < d._capacidadMaxima) {
        d._lista.Add(a);
        return true;
      } else {
        return false;
      }
    }

    public static bool operator -(DepositoDeAutos d, Auto a) {
      int index;
      index = d.GetIndice(a);

      if (index != -1) {
        d._lista.Remove(a);
        return true;
      } else {
        return false;
      }
    }

    public bool Agregar(Auto a) {
      return (this + a);
    }

    public bool Remover(Auto a) {
      return (this - a);
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder();
      sb.AppendLine("Capacidad máxima: " + this._capacidadMaxima);
      sb.AppendLine("Listado de autos:");
      foreach (Auto a in this._lista) {
        sb.AppendLine(a.ToString());
      }
      return sb.ToString();
    }
    #endregion
  }
}
