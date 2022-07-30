namespace UI
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelMenuIzquierda = new System.Windows.Forms.Panel();
            this.lblRelog = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnListaClientes = new System.Windows.Forms.Button();
            this.btnAgregarCliente = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.panelFormPequeño = new System.Windows.Forms.Panel();
            this.lblGimMaximus = new System.Windows.Forms.Label();
            this.panelMenuIzquierda.SuspendLayout();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.panelFormPequeño.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.LightCoral;
            this.btnCerrar.FlatAppearance.BorderSize = 2;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCerrar.ForeColor = System.Drawing.Color.LightCoral;
            this.btnCerrar.Location = new System.Drawing.Point(675, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(69, 59);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panelMenuIzquierda
            // 
            this.panelMenuIzquierda.Controls.Add(this.lblRelog);
            this.panelMenuIzquierda.Controls.Add(this.panelBotones);
            this.panelMenuIzquierda.Controls.Add(this.pbLogo);
            this.panelMenuIzquierda.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenuIzquierda.Location = new System.Drawing.Point(0, 0);
            this.panelMenuIzquierda.Name = "panelMenuIzquierda";
            this.panelMenuIzquierda.Size = new System.Drawing.Size(196, 526);
            this.panelMenuIzquierda.TabIndex = 1;
            // 
            // lblRelog
            // 
            this.lblRelog.AutoSize = true;
            this.lblRelog.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRelog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(247)))), ((int)(((byte)(100)))));
            this.lblRelog.Location = new System.Drawing.Point(12, 490);
            this.lblRelog.Name = "lblRelog";
            this.lblRelog.Size = new System.Drawing.Size(96, 27);
            this.lblRelog.TabIndex = 2;
            this.lblRelog.Text = "00:00:00";
            // 
            // panelBotones
            // 
            this.panelBotones.Controls.Add(this.btnListaClientes);
            this.panelBotones.Controls.Add(this.btnAgregarCliente);
            this.panelBotones.Location = new System.Drawing.Point(0, 219);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(193, 117);
            this.panelBotones.TabIndex = 1;
            // 
            // btnListaClientes
            // 
            this.btnListaClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.btnListaClientes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(247)))), ((int)(((byte)(100)))));
            this.btnListaClientes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(247)))), ((int)(((byte)(100)))));
            this.btnListaClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.btnListaClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListaClientes.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnListaClientes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnListaClientes.Location = new System.Drawing.Point(0, 65);
            this.btnListaClientes.Name = "btnListaClientes";
            this.btnListaClientes.Size = new System.Drawing.Size(193, 35);
            this.btnListaClientes.TabIndex = 2;
            this.btnListaClientes.Text = "Lista de Clientes";
            this.btnListaClientes.UseVisualStyleBackColor = false;
            this.btnListaClientes.Click += new System.EventHandler(this.btnListaClientes_Click);
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.btnAgregarCliente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(247)))), ((int)(((byte)(100)))));
            this.btnAgregarCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(247)))), ((int)(((byte)(100)))));
            this.btnAgregarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.btnAgregarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCliente.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAgregarCliente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAgregarCliente.Location = new System.Drawing.Point(0, 15);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.Size = new System.Drawing.Size(193, 35);
            this.btnAgregarCliente.TabIndex = 1;
            this.btnAgregarCliente.Text = "Agregar Clientes";
            this.btnAgregarCliente.UseVisualStyleBackColor = false;
            this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbLogo.Image = global::UI.Properties.Resources.Maximus3;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(196, 195);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // panelFormPequeño
            // 
            this.panelFormPequeño.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(240)))), ((int)(((byte)(85)))));
            this.panelFormPequeño.BackgroundImage = global::UI.Properties.Resources.MaximusGym;
            this.panelFormPequeño.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelFormPequeño.Controls.Add(this.lblGimMaximus);
            this.panelFormPequeño.Controls.Add(this.btnCerrar);
            this.panelFormPequeño.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormPequeño.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panelFormPequeño.Location = new System.Drawing.Point(196, 0);
            this.panelFormPequeño.Name = "panelFormPequeño";
            this.panelFormPequeño.Size = new System.Drawing.Size(756, 526);
            this.panelFormPequeño.TabIndex = 2;
            // 
            // lblGimMaximus
            // 
            this.lblGimMaximus.AutoSize = true;
            this.lblGimMaximus.Font = new System.Drawing.Font("Stencil", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGimMaximus.Location = new System.Drawing.Point(6, 12);
            this.lblGimMaximus.Name = "lblGimMaximus";
            this.lblGimMaximus.Size = new System.Drawing.Size(206, 25);
            this.lblGimMaximus.TabIndex = 1;
            this.lblGimMaximus.Text = "Gimnasio Maximus";
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(952, 526);
            this.Controls.Add(this.panelFormPequeño);
            this.Controls.Add(this.panelMenuIzquierda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(952, 526);
            this.Name = "MenuPrincipal";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuPrincipal";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.panelMenuIzquierda.ResumeLayout(false);
            this.panelMenuIzquierda.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.panelFormPequeño.ResumeLayout(false);
            this.panelFormPequeño.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel panelMenuIzquierda;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnListaClientes;
        private System.Windows.Forms.Button btnAgregarCliente;
        private System.Windows.Forms.Panel panelFormPequeño;
        private System.Windows.Forms.Label lblRelog;
        private System.Windows.Forms.Label lblGimMaximus;
    }
}