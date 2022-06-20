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
        static List<Producto> products;

        static Negocio()
        {
            clientes = new List<Cliente>();
            CargarProductos();
        }

        static public List<Cliente> Clientes { get { return clientes; } set { clientes = value; } }
        public static List<Producto> Products { get { return products; } set { products = value; } }

        private static void CargarProductos()
        {
            products = new List<Producto>();
            
            products.Add(new Producto(1, "Motherboard Asus A320m K Prime Am4", 9480,50));
            products.Add(new Producto(2, "Micro Amd Ryzen 5 5600g 4.4 Ghz Am4", 29600,45));
            products.Add(new Producto(3, "Placa de Video Msi Nvidia Geforce Gtx 1050 Ti Gt Oc 4gb Gddr5", 36400,50));
            products.Add(new Producto(4, "Monitor 24 Naxido Nx24v9 75hz Ips Eyesaver", 34020, 60));
            products.Add(new Producto(5, "Mouse Logitech G203 Lightsync White", 4000, 100));


        }

        public static string MostrarListaClientes()
        {
            StringBuilder sb=new StringBuilder();
            foreach (Cliente item in clientes)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }




    }
}
