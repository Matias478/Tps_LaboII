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

        public void Escribir(string path, T texto, Action<string> mostrarMensaje)
        {
            if (ValidacionArchivo(path) && ValidacionExtension(path))
            {
                Serializar(path, texto, mostrarMensaje);
            }
        }

        public void GuardarComo(string path, T texto, Action<string> mostrarMensaje)
        {
            if (ValidacionExtension(path))
            {
                Serializar(path, texto, mostrarMensaje);
            }
        }
        /// <summary>
        /// Recibe por parametros el path, el contenido y un delegado para mostrar un mensaje si el serializado fue exitoso
        /// </summary>
        /// <param name="path"></param>
        /// <param name="texto"></param>
        /// <param name="mostrarMensaje"></param>
        private void Serializar(string path, T texto, Action<string> mostrarMensaje)
        {
            using (StreamWriter stW = new StreamWriter(path))
            {
                string json = JsonSerializer.Serialize(texto);
                stW.WriteLine(json);
                if(mostrarMensaje is not null)
                {
                    mostrarMensaje.Invoke("Documento JSON Serializado correctamente");
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
            if (ValidacionArchivo(path) && ValidacionExtension(path))
            {
                using (StreamReader stR = new StreamReader(path))
                {
                    string json = stR.ReadToEnd();
                    if(mostrarMensaje is not null)
                    {
                        mostrarMensaje.Invoke("Documento JSON deserializado con exito");
                    }
                    return JsonSerializer.Deserialize<T>(json);
                }
            }
            return null;
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
            if (Path.GetExtension(path) != this.Extension)
            {
                throw new FileNotFoundException($"No posee la extencion {Extension}");
            }
            return true;
        }
    }
}
