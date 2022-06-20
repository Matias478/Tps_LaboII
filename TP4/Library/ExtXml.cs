using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace Library
{
    public class ExtXml<T> : ISerializacion<T> where T : class
    {
        public string Extension { get { return ".xml"; } }

        public void Escribir(string path, T contenido)
        {
            if (ValidacionArchivo(path) && ValidacionExtension(path))
            {
                Serializar(path, contenido);
            }
        }

        public void GuardarComo(string path, T texto)
        {
            if (ValidacionExtension(path))
            {
                Serializar(path, texto);
            }
        }

        public void Serializar(string path, T contenido)
        {
            using(StreamWriter stw = new StreamWriter(path))
            {
                XmlSerializer xmlS = new XmlSerializer(typeof(T));
                xmlS.Serialize(stw, contenido);
            }
        }

        public T Leer(string path)
        {
            T aux;
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    XmlSerializer serial = new XmlSerializer(typeof(T));
                    aux = (T)serial.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Algo salio mal al intentar leer el archivo", ex);
            }

            return aux;
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
            if(Path.GetExtension(path) != Extension)
            {
                throw new FileNotFoundException($"No posee la extension {Extension}");
            }
            return true;
        }
    }
}
