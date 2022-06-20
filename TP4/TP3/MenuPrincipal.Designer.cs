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
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnListaClientes = new System.Windows.Forms.Button();
            this.btnAgregarPedido = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.panelFormPequeño = new System.Windows.Forms.Panel();
            this.panelMenuIzquierda.SuspendLayout();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.panelFormPequeño.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.LightCoral;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCerrar.ForeColor = System.Drawing.Color.LightCoral;
            this.btnCerrar.Location = new System.Drawing.Point(643, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(69, 59);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panelMenuIzquierda
            // 
            this.panelMenuIzquierda.Controls.Add(this.panelBotones);
            this.panelMenuIzquierda.Controls.Add(this.pbLogo);
            this.panelMenuIzquierda.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenuIzquierda.Location = new System.Drawing.Point(0, 0);
            this.panelMenuIzquierda.Name = "panelMenuIzquierda";
            this.panelMenuIzquierda.Size = new System.Drawing.Size(190, 518);
            this.panelMenuIzquierda.TabIndex = 1;
            // 
            // panelBotones
            // 
            this.panelBotones.Controls.Add(this.btnListaClientes);
            this.panelBotones.Controls.Add(this.btnAgregarPedido);
            this.panelBotones.Location = new System.Drawing.Point(0, 219);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(190, 117);
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
            this.btnListaClientes.Location = new System.Drawing.Point(0, 72);
            this.btnListaClientes.Name = "btnListaClientes";
            this.btnListaClientes.Size = new System.Drawing.Size(190, 35);
            this.btnListaClientes.TabIndex = 2;
            this.btnListaClientes.Text = "Lista de CLientes";
            this.btnListaClientes.UseVisualStyleBackColor = false;
            this.btnListaClientes.Click += new System.EventHandler(this.btnListaClientes_Click);
            // 
            // btnAgregarPedido
            // 
            this.btnAgregarPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.btnAgregarPedido.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(247)))), ((int)(((byte)(100)))));
            this.btnAgregarPedido.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(247)))), ((int)(((byte)(100)))));
            this.btnAgregarPedido.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(20)))), ((int)(((byte)(70)))));
            this.btnAgregarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPedido.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAgregarPedido.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAgregarPedido.Location = new System.Drawing.Point(0, 21);
            this.btnAgregarPedido.Name = "btnAgregarPedido";
            this.btnAgregarPedido.Size = new System.Drawing.Size(190, 35);
            this.btnAgregarPedido.TabIndex = 1;
            this.btnAgregarPedido.Text = "Agregar Clientes";
            this.btnAgregarPedido.UseVisualStyleBackColor = false;
            this.btnAgregarPedido.Click += new System.EventHandler(this.btnAgregarPedido_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbLogo.Image = global::UI.Properties.Resources.Maximus3;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(190, 139);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // panelFormPequeño
            // 
            this.panelFormPequeño.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelFormPequeño.Controls.Add(this.btnCerrar);
            this.panelFormPequeño.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormPequeño.Location = new System.Drawing.Point(190, 0);
            this.panelFormPequeño.Name = "panelFormPequeño";
            this.panelFormPequeño.Size = new System.Drawing.Size(724, 518);
            this.panelFormPequeño.TabIndex = 2;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(914, 518);
            this.Controls.Add(this.panelFormPequeño);
            this.Controls.Add(this.panelMenuIzquierda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuPrincipal";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuPrincipal";
            this.panelMenuIzquierda.ResumeLayout(false);
            this.panelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.panelFormPequeño.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel panelMenuIzquierda;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnListaClientes;
        private System.Windows.Forms.Button btnAgregarPedido;
        private System.Windows.Forms.Panel panelFormPequeño;
    }
}