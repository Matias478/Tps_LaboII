using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;

namespace UI
{
    public partial class AgregarClientes : Form
    {
        Cliente clienteCreado;
        List<Producto> productos;
        public AgregarClientes()
        {
            InitializeComponent();
            productos = new List<Producto>();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbNombre.Text) || string.IsNullOrEmpty(txbApellido.Text) || string.IsNullOrEmpty(txbDni.Text) || string.IsNullOrEmpty(txbTelefono.Text))
            {
                MessageBox.Show("Se deben ingresar todos los datos para agregar un cliente!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (float.TryParse(txbNombre.Text, out float name) && float.TryParse(txbApellido.Text, out float lastName))
            {
                MessageBox.Show("Solo se pueden ingresar caracteres en los campos nombre y apellido!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else if (!long.TryParse(txbDni.Text, out long dni))
            {
                MessageBox.Show("Solo se pueden ingresar numeros en los campos dni !!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else if (!long.TryParse(txbTelefono.Text, out long telefono))
            {
                MessageBox.Show("Solo se pueden ingresar numeros en los campos telefono !!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string nombre = txbNombre.Text;
                string apellido = txbApellido.Text;
                string nombreProducto = cmbProductos.Text;
                if (!int.TryParse(lbCantidad.Text, out int cantidad) || cantidad==0)
                {
                    MessageBox.Show("La cantidad de productos debe ser mayor a cero");
                }
                else
                {
                    foreach (Producto item in Negocio.Products)
                    {
                        if (item.Name == nombreProducto)
                        {
                            if (item.Cantidad < cantidad)
                            {
                                MessageBox.Show("La cantidad pedida supera la cantidad del producto en el inventario");
                            }
                            else
                            {
                                clienteCreado = new Cliente(nombre, apellido, dni, telefono, productos);
                                clienteCreado.AgregarProductos(item, cantidad);
                                if (clienteCreado is not null)
                                {
                                    Negocio.Clientes.Add(clienteCreado);
                                    RefrescarInfo();
                                    MessageBox.Show("Cliente agregado Correctamente");
                                }
                            }
                        }
                    }
                }
                
            }
        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            if(int.TryParse(lbCantidad.Text, out int cantidad))
            {
                cantidad++;
                lbCantidad.Text = cantidad.ToString();
            }
        }

        private void btnRestar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(lbCantidad.Text, out int cantidad))
            {
                if(cantidad==0)
                {
                    //MessageBox.Show("No se pueden numeros negativos");
                }
                else
                {
                    cantidad--;
                    lbCantidad.Text = cantidad.ToString();
                }
            }
        }

        private void AgregarClientes_Load(object sender, EventArgs e)
        {
            foreach (Producto item in Negocio.Products)
            {
                cmbProductos.Items.Add(item.Name);
            }
        }

        public void RefrescarInfo()
        {
            txbNombre.Text = "";
            txbApellido.Text = "";
            txbDni.Text = "";
            txbTelefono.Text = "";
            cmbProductos.SelectedIndex = -1;
            lbCantidad.Text = "0";
        }

    }
}
