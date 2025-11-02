namespace SistemaDeGestionPersonal
{
    partial class frmActualizar
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
            cbxEstado = new ComboBox();
            label6 = new Label();
            cbxDepartamento = new ComboBox();
            label5 = new Label();
            cbxCargo = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            mtxtTelefono = new MaskedTextBox();
            mtxtDUI = new MaskedTextBox();
            label2 = new Label();
            txtNombre = new TextBox();
            label1 = new Label();
            btnActualisar = new Button();
            btnEliminar = new Button();
            SuspendLayout();
            // 
            // cbxEstado
            // 
            cbxEstado.BackColor = SystemColors.ScrollBar;
            cbxEstado.FormattingEnabled = true;
            cbxEstado.Items.AddRange(new object[] { "Activo", "Desactivo" });
            cbxEstado.Location = new Point(246, 272);
            cbxEstado.Name = "cbxEstado";
            cbxEstado.Size = new Size(214, 29);
            cbxEstado.TabIndex = 35;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(46, 272);
            label6.Name = "label6";
            label6.Size = new Size(59, 21);
            label6.TabIndex = 34;
            label6.Text = "Estado:";
            // 
            // cbxDepartamento
            // 
            cbxDepartamento.BackColor = SystemColors.ScrollBar;
            cbxDepartamento.FormattingEnabled = true;
            cbxDepartamento.Items.AddRange(new object[] { "RRHH", "Almacen", "Ventas" });
            cbxDepartamento.Location = new Point(246, 221);
            cbxDepartamento.Name = "cbxDepartamento";
            cbxDepartamento.Size = new Size(214, 29);
            cbxDepartamento.TabIndex = 33;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(46, 224);
            label5.Name = "label5";
            label5.Size = new Size(113, 21);
            label5.TabIndex = 32;
            label5.Text = "Departamento:";
            // 
            // cbxCargo
            // 
            cbxCargo.BackColor = SystemColors.ScrollBar;
            cbxCargo.FormattingEnabled = true;
            cbxCargo.Items.AddRange(new object[] { "Jefe", "Gerente", "Empleado" });
            cbxCargo.Location = new Point(246, 174);
            cbxCargo.Name = "cbxCargo";
            cbxCargo.Size = new Size(214, 29);
            cbxCargo.TabIndex = 31;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 174);
            label4.Name = "label4";
            label4.Size = new Size(55, 21);
            label4.TabIndex = 30;
            label4.Text = "Cargo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 131);
            label3.Name = "label3";
            label3.Size = new Size(71, 21);
            label3.TabIndex = 29;
            label3.Text = "Telefono:";
            // 
            // mtxtTelefono
            // 
            mtxtTelefono.BackColor = SystemColors.ScrollBar;
            mtxtTelefono.Location = new Point(246, 131);
            mtxtTelefono.Mask = "0000-0000";
            mtxtTelefono.Name = "mtxtTelefono";
            mtxtTelefono.Size = new Size(214, 29);
            mtxtTelefono.TabIndex = 28;
            // 
            // mtxtDUI
            // 
            mtxtDUI.BackColor = SystemColors.ScrollBar;
            mtxtDUI.Location = new Point(246, 86);
            mtxtDUI.Mask = "00000000-0";
            mtxtDUI.Name = "mtxtDUI";
            mtxtDUI.Size = new Size(214, 29);
            mtxtDUI.TabIndex = 27;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 89);
            label2.Name = "label2";
            label2.Size = new Size(39, 21);
            label2.TabIndex = 26;
            label2.Text = "DUI:";
            // 
            // txtNombre
            // 
            txtNombre.BackColor = SystemColors.ScrollBar;
            txtNombre.Location = new Point(246, 44);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(214, 29);
            txtNombre.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 47);
            label1.Name = "label1";
            label1.Size = new Size(143, 21);
            label1.TabIndex = 24;
            label1.Text = "Nombre Completo:";
            // 
            // btnActualisar
            // 
            btnActualisar.BackColor = SystemColors.ScrollBar;
            btnActualisar.Location = new Point(482, 334);
            btnActualisar.Name = "btnActualisar";
            btnActualisar.Size = new Size(195, 63);
            btnActualisar.TabIndex = 36;
            btnActualisar.Text = "Actualizar";
            btnActualisar.UseVisualStyleBackColor = false;
            btnActualisar.Click += btnActualisar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = SystemColors.ScrollBar;
            btnEliminar.Location = new Point(265, 334);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(195, 63);
            btnEliminar.TabIndex = 37;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // frmActualizar
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualisar);
            Controls.Add(cbxEstado);
            Controls.Add(label6);
            Controls.Add(cbxDepartamento);
            Controls.Add(label5);
            Controls.Add(cbxCargo);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(mtxtTelefono);
            Controls.Add(mtxtDUI);
            Controls.Add(label2);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Name = "frmActualizar";
            Text = "Actualizar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbxEstado;
        private Label label6;
        private ComboBox cbxDepartamento;
        private Label label5;
        private ComboBox cbxCargo;
        private Label label4;
        private Label label3;
        private MaskedTextBox mtxtTelefono;
        private MaskedTextBox mtxtDUI;
        private Label label2;
        private TextBox txtNombre;
        private Label label1;
        private Button btnActualisar;
        private Button btnEliminar;
    }
}