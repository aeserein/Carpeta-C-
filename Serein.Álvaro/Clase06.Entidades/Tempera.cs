using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_06.Entidades
{
    public class Tempera
    {
        private ConsoleColor color;
        private string marca;
        private int cantidad;

        //////////////////////////////////////////////////

        public ConsoleColor GetColor {
            get {
                return this.color;
            }
        }
        public string GetMarca {
            get {
                return this.marca;
            }
        }
        public int GetCantidad {
            get {
                return this.cantidad;
            }
        }

        public Tempera(ConsoleColor color, string marca, int cantidad) {
            this.cantidad = cantidad;
            this.color = color;
            this.marca = marca;
        }

        private string Mostrar() {
            return "Marca:\t" + this.marca + "\n" +
                   "Cantidad:\t" + this.cantidad + "\n" +
                   "Color:\t" + this.color + "\n\n";
        }

        public static implicit operator string(Tempera tempera) {

            if (!Object.Equals(tempera, null)) {
                return tempera.Mostrar();
            } else {
                return "";
            }
        }

        public static bool operator ==(Tempera tempera, Tempera tempera2) {

            if (!Object.Equals(tempera, null) &&
                !Object.Equals(tempera2, null) &&
                tempera.marca == tempera2.marca &&
                tempera.color == tempera2.color) {

                return true;
            }

            return false;
        }

        public static bool operator !=(Tempera tempera, Tempera tempera2) {
            return !(tempera == tempera2);
        }

        public static Tempera operator +(Tempera t, int cantidad) {

            if (!Object.Equals(t, null) && cantidad>0) {

                t.cantidad += cantidad;
            }
            return t;
        }

        public static Tempera operator +(Tempera tempera1, Tempera tempera2) {

            if (tempera1 == tempera2) {
                return (tempera1 + tempera2.cantidad);
            } else {
                return tempera1;
            }
        }

        public static Tempera operator -(Tempera tempera1, Tempera tempera2) {

            int cantidad;
            if (tempera1 == tempera2) {

                if (tempera1.cantidad - tempera2.cantidad < 0)
                    return null;
                else {
                    cantidad = tempera1.cantidad - tempera2.cantidad;
                    tempera1.cantidad = cantidad;
                    return tempera1;
                }                
            }
            return tempera1;            
        }
    }
}