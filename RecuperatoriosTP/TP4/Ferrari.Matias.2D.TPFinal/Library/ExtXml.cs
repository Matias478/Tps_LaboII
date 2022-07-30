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

        public void Escribir(string path, T contenido, Action<string> mostraMensaje)
        {
            if (ValidacionArchivo(path) && ValidacionExtension(path))
            {
                Serializar(path, contenido,mostraMensaje);
            }
        }

        public void GuardarComo(string path, T texto, Action<string> mostraMensaje)
        {
            if (ValidacionExtension(path))
            {
                Serializar(path, texto,mostraMensaje);
            }
        }
        /// <summary>
        /// Recibe por parametros el path, el contenido y un delegado para mostrar un mensaje si el serializado fue exitoso
        /// </summary>
        /// <param name="path"></param>
        /// <param name="texto"></param>
        /// <param name="mostrarMensaje"></param>
        public void Serializar(string path, T contenido, Action<string> mostraMensaje)
        {
            using(StreamWriter stw = new StreamWriter(path))
            {
                XmlSerializer xmlS = new XmlSerializer(typeof(T));
                xmlS.Serialize(stw, contenido);
                if(mostraMensaje is not null)
                {
                    mostraMensaje.Invoke("Documento XML Serializado correctamente");
                }
            }
        }

        /// <summary>
        /// recibe por parametros el path y un delegado para mostrar en un label que la operacion de deserializar fue exitosa
        /// </summary>
        /// <param name="path"></param>
        /// <param name="mostrarMensaje"></param>
        /// <returns></returns>
        public T Leer(string path, Action<string> mostrarMensaje)
        {
            T aux;
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    XmlSerializer serial = new XmlSerializer(typeof(T));
                    aux = (T)serial.Deserialize(reader);
                    if(mostrarMensaje is not null)
                    {
                        mostrarMensaje.Invoke("Documento XML deserializado con exito");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Algo salio mal al intentar leer el archivo", ex);
            }

            return aux;
        }
        /// <summary>
        /// Validara si el archivo existe en el path pasado por parametros
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public bool ValidacionArchivo(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("No existe el archivo o no se pudo encontrar");
            }
            return true;
        }
        /// <summary>
        /// Validara si la extencion del archivo es correcta
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
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
