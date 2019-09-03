using System;

namespace Clase05.Entidades {

  public class Tinta {

    private ConsoleColor color;
    private ETipoTinta tipo;

    //////////////////////////////////////////////////

    public Tinta() {
      this.color = ConsoleColor.Blue;
      this.tipo = ETipoTinta.Común;
    }
    public Tinta(ConsoleColor color) : this() {
      this.color = color;
    }
    public Tinta(ConsoleColor color, ETipoTinta tipo) : this(color) {
      this.tipo = tipo;
    }

    //////////////////////////////////////////////////

    private string Mostrar() {
      return "Color: " + this.color + "\n" +
             "Tipo: " + this.tipo + "\n";
    }

    public static string Mostrar(Tinta unaTinta) {
      return unaTinta.Mostrar();
    }

    //////////////////////////////////////////////////

    public static bool operator ==(Tinta t1, Tinta t2) {

      if (!Object.Equals(t1, null) && !Object.Equals(t2, null)) {

        return (t1.color == t2.color && t1.tipo == t2.tipo);

      } else {

        if (Object.Equals(t1, null) && Object.Equals(t2, null)) {

          return true;

        } else {

          return false;

        }
      }      
    }

    public static bool operator !=(Tinta t1, Tinta t2) {
      return !(t1==t2);
    }


    public static bool operator ==(Tinta tinta, ConsoleColor color) {

      if ( !Object.Equals(tinta, null))
        return (tinta.color == color);
      else
        return false;      
    }
    public static bool operator !=(Tinta tinta, ConsoleColor color) {
      return !(tinta.color == color);
    }

    public static explicit operator string (Tinta tinta) {
      return tinta.Mostrar();
    }

  }

}
