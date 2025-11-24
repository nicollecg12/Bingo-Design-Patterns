namespace Bingo_Design_Patterns
{
    partial class FormAdministrarPalabras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdministrarPalabras));
            this.btnEliminarPatron = new System.Windows.Forms.Button();
            this.btnModificarPatron = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvListaPalabras = new System.Windows.Forms.DataGridView();
            this.NombreDelPatron = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FrasePista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAñadirPatron = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtPatron = new System.Windows.Forms.TextBox();
            this.lblAdministrarPalabras = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPalabras)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEliminarPatron
            // 
            this.btnEliminarPatron.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminarPatron.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarPatron.ForeColor = System.Drawing.Color.White;
            this.btnEliminarPatron.Location = new System.Drawing.Point(50, 188);
            this.btnEliminarPatron.Name = "btnEliminarPatron";
            this.btnEliminarPatron.Size = new System.Drawing.Size(172, 33);
            this.btnEliminarPatron.TabIndex = 47;
            this.btnEliminarPatron.Text = "Eliminar";
            this.btnEliminarPatron.UseVisualStyleBackColor = false;
            // 
            // btnModificarPatron
            // 
            this.btnModificarPatron.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnModificarPatron.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarPatron.ForeColor = System.Drawing.Color.White;
            this.btnModificarPatron.Location = new System.Drawing.Point(50, 237);
            this.btnModificarPatron.Name = "btnModificarPatron";
            this.btnModificarPatron.Size = new System.Drawing.Size(172, 35);
            this.btnModificarPatron.TabIndex = 46;
            this.btnModificarPatron.Text = "Modificar";
            this.btnModificarPatron.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("Rockwell", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(39, 350);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 26);
            this.label3.TabIndex = 45;
            this.label3.Text = "Agregar nuevo patrón";
            // 
            // dgvListaPalabras
            // 
            this.dgvListaPalabras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaPalabras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreDelPatron,
            this.FrasePista});
            this.dgvListaPalabras.Location = new System.Drawing.Point(288, 166);
            this.dgvListaPalabras.Name = "dgvListaPalabras";
            this.dgvListaPalabras.Size = new System.Drawing.Size(243, 125);
            this.dgvListaPalabras.TabIndex = 44;
            // 
            // NombreDelPatron
            // 
            this.NombreDelPatron.HeaderText = "Nombre del patrón";
            this.NombreDelPatron.Name = "NombreDelPatron";
            // 
            // FrasePista
            // 
            this.FrasePista.HeaderText = "Descripción";
            this.FrasePista.Name = "FrasePista";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Firebrick;
            this.btnSalir.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(455, 538);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(95, 33);
            this.btnSalir.TabIndex = 43;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // btnAñadirPatron
            // 
            this.btnAñadirPatron.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAñadirPatron.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadirPatron.ForeColor = System.Drawing.Color.White;
            this.btnAñadirPatron.Location = new System.Drawing.Point(128, 476);
            this.btnAñadirPatron.Name = "btnAñadirPatron";
            this.btnAñadirPatron.Size = new System.Drawing.Size(210, 40);
            this.btnAñadirPatron.TabIndex = 42;
            this.btnAñadirPatron.Text = "Añadir Patrón";
            this.btnAñadirPatron.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("MV Boli", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(258, 398);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 41;
            this.label2.Text = "Descripción";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblNombre.Font = new System.Drawing.Font("MV Boli", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(40, 398);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(142, 20);
            this.lblNombre.TabIndex = 40;
            this.lblNombre.Text = "Patrón de diseño";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(262, 430);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(259, 22);
            this.txtDescripcion.TabIndex = 39;
            // 
            // txtPatron
            // 
            this.txtPatron.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatron.Location = new System.Drawing.Point(44, 430);
            this.txtPatron.Name = "txtPatron";
            this.txtPatron.Size = new System.Drawing.Size(178, 22);
            this.txtPatron.TabIndex = 38;
            // 
            // lblAdministrarPalabras
            // 
            this.lblAdministrarPalabras.AutoSize = true;
            this.lblAdministrarPalabras.BackColor = System.Drawing.Color.SteelBlue;
            this.lblAdministrarPalabras.Font = new System.Drawing.Font("Rockwell", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdministrarPalabras.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblAdministrarPalabras.Location = new System.Drawing.Point(295, 107);
            this.lblAdministrarPalabras.Name = "lblAdministrarPalabras";
            this.lblAdministrarPalabras.Size = new System.Drawing.Size(226, 26);
            this.lblAdministrarPalabras.TabIndex = 37;
            this.lblAdministrarPalabras.Text = "Administrar palabras";
            // 
            // FormAdministrarPalabras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(600, 581);
            this.Controls.Add(this.btnEliminarPatron);
            this.Controls.Add(this.btnModificarPatron);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvListaPalabras);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAñadirPatron);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtPatron);
            this.Controls.Add(this.lblAdministrarPalabras);
            this.Name = "FormAdministrarPalabras";
            this.Text = "FormAdministrarPalabras";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPalabras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEliminarPatron;
        private System.Windows.Forms.Button btnModificarPatron;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvListaPalabras;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreDelPatron;
        private System.Windows.Forms.DataGridViewTextBoxColumn FrasePista;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAñadirPatron;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtPatron;
        private System.Windows.Forms.Label lblAdministrarPalabras;
    }
}