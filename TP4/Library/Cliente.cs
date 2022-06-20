using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Cliente
    {
        static int lastId;
        int id;
        string nombre;
        string apellido;
        long dni;
        long telefono;
        List<Producto> pedido;
        int cantidadProductosComprados;
        //Dictionary<Producto, int> pedido2;


        static Cliente()
        {
            lastId = 1;
        }
        public Cliente()
        {
            //pedido2 = new Dictionary<Producto, int>();
            //itemsComprados = new List<Producto>();
        }
        public Cliente(string nombre,string apellido, long dni,long telefono, List<Producto> pedido /*Dictionary<Producto,int> pedido*/):this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.telefono = telefono;

            this.pedido = pedido;
            id = lastId;
            lastId++;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public long Dni { get => dni; set => dni = value; }
        public long Telefono { get => telefono; set => telefono = value; }
        //public Dictionary<Producto, int> Pedido2 { get => pedido2; set => pedido2 = value; }
        public List<Producto> Pedido { get => pedido; set => pedido = value; }


        /// <summary>
        /// Agrega el producto recibido a la lista de productos de la mesa , reduce la cantidad del mismo en el inventario
        /// Tambien agrega el producto y la cantidad al dictionary de pedidos, para poder mostrar la cant pedida por mesa.
        /// </summary>
        /// <param name="productoRecibido"></param>
        /// <param name="cant"></param>
        public void AgregarProductos(Producto productoRecibido, int cant)
        {
            if (productoRecibido is not null)
            {
                pedido.Add(productoRecibido);
                productoRecibido.Cantidad -= cant;
                cantidadProductosComprados = cant;
                //pedido2.Add(productoRecibido, cant);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID: {Id} Nombre: {Nombre} Apellido: {Apellido}");
            sb.AppendLine($"DNI: {Dni} Telefono: {Telefono}");

            sb.Append(MostrarPedidos());

            return sb.ToString(); 
        }

        public string MostrarPedidos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Pedido: ");
            foreach (Producto item in Pedido)
            {
                sb.Append(item.ToString());
            }
            sb.Append($" Cantidad: {cantidadProductosComprados}");
            return sb.ToString();
        }


        /*public string MostrarPedidos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Pedido: ");
            foreach (KeyValuePair<Producto, int> item in pedido)
            {
                sb.AppendLine($"ID: {item.Key.Id} Nombre: {item.Key.Name} \n" +
                    $"Precio: {item.Key.Precio} Cantidad: {item.Value} unidad/es");
            }
            return sb.ToString();
        }*/



    }

}
