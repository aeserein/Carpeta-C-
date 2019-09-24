using System;
using System.Collections.Generic;

namespace Clase09.Entidades {

    class Libro {

        private string titulo;
        private string autor;
        private List<Capitulo> capitulos;

        #region Propiedades
        public string Titulo {
            get {
                return this.titulo;
            }
        }
        public string Autor {
            get {
                return this.autor;
            }
        }
        public int CantidadPaginas {
            get {
                int cantidad = 0;
                foreach(Capitulo c in this.capitulos) {
                    cantidad += c.GetPaginas;
                }
                return cantidad;
            }
        }
        public int CantidadCapitulos {
            get {
                return this.capitulos.Count;
            }
        }
        #endregion

        #region Constructores
        public Libro(string titulo, string autor) {
            this.titulo = titulo;
            this.autor = autor;
            this.capitulos = new List<Capitulo>();
        }
        #endregion

        #region Indexadores
        public Capitulo this[int index] {
            get {
                if (index < 0 || index >= this.CantidadCapitulos)
                    return null;
                else
                    return this.capitulos[index];
            }
            set {
                if (index == this.CantidadCapitulos)
                    this.capitulos.Add(value);
                else if (index < 0 || index > this.CantidadCapitulos)
                    return;
                else
                    this.capitulos[index] = value;
            }
        }
        #endregion
    }

}
