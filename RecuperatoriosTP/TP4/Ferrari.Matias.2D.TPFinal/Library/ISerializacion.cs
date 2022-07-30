using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public interface ISerializacion<T>
    {
        public string Extension { get; }
        public void Escribir(string path, T contenido, Action<string> mostrarMensaje);
        public T Leer(string path, Action<string> mostrarMensaje);
        public bool ValidacionArchivo(string path);
        public bool ValidacionExtension(string path);

    }
}
