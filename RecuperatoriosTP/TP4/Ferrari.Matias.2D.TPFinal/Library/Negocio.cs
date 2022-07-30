using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Negocio 
    {
        static List<Cliente> clientes;

        static Negocio()
        {
            clientes = new List<Cliente>();
        }

        static public List<Cliente> Clientes { get { return clientes; } set { clientes = value; } }

        public static bool VerificarDatos(long dni, long telefono)
        {
            try
            {
                if (dni < 10000000 || dni > 45000000)
                {
                    throw new DatosNoValidosException("El dni debera ser mayor a 10M y menor que 45M");
                }else if(telefono.ToString().Length<10 || telefono.ToString().Length > 10)
                {
                    throw new DatosNoValidosException("El numero de telefono tiene que tener 10 digitos");
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string MostrarListaClientes(int id)
        {
            StringBuilder sb=new StringBuilder();
            foreach (Cliente item in clientes)
            {
                if(item.Id==id)
                {
                    sb.AppendLine(item.ToString());
                }
            }
            return sb.ToString();
        }


    }
}
