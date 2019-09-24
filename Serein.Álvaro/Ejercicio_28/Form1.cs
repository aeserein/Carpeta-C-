using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_28 {

    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }

        private void BtnCalcular_Click(object sender, EventArgs e) {
            string[] palabras = richTextBox1.Text.Split(' ');
            Dictionary<string, int> diccionario = new Dictionary<string, int>();
            Dictionary<string, int> top3 = new Dictionary<string, int>();
            int iMax, index;
            string respuesta="";
            short f, i;
            
            for (f=0; f<palabras.Length; f++) {
                if (diccionario.ContainsKey(palabras[f])) {
                    diccionario[palabras[f]]++;
                } else {
                    diccionario.Add(palabras[f], 1);
                }
            }
           
            for (f=0; f<3; f++) {
                iMax = int.MinValue;
                index = -1;
                for (i=0; i<diccionario.Count; i++) {
                    if (diccionario.Values.ElementAt(i) >= iMax) {
                        index = i;
                        iMax = diccionario.Values.ElementAt(i);
                    }
                }
                if (index > -1) {
                    respuesta += diccionario.Keys.ElementAt(index) + " - " + diccionario.Values.ElementAt(index) + "\n";
                    diccionario.Remove(diccionario.Keys.ElementAt(index));
                }

            }

            if (respuesta!="")
                MessageBox.Show(respuesta);
        }
    }
}
