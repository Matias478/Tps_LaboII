using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txbPassword.Text))
            {
                MessageBox.Show("Debe ingresar datos para poder loguearse", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if(double.TryParse(txbPassword.Text,out double error))
            {
                MessageBox.Show("No se pueden ingresar numeros", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(txbPassword.Text=="maximus123")
                {
                    MenuPrincipal frmMenu = new MenuPrincipal();
                    frmMenu.Show();
                    this.Hide();
                }
                else
                {
                    CargarNoDijisteLaPalabraMagica();
                    MessageBox.Show("Contraseña incorrecta", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarNoDijisteLaPalabraMagica()
        {
            try
            {
                using (SoundPlayer sp = new SoundPlayer(Properties.Resources.aaanodijistelapalabramagica))
                {
                    sp.Play();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo encontrar el archivo de audio!!!");
            }
        }

        private void btnCompletarPassword_Click(object sender, EventArgs e)
        {
            txbPassword.Text = "maximus123";
        }
    }
}
