using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_17.Entidades {

  public class Deposito<T> {

    private int _capacidadMaxima;
    private List<T> _lista;

    #region Constructores
    public Deposito(int capacidad) {
      this._capacidadMaxima = capacidad;
      this._lista = new List<T>();
    }
    #endregion

    #region Métodos
    private int GetIndice(T t) {
      for (int f = 0; f < this._lista.Count; f++) {
        if (this._lista[f].Equals(t))
          return f;
      }
      return -1;
    }
    #endregion

    #region Operadores
    public static bool operator +(Deposito<T> d, T t) {
      if (d._lista.Count < d._capacidadMaxima) {
        d._lista.Add(t);
        return true;
      } else {
        return false;
      }
    }

    public static bool operator -(Deposito<T> d, T t) {
      int index;
      index = d.GetIndice(t);

      if (index != -1) {
        d._lista.Remove(t);
        return true;
      } else {
        return false;
      }
    }

    public bool Agregar(T t) {
      return (this + t);
    }

    public bool Remover(T t) {
      return (this - t);
    }

    public override string ToString() {

      StringBuilder sb = new StringBuilder();
      sb.AppendLine("Capacidad máxima: " + this._capacidadMaxima);
      sb.AppendLine("Listado de " + typeof(T).Name.ToLower() + "s:");
      foreach (T a in this._lista) {
        sb.AppendLine(a.ToString());
      }
      return sb.ToString();
    }
    #endregion

  }
}
