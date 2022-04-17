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
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        bool operarBtnFuePresionado = false;

        /// <summary>
        /// Inicializa los componentes
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }

        
        /// <summary>
        /// Borra los datos de los textBox, comboBox y label
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperators.SelectedIndex = -1;
            lblResultado.Text = "";
            operarBtnFuePresionado = false;
        }
        /// <summary>
        /// Llama al metodo limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        

        
        /// <summary>
        /// Carga el formulario, llama al metodo limpiar y da nombre al listBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
            //lblResultado.Text = "0";
        }
        

        
        /// <summary>
        /// Recibe y crea los numeros y el signo de la operacion, para retornar el resultado de la cuenta
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string num1, string num2, string operador)
        {
            Operando n1 = new Operando(num1);
            Operando n2 = new Operando(num2);
            char op = Char.Parse(operador);

            return Calculadora.Operar(n1, n2, op);//operador[0]);
        }
        /// <summary>
        /// Hace validaciones varias, llama al metodo operar para usar su retorno y asignarlo al label y a la listBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (/*cmbOperators.Text.Equals("") || */String.IsNullOrEmpty(txtNumero1.Text) || String.IsNullOrEmpty(txtNumero2.Text))
            {
                MessageBox.Show("Debe ingresar una operacion para continuar", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
            {
                if(!Double.TryParse(txtNumero1.Text, out double num1Double) || !Double.TryParse(txtNumero2.Text, out double num2Double))
                {
                    MessageBox.Show("Solo se permite ingresar numeros", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else 
                {
                    if(cmbOperators.Text.Equals("/") && txtNumero2.Text.Equals("0"))
                    {
                        MessageBox.Show("No se pueden hacer divisiones por 0", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }else
                    {
                        string operador = (string)cmbOperators.SelectedItem;
                        if (string.IsNullOrEmpty(cmbOperators.Text))
                        {
                            operador = "+";
                            //MessageBox.Show("Al no estar definido el operador, por defecto sera suma", "Warning!", MessageBoxButtons.OK ,MessageBoxIcon.Warning);
                        }
                        lblResultado.Text = FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, operador).ToString();
                        StringBuilder sb = new StringBuilder();

                        sb.AppendFormat($"{txtNumero1.Text} {operador} {txtNumero2.Text} = {lblResultado.Text}");
                        lstOperaciones.Items.Add(sb);
                        operarBtnFuePresionado = true;
                        if (operarBtnFuePresionado == true)
                        {
                            btnConvertirADecimal.Enabled = false;
                            btnConvertirABinario.Enabled = true;
                        }
                    }
                }   
            }
        }
        

        
        /// <summary>
        /// Al apretar el boton cerrar aparece un mensaje en busca de la confirmacion de la accion, si esta es si, se cierra el programa sino sigue en curso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Seguro que quiere salir?","Atencion !",MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {
                Dispose();
            }
        }
        /// <summary>
        /// Al querer salir con la X aparece un mensaje en busca de la confirmacion de la accion, si esta es si, se cierra el programa sino sigue en curso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que quiere salir?", "Atencion !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Dispose();
            }
            else
                e.Cancel = true;
        }
        

        #region conversoresBinariosDecimal
        /// <summary>
        /// Hace unas validaciones varias, llama al metodo que convierte un numero decimal a uno binario y 
        ///  desabilita el boton que convierte de decimal a binario una vez pulsado hasta que se pulse el boton que convierte lo contrario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNumero1.Text) || String.IsNullOrEmpty(txtNumero2.Text))
            {
                MessageBox.Show("Debe ingresar una operacion y presionar el boton operar para continuar", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if(operarBtnFuePresionado==false)
            {
                MessageBox.Show("Debe Presionar el boton operar para continuar", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
            {
                Operando numeroDecimal = new Operando();
                StringBuilder sb = new StringBuilder();
                sb.Append($"Dec: {lblResultado.Text} ");
                lblResultado.Text = numeroDecimal.DecimalBinario(lblResultado.Text);
                sb.AppendLine($"Bin: {lblResultado.Text}");
                lstOperaciones.Items.Add(sb);

                if (String.Compare(lblResultado.Text, "Valor Invalido") == 0)
                {
                    MessageBox.Show("Se necesita limpiar los valores actuales o realizar otra operacion", "Operacion invalida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnConvertirABinario.Enabled = false;
                    btnConvertirADecimal.Enabled = false;
                }else
                {
                        btnConvertirABinario.Enabled = false;
                        btnConvertirADecimal.Enabled = true;

                    if (btnConvertirADecimal.Enabled == false)
                    {
                        btnConvertirABinario.Enabled = true;
                    }
                }
            }
        }
        /// <summary>
        /// Hace una validacion para verificar si hizo una operacion, luego llama al conversor y lo asigna al label,
        ///  por ultimo desabilita el boton que convierte de binario a decimal una vez pulsado hasta que se pulse el boton que convierte lo contrario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNumero1.Text) || String.IsNullOrEmpty(txtNumero2.Text))
            {
                MessageBox.Show("Debe ingresar una operacion y presionar el boton operar para continuar", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if (operarBtnFuePresionado == false)
            {
                MessageBox.Show("Debe Presionar el boton operar para continuar", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Operando numeroBinario = new Operando();
                StringBuilder sb = new StringBuilder();
                sb.Append($"Bin: {lblResultado.Text} ");
                lblResultado.Text = numeroBinario.BinarioDecimal(lblResultado.Text);
                sb.AppendLine($"Dec: {lblResultado.Text}");
                lstOperaciones.Items.Add(sb);


                btnConvertirADecimal.Enabled = false;
                btnConvertirABinario.Enabled = true;

                if (btnConvertirABinario.Enabled == false)
                {
                    btnConvertirADecimal.Enabled = true;
                }
            }
        }
        #endregion

    }
}
