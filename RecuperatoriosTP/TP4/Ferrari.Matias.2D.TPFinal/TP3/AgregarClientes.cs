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
        Cliente clienteCreado = null;
        public AgregarClientes()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Creara un cliente y lo agregara a la lista de clientes, tanto del programa como en la base
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int idCliente = 0;
            try
            {
                if (string.IsNullOrEmpty(txbNombre.Text) || string.IsNullOrEmpty(txbApellido.Text) || string.IsNullOrEmpty(txbDni.Text) || string.IsNullOrEmpty(txbTelefono.Text))
                {
                    MessageBox.Show("Se deben ingresar todos los datos para agregar un cliente!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (float.TryParse(txbNombre.Text, out float name) || float.TryParse(txbApellido.Text, out float lastName))
                {
                    MessageBox.Show("Solo se pueden ingresar caracteres en los campos nombre y apellido!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!long.TryParse(txbDni.Text, out long dni))
                {
                    MessageBox.Show("Solo se pueden ingresar numeros en los campos dni !!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!long.TryParse(txbTelefono.Text, out long telefono))
                {
                    MessageBox.Show("Solo se pueden ingresar numeros en los campos telefono !!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }else if(cmbClases.SelectedIndex==-1 || cmbTurnos.SelectedIndex==-1)
                {
                    MessageBox.Show("Se debe elegir una clase y un turno para poder continuar!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string nombre = txbNombre.Text;
                    string apellido = txbApellido.Text;
                    EClases clase = (EClases)cmbClases.SelectedItem;
                    EHorarios horario = (EHorarios)cmbTurnos.SelectedItem;

                    if(!Negocio.VerificarDatos(dni, telefono))
                    {
                    }
                    else
                    {
                        clienteCreado = new Cliente(idCliente,nombre, apellido, dni, telefono, clase, horario);
                        if (clienteCreado is not null)
                        {
                            Negocio.Clientes.Add(clienteCreado);
                            SQLManagment.Insertar(clienteCreado);

                            MessageBox.Show("Cliente agregado Correctamente");
                            RefrescarInfo();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void AgregarClientes_Load(object sender, EventArgs e)
        {
            cmbClases.DataSource = Enum.GetValues(typeof(EClases));
            cmbTurnos.DataSource = Enum.GetValues(typeof(EHorarios));
            RefrescarInfo();
        }
        /// <summary>
        /// Devuelve todos los textbox y combobox a default 
        /// </summary>
        public void RefrescarInfo()
        {
            txbNombre.Text = "";
            txbApellido.Text = "";
            txbDni.Text = "";
            txbTelefono.Text = "";
            cmbClases.SelectedIndex = -1;
            cmbTurnos.SelectedIndex = -1;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            RefrescarInfo();
        }
    }
}
