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
    public partial class ModificarCliente : Form
    {
        private Cliente cliente;
        public ModificarCliente(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
        }

        private void ModificarCliente_Load(object sender, EventArgs e)
        {
            cmbClases.DataSource = Enum.GetValues(typeof(EClases));
            cmbTurnos.DataSource = Enum.GetValues(typeof(EHorarios));
            CargarInfo();
        }
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
        /// <summary>
        /// Modificara los uno o mas campos del cliente que se recibio por el constructor del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txbNombre.Text) || string.IsNullOrEmpty(txbApellido.Text) || string.IsNullOrEmpty(txbDni.Text) || string.IsNullOrEmpty(txbTelefono.Text))
                {
                    MessageBox.Show("Se deben ingresar todos los datos para agregar un cliente!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (float.TryParse(txbNombre.Text, out float name) && float.TryParse(txbApellido.Text, out float lastName))
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
                }
                else
                {
                    string nombre = txbNombre.Text;
                    string apellido = txbApellido.Text;
                    EClases clase = (EClases)cmbClases.SelectedItem;
                    EHorarios horario = (EHorarios)cmbTurnos.SelectedItem;

                    if (!Negocio.VerificarDatos(dni, telefono))
                    {
                    }
                    else
                    {
                        cliente.Nombre = txbNombre.Text;
                        cliente.Apellido = txbApellido.Text;
                        cliente.Dni = dni;
                        cliente.Telefono = telefono;
                        cliente.Clases = (EClases)cmbClases.SelectedValue;
                        cliente.Horarios = (EHorarios)cmbTurnos.SelectedValue;

                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Cargara los textbox y combobox con la info del cliente recibido como parametro en el constructor 
        /// </summary>
        private void CargarInfo()
        {
            txbNombre.Text = cliente.Nombre;
            txbApellido.Text = cliente.Apellido;
            txbDni.Text = cliente.Dni.ToString();
            txbTelefono.Text = cliente.Telefono.ToString();
            cmbClases.SelectedItem = cliente.Clases;
            cmbTurnos.SelectedItem = cliente.Horarios;
        }
         
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
