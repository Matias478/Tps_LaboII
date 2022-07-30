using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class DatosNoValidosException : Exception
    {
        public DatosNoValidosException(string mensaje) : base(mensaje)
        {

        }
    }
}
