using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Library
{
    public class ExtJson<T> : ISerializacion<T> where T : class
    {
        public string Extension { get { return ".json"; } }

        public void Escribir(string path, T texto)
        {
            if (ValidacionArchivo(path) && ValidacionExtension(path))
            {
                Serializar(path, texto);
            }
        }

        public void GuardarComo(string path, T texto)
        {
            if (ValidacionExtension(path))
            {
                Serializar(path, texto);
            }
        }

        private void Serializar(string path, T texto)
        {
            using (StreamWriter stW = new StreamWriter(path))
            {
                string json = JsonSerializer.Serialize(texto);
                stW.WriteLine(json);
            }
            //string json = JsonSerializer.Serialize(path);
            //File.WriteAllText(path, json);
        }

        public T Leer(string path)
        {
            if (ValidacionArchivo(path) && ValidacionExtension(path))
            {
                using (StreamReader stR = new StreamReader(path))
                {
                    string json = stR.ReadToEnd();
                    return JsonSerializer.Deserialize<T>(json);
                }
            }
            return null;
        }

        public bool ValidacionArchivo(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("No existe el archivo o no se pudo encontrar");
            }
            return true;
        }

        public bool ValidacionExtension(string path)
        {
            if (Path.GetExtension(path) != this.Extension)
            {
                throw new FileNotFoundException($"No posee la extencion {Extension}");
            }
            return true;
        }
    }
}
