namespace Bingo_Design_Patterns
{
    partial class FormRegistroAdministrador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistroAdministrador));
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAgregarAdmin = new System.Windows.Forms.Button();
            this.txtNumeroTelefonico = new System.Windows.Forms.TextBox();
            this.lblNumeroTelefonico = new System.Windows.Forms.Label();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.lblEdad = new System.Windows.Forms.Label();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNuevoAdministrador = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(247, 148);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(179, 24);
            this.txtNombre.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("MV Boli", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(94, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 20);
            this.label4.TabIndex = 43;
            this.label4.Text = "Nombre completo";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Firebrick;
            this.btnSalir.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(596, 359);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(95, 33);
            this.btnSalir.TabIndex = 42;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAgregarAdmin
            // 
            this.btnAgregarAdmin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAgregarAdmin.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarAdmin.ForeColor = System.Drawing.Color.White;
            this.btnAgregarAdmin.Location = new System.Drawing.Point(506, 212);
            this.btnAgregarAdmin.Name = "btnAgregarAdmin";
            this.btnAgregarAdmin.Size = new System.Drawing.Size(210, 40);
            this.btnAgregarAdmin.TabIndex = 41;
            this.btnAgregarAdmin.Text = "Agregar Admin";
            this.btnAgregarAdmin.UseVisualStyleBackColor = false;
            this.btnAgregarAdmin.Click += new System.EventHandler(this.btnAgregarAdmin_Click);
            // 
            // txtNumeroTelefonico
            // 
            this.txtNumeroTelefonico.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroTelefonico.Location = new System.Drawing.Point(247, 250);
            this.txtNumeroTelefonico.Name = "txtNumeroTelefonico";
            this.txtNumeroTelefonico.Size = new System.Drawing.Size(179, 24);
            this.txtNumeroTelefonico.TabIndex = 40;
            // 
            // lblNumeroTelefonico
            // 
            this.lblNumeroTelefonico.AutoSize = true;
            this.lblNumeroTelefonico.BackColor = System.Drawing.Color.Transparent;
            this.lblNumeroTelefonico.Font = new System.Drawing.Font("MV Boli", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroTelefonico.ForeColor = System.Drawing.Color.White;
            this.lblNumeroTelefonico.Location = new System.Drawing.Point(88, 252);
            this.lblNumeroTelefonico.Name = "lblNumeroTelefonico";
            this.lblNumeroTelefonico.Size = new System.Drawing.Size(153, 20);
            this.lblNumeroTelefonico.TabIndex = 39;
            this.lblNumeroTelefonico.Text = "Número telefónico";
            // 
            // txtEdad
            // 
            this.txtEdad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdad.Location = new System.Drawing.Point(247, 199);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(179, 24);
            this.txtEdad.TabIndex = 38;
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.BackColor = System.Drawing.Color.Transparent;
            this.lblEdad.Font = new System.Drawing.Font("MV Boli", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEdad.ForeColor = System.Drawing.Color.White;
            this.lblEdad.Location = new System.Drawing.Point(196, 201);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(45, 20);
            this.lblEdad.TabIndex = 37;
            this.lblEdad.Text = "Edad";
            // 
            // txtContraseña
            // 
            this.txtContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.Location = new System.Drawing.Point(247, 359);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(179, 24);
            this.txtContraseña.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("MV Boli", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(148, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "Contraseña";
            // 
            // lblNuevoAdministrador
            // 
            this.lblNuevoAdministrador.AutoSize = true;
            this.lblNuevoAdministrador.BackColor = System.Drawing.Color.SteelBlue;
            this.lblNuevoAdministrador.Font = new System.Drawing.Font("Jokerman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNuevoAdministrador.ForeColor = System.Drawing.Color.White;
            this.lblNuevoAdministrador.Location = new System.Drawing.Point(296, 59);
            this.lblNuevoAdministrador.Name = "lblNuevoAdministrador";
            this.lblNuevoAdministrador.Size = new System.Drawing.Size(290, 35);
            this.lblNuevoAdministrador.TabIndex = 34;
            this.lblNuevoAdministrador.Text = "Nuevo Administrador";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreUsuario.Location = new System.Drawing.Point(247, 305);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(179, 24);
            this.txtNombreUsuario.TabIndex = 33;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblNombre.Font = new System.Drawing.Font("MV Boli", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(85, 305);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(156, 20);
            this.lblNombre.TabIndex = 32;
            this.lblNombre.Text = "Nombre de usuario";
            // 
            // FormRegistroAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAgregarAdmin);
            this.Controls.Add(this.txtNumeroTelefonico);
            this.Controls.Add(this.lblNumeroTelefonico);
            this.Controls.Add(this.txtEdad);
            this.Controls.Add(this.lblEdad);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNuevoAdministrador);
            this.Controls.Add(this.txtNombreUsuario);
            this.Controls.Add(this.lblNombre);
            this.Name = "FormRegistroAdministrador";
            this.Text = "FormRegistroAdministrador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAgregarAdmin;
        private System.Windows.Forms.TextBox txtNumeroTelefonico;
        private System.Windows.Forms.Label lblNumeroTelefonico;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNuevoAdministrador;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Label lblNombre;
    }
}