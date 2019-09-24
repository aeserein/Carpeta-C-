using System;

namespace Clase09.Entidades {

    public class Capitulo {

        private int numero;
        private string titulo;
        private int paginas;
        private static Random generadorDeNumeros;
        private static Random generadorDePaginas;

        #region Propiedades
        public int GetNumero {
            get {
                return this.numero;
            }
        }
        public string GetTitulo {
            get {
                return this.titulo;
            }
        }
        public int GetPaginas {
            get {
                return this.paginas;
            }
        }
        #endregion

        #region Constructores
        static Capitulo() {
            Capitulo.generadorDeNumeros = new Random();
            Capitulo.generadorDePaginas = new Random();
        }
        private Capitulo(int numero, string titulo, int paginas) {
            this.numero = numero;
            this.titulo = titulo;
            this.paginas = paginas;
        }
        #endregion

        #region Operadores
        public static implicit operator Capitulo(string s) {
            int auxNumero, auxPaginas;
            auxNumero = Capitulo.generadorDeNumeros.Next(1, 66);
            auxPaginas = Capitulo.generadorDePaginas.Next(15, 234);
            return new Capitulo(auxNumero, s, auxPaginas);
        }
        public static bool operator ==(Capitulo c1, Capitulo c2) {
            return (c1.GetNumero == c2.GetNumero &&
                    c1.GetTitulo == c2.GetTitulo);
        }
        public static bool operator !=(Capitulo c1, Capitulo c2) {
            return !(c1 == c2);
        }
        #endregion
    }

}
