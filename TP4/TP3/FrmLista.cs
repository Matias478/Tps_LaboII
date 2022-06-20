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
        static string path;// static??
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

            RefrescarDataGrid();
        }

        private void RefrescarDataGrid()
        {
            dgvLista.DataSource = null;
            dgvLista.DataSource = Negocio.Clientes;
        }

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
                            this.extJson.GuardarComo(LastFile, Negocio.Clientes);
                            break;
                        case ".xml":
                            this.extXml.GuardarComo(LastFile, Negocio.Clientes);
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
                            this.extJson.Escribir(LastFile, Negocio.Clientes);
                            break;
                        case ".xml":
                            this.extXml.Escribir(LastFile, Negocio.Clientes);
                            break;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            
        }

        private void Cargar()
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LastFile=openFileDialog.FileName;
            }
            try
            {
                switch (Path.GetExtension(LastFile))
                {
                    case ".xml":
                        Negocio.Clientes = this.extXml.Leer(LastFile);
                        break;
                    case ".json":
                        Negocio.Clientes = this.extJson.Leer(LastFile);
                        break;
                }
                RefrescarDataGrid();
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

        private void dgvLista_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value);
            try
            {
                for (int i = 0; i < Negocio.Clientes.Count; i++)
                {
                    if (Negocio.Clientes[i].Id==id)
                    {
                        MessageBox.Show(Negocio.Clientes[i].MostrarPedidos());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            Cargar();
        }
    }
}
