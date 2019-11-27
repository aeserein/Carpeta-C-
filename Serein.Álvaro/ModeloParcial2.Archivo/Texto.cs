using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModeloParcial2.Entidades;
using System.IO;

namespace ModeloParcial2.Archivo {

    public class Texto : IArchivo<Queue<Patente>> {

        public void Guardar(string archivo, Queue<Patente> datos) {

            StreamWriter streamWriter = null;
            try {
                streamWriter = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo + ".txt", false);
                foreach (Patente patente in datos) {

                    //streamWriter.WriteLine(patente.ToString());
                    streamWriter.WriteLine(patente.CodigoPatente);
                }
            } catch (Exception e) {
                throw;
            } finally {
                streamWriter.Close();
            }

        }

        public void Leer(string archivo, out Queue<Patente> datos) {

            StreamReader streamReader = null;
            Queue<Patente> auxPatentes = null;

            string aux;
            try {
                streamReader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo + ".txt");
                while ( (aux = streamReader.ReadLine()) != null) {
                    Patente p = PatenteStringExtension.ValidarPatente(aux);
                    auxPatentes.Enqueue(p);
                    aux = null;
                }
                datos = auxPatentes;
            } catch (Exception e) {
                throw;
            } finally {
                streamReader.Close();
            }
        }
    }
}