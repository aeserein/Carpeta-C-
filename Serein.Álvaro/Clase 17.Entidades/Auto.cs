using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_17.Entidades
{

  public class Auto
  {

    private string _color;
    private string _marca;

    #region Propiedades
    public string Color
    {
      get => this._color;
    }
    public string Marca
    {
      get => _marca;
    }
    #endregion

    #region Constructores
    public Auto(string color, string marca)
    {
      this._color = color;
      this._marca = marca;
    }
    #endregion

    #region Métodos
    public override bool Equals(object obj) {
      return (this==(Auto)obj);
    }

    public override string ToString() {
      return "Marca: " + this.Marca + " - Color: " + this.Color;
    }
    #endregion

    #region Operadores
    public static bool operator ==(Auto a, Auto b) {
      try {
        return (a.Marca == b.Marca &&
                a.Color == b.Color);
      } catch {
        return false;
      }
    }

    public static bool operator !=(Auto a, Auto b) {
      return !(a == b);
    }
    #endregion

  }
}
