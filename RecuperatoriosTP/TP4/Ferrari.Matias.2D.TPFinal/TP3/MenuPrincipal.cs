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
    public partial class MenuPrincipal : Form
    {
        private Form formActivo = null;

        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Abre un form dentro los limites de un panel en lugar de abrirlo en forma modal
        /// </summary>
        /// <param name="childForm"></param>
        private void abrirFormPequeño(Form childForm)
        {
            if (formActivo != null)
            {
                formActivo.Close();
            }
            formActivo = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelFormPequeño.Controls.Add(childForm);
            panelFormPequeño.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            abrirFormPequeño(new AgregarClientes());
        }

        private void btnListaClientes_Click(object sender, EventArgs e)
        {
            abrirFormPequeño(new FrmLista());
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            System.Timers.Timer t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += Timer_Elapsed;
            Task.Run(() => { t.Start(); });
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                lblRelog.Text = DateTime.Now.ToString("HH:mm:ss");
            }));
        }


    }
}
