using System;
using System.Collections.Generic;
using System.Text;

namespace Clase05.Entidades {

  public class Pluma {

    private string _marca;
    private Tinta _tinta;
    private int _cantidad;

    ///////////////////////////////////////////////

    public Pluma() {
      this._marca = "Sin Marca";
      this._tinta = null;
      this._cantidad = 0;
    }
    public Pluma(string marca) : this() {
      this._marca = marca;
    }
    public Pluma(string marca, Tinta tinta) : this(marca) {
      this._tinta = tinta;
    }
    public Pluma(string marca, Tinta tinta, int cantidad) : this(marca, tinta) {
      this._cantidad = cantidad;
    }

    ///////////////////////////////////////////////

    private string Mostrar() {
      return "Marca: " + this._marca + "\n" +
             "Tinta: " + (string)this._tinta + "\n" +
             "Cantidad: " + this._cantidad + "\n";
    }

    public static implicit operator string(Pluma p) {
      return p.Mostrar();
    }

    //////////////////////////////////////////////////

    public static bool operator ==(Pluma p, Tinta t) {

      if (!Object.Equals(p, null) && !Object.Equals(t, null)) {

        return (p._tinta == t);

      } else {

        if (Object.Equals(p, null) && Object.Equals(t,null)) {

          return true;

        } else {

          return false;
        }
      }
      
    }
    public static bool operator !=(Pluma p, Tinta t) {
      return !(p == t);
    }

    public static Pluma operator +(Pluma p, Tinta t) {
      if (p==t && p._cantidad<100) {
        p._cantidad++;
      }
      return p;
    }
  }
}
