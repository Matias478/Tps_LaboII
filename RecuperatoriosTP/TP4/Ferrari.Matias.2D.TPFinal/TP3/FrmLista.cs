using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;

namespace UI
{
    public partial class FrmLista : Form
    {
        public delegate void DelegadoMensajeExito(string mensaje);

        public delegate void DelegadoDesactivarBoton();
        public event DelegadoDesactivarBoton EventoDesactivar;

        private ExtJson<List<Cliente>> extJson;
        private ExtXml<List<Cliente>> extXml;
        string lastFile;

        OpenFileDialog openFileDialog;
        SaveFileDialog saveFileDialog;


        public string LastFile
        {
            get { return lastFile; }
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    lastFile = value;
                }
            }
        }

        public FrmLista()
        {
            InitializeComponent();
            //string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string nombre = "Cliente.xml";
            //path = Path.Combine(pathDesktop, nombre);
            //Intancia
            extJson = new ExtJson<List<Cliente>>();
            extXml = new ExtXml<List<Cliente>>();
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivo XML|*.xml|Archivo JSON|*.json";
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo XML|*.xml|Archivo JSON|*.json";

            //RefrescarDataGrid();
        }

        /// <summary>
        /// Guardara los datos de la lista de clientes en un archivo JSON|XML
        /// </summary>
        private void Guardar()
        {
            if (!File.Exists(LastFile))
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    LastFile = saveFileDialog.FileName;
                }
                try
                {
                    switch (Path.GetExtension(LastFile))
                    {
                        case ".json":
                            this.extJson.GuardarComo(LastFile, Negocio.Clientes,ActualizarComponenetesFormulario);
                            break;
                        case ".xml":
                            this.extXml.GuardarComo(LastFile, Negocio.Clientes, ActualizarComponenetesFormulario);
                            break;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }else
            {
                try
                {
                    switch (Path.GetExtension(LastFile))
                    {
                        case ".json":
                            this.extJson.Escribir(LastFile, Negocio.Clientes, ActualizarComponenetesFormulario);
                            break;
                        case ".xml":
                            this.extXml.Escribir(LastFile, Negocio.Clientes, ActualizarComponenetesFormulario);
                            break;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            
        }
        /// <summary>
        /// Cargara la lista de clientes con los datos del archivo JSON|XML elegido
        /// </summary>
        private void Cargar()
        {
            //Cliente aux2 = Negocio.Clientes.Last();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LastFile=openFileDialog.FileName;
            }
            try
            {
                switch (Path.GetExtension(LastFile))
                {
                    case ".xml":
                        Negocio.Clientes = this.extXml.Leer(LastFile,ActualizarComponenetesFormulario);
                        //Cliente aux = Negocio.Clientes.Last();
                        //foreach (var item in Negocio.Clientes)
                        //{
                        //    if(aux2.Id<aux.Id)
                        //    {
                        //        SQLManagment.Insertar(item);
                        //    }
                        //}
                        break;
                    case ".json":
                        Negocio.Clientes = this.extJson.Leer(LastFile,ActualizarComponenetesFormulario);
                        break;
                }
                dgvListaClientes.DataSource = null;
                dgvListaClientes.DataSource = Negocio.Clientes;
            }
            catch (Exception ef)
            {
                MessageBox.Show(ef.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        /// <summary>
        /// Actualiza el label cuando se serializa o se deserializa
        /// </summary>
        /// <param name="texto"></param>
        private void ActualizarComponenetesFormulario(string texto)
        {
            lbMensaje.Text = texto;
            lbMensaje.Visible = true;
        }

        /// <summary>
        /// Al hacer doble click en alguna fila se mostraran los datos de ese cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvListaClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvListaClientes.CurrentRow.Cells[0].Value);
            try
            {
                MessageBox.Show(Negocio.MostrarListaClientes(id));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmLista_Load(object sender, EventArgs e)
        {
            RefrescarDataGrid();
            EventoDesactivar += DesactivarBotones;
        }
        /// <summary>
        /// Actualiza el datagrid cada vez que hay un cambio
        /// </summary>
        private void RefrescarDataGrid()
        {
            List<Cliente> listaClientes = Negocio.Clientes;
            listaClientes = SQLManagment.Leer();

            if(listaClientes.Count>0)
            {
                dgvListaClientes.DataSource = null;
                dgvListaClientes.DataSource = new List<Cliente>(listaClientes);
            }else
            {
                EventoDesactivar.Invoke();
                MessageBox.Show("No hay datos para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Al hacer click en el boton eliminar, se llamara a este metodo que sacara el id del cliente elegido 
        /// y hara llamara al metodo que EliminarCliente de la clase SQLManagment para hacer una baja
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgvListaClientes is not null)
            {
                DialogResult respuesta = MessageBox.Show("¿Esta seguro de querer dar de baja a este cliente?", "Eliminación", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    int id = (int)dgvListaClientes.CurrentRow.Cells[0].Value;
                    List<Cliente> listaClientes = Negocio.Clientes;

                    SQLManagment.EliminarCliente(id);
                    RefrescarDataGrid();
                }
            }
        }

        /// <summary>
        /// Lo que hara sera sacar al cliente elegido como un objeto y pasarlo como parametro al metodo 
        /// ModificarCliente de la clase SQLManagment que hara un UPDATE en la base de datos
        /// </summary>
        private void ModificarCliente()
        {
            Cliente clienteModificado;
            List<Cliente> listaClientes = Negocio.Clientes;

            if(dgvListaClientes is not null)
            {
                DialogResult respuesta = MessageBox.Show("¿Esta seguro de querer modificar los campos de este cliente?", "Modificar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(respuesta == DialogResult.Yes)
                {
                    clienteModificado = (Cliente)dgvListaClientes.CurrentRow.DataBoundItem;

                    ModificarCliente frmModificar = new ModificarCliente(clienteModificado);

                    if(frmModificar.ShowDialog()==DialogResult.OK)
                    {
                        SQLManagment.ModificarCliente(clienteModificado);
                        RefrescarDataGrid();
                    }

                }
            }
            else
            {
                MessageBox.Show("No hay clientes cargados");
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarCliente();
        }

        /// <summary>
        /// Metodo que es invocado por un evento y desactiva los botones de eliminacion y modificacion
        /// </summary>
        private void DesactivarBotones()
        {
            this.btnEliminar.Enabled = false;
            this.btnModificar.Enabled = false;
        }


    }
}
