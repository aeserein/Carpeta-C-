using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_17.Entidades {

  public class DepositoDeCocinas {

    private int _capacidadMaxima;
    private List<Cocina> _lista;

    #region Constructores
    public DepositoDeCocinas(int capacidad) {
      this._capacidadMaxima = capacidad;
      this._lista = new List<Cocina>();
    }
    #endregion

    #region Métodos
    private int GetIndice(Cocina c) {
      for (int f = 0; f < this._lista.Count; f++) {
        if (this._lista[f] == c)
          return f;
      }
      return -1;
    }
    #endregion

    #region Operadores
    public static bool operator +(DepositoDeCocinas d, Cocina c) {
      if (d._lista.Count < d._capacidadMaxima) {
        d._lista.Add(c);
        return true;
      } else {
        return false;
      }
    }

    public static bool operator -(DepositoDeCocinas d, Cocina c) {
      int index;
      index = d.GetIndice(c);

      if (index != -1) {
        d._lista.Remove(c);
        return true;
      } else {
        return false;
      }
    }

    public bool Agregar(Cocina c) {
      return (this + c);
    }

    public bool Remover(Cocina c) {
      return (this - c);
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder();
      sb.AppendLine("Capacidad máxima: " + this._capacidadMaxima);
      sb.AppendLine("Listado de autos:");
      foreach (Cocina a in this._lista) {
        sb.AppendLine(a.ToString());
      }
      return sb.ToString();
    }
    #endregion

  }
}
