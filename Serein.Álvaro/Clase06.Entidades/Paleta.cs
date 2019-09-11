using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_06.Entidades {

    public class Paleta {

        private Tempera[] colores;
        private int cantidadMaximaColores;

        //////////////////////////////////////////////////

        public int GetCantidad {
            get {
                return this.cantidadMaximaColores;
            }
        }

        //////////////////////////////////////////////////

        private Paleta() : this(5) { }

        private Paleta(int cantidad) {
            this.cantidadMaximaColores = cantidad;
            this.colores = new Tempera[cantidad];
        }

        //////////////////////////////////////////////////

        public static implicit operator Paleta(int cantidad) {

            if (cantidad > 0) {
                Paleta p = new Paleta(cantidad);
                return p;
            } else {
                return null;
            }
        }

        private string Mostrar() {

            string cadena = "Cantidad máxima: " + this.cantidadMaximaColores + "\n\n";

            foreach (Tempera t in this.colores) {
                cadena += t;
            }

            return cadena;
        }

        public static explicit operator string(Paleta paleta) {
            return paleta.Mostrar();
        }

        public static bool operator ==(Paleta paleta, Tempera tempera) {

            if (!Object.Equals(paleta, null) && !Object.Equals(tempera, null)) {

                foreach (Tempera t in paleta.colores) {

                    if (t == tempera) {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator !=(Paleta paleta, Tempera tempera) {
            return !(paleta == tempera);
        }

        public static Paleta operator +(Paleta paleta, Tempera tempera) {

            int index;
            if (paleta==tempera) {
                index = paleta.BuscarTemperaEnPaleta(tempera);
                paleta.colores[index] += tempera;
            } else {
                index = paleta.BuscarIndiceLibreEnPaleta();
                if (index >= 0)
                    paleta.colores[index] = tempera;
            }
            return paleta;
        }

        public static Paleta operator -(Paleta paleta, Tempera tempera) {

            int index;
            if (paleta==tempera) {

                index = paleta.BuscarTemperaEnPaleta(tempera);
                paleta.colores[index] -= tempera;
            }

            return paleta;
        }

        private int BuscarTemperaEnPaleta(Tempera t) {

            int index;

            for(index=0; index<this.cantidadMaximaColores; index++) {
                if (this.colores[index]==t) {
                    return index;
                }
            }
            return -1;
        }

        private int BuscarIndiceLibreEnPaleta() {

            int index;

            for(index=0; index<this.cantidadMaximaColores; index++) {
                if (Object.Equals(this.colores[index], null))
                    return index;
            }
            return -1;
        }

        public static int operator |(Paleta paleta, Tempera tempera)
        {
            if (paleta == tempera)
            {
                for (int i = 0; i < paleta.colores.Length; i++)
                {
                    if (paleta.colores[i] == tempera)
                        return i;
                }
            }
            return -1;
        }

        public Tempera this[int index] {
            get {
                return this.colores[index];
            }
            set {
                this.colores[index] = value;
            }
        }

    }
}