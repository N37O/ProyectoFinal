namespace SistemaDeGestionPersonal
{
    partial class frmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            Empleados = new TabPage();
            cbxEstado = new ComboBox();
            label6 = new Label();
            dgvEmpleados = new DataGridView();
            cbxDepartamento = new ComboBox();
            label5 = new Label();
            btnEliminar = new Button();
            btnActualisar = new Button();
            btnAgregar = new Button();
            cbxCargo = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            mtxtTelefono = new MaskedTextBox();
            mtxtDUI = new MaskedTextBox();
            label2 = new Label();
            txtNombre = new TextBox();
            label1 = new Label();
            Asistencias = new TabPage();
            dgvAsistencias = new DataGridView();
            cbxPermiso = new ComboBox();
            mtxtHoraSalida = new MaskedTextBox();
            label11 = new Label();
            mtxtHoraEntrada = new MaskedTextBox();
            label10 = new Label();
            btnEnviar = new Button();
            label9 = new Label();
            txtIdEmpleado = new TextBox();
            label8 = new Label();
            label7 = new Label();
            dtpFecha = new DateTimePicker();
            Reportes = new TabPage();
            cbxCargarReporte = new ComboBox();
            label15 = new Label();
            btnGenerarReporte = new Button();
            btnExportar = new Button();
            dgvResultadosReportes = new DataGridView();
            comboBox1 = new ComboBox();
            label14 = new Label();
            dtpHasta = new DateTimePicker();
            label13 = new Label();
            dtpDesde = new DateTimePicker();
            label12 = new Label();
            tabControl1.SuspendLayout();
            Empleados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            Asistencias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAsistencias).BeginInit();
            Reportes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultadosReportes).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Empleados);
            tabControl1.Controls.Add(Asistencias);
            tabControl1.Controls.Add(Reportes);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(695, 527);
            tabControl1.TabIndex = 0;
            // 
            // Empleados
            // 
            Empleados.BackColor = SystemColors.InactiveBorder;
            Empleados.Controls.Add(cbxEstado);
            Empleados.Controls.Add(label6);
            Empleados.Controls.Add(dgvEmpleados);
            Empleados.Controls.Add(cbxDepartamento);
            Empleados.Controls.Add(label5);
            Empleados.Controls.Add(btnEliminar);
            Empleados.Controls.Add(btnActualisar);
            Empleados.Controls.Add(btnAgregar);
            Empleados.Controls.Add(cbxCargo);
            Empleados.Controls.Add(label4);
            Empleados.Controls.Add(label3);
            Empleados.Controls.Add(mtxtTelefono);
            Empleados.Controls.Add(mtxtDUI);
            Empleados.Controls.Add(label2);
            Empleados.Controls.Add(txtNombre);
            Empleados.Controls.Add(label1);
            Empleados.Location = new Point(4, 29);
            Empleados.Name = "Empleados";
            Empleados.Padding = new Padding(3);
            Empleados.Size = new Size(687, 494);
            Empleados.TabIndex = 0;
            Empleados.Text = "Empleados";
            // 
            // cbxEstado
            // 
            cbxEstado.BackColor = SystemColors.ScrollBar;
            cbxEstado.FormattingEnabled = true;
            cbxEstado.Items.AddRange(new object[] { "Activo", "Desactivo" });
            cbxEstado.Location = new Point(206, 238);
            cbxEstado.Name = "cbxEstado";
            cbxEstado.Size = new Size(191, 28);
            cbxEstado.TabIndex = 23;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(28, 238);
            label6.Name = "label6";
            label6.Size = new Size(57, 20);
            label6.TabIndex = 22;
            label6.Text = "Estado:";
            // 
            // dgvEmpleados
            // 
            dgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmpleados.Location = new Point(5, 284);
            dgvEmpleados.Name = "dgvEmpleados";
            dgvEmpleados.RowHeadersWidth = 51;
            dgvEmpleados.Size = new Size(680, 214);
            dgvEmpleados.TabIndex = 21;
            dgvEmpleados.SelectionChanged += dgvEmpleados_SelectionChanged;
            // 
            // cbxDepartamento
            // 
            cbxDepartamento.BackColor = SystemColors.ScrollBar;
            cbxDepartamento.FormattingEnabled = true;
            cbxDepartamento.Items.AddRange(new object[] { "RRHH", "Almacen", "Ventas" });
            cbxDepartamento.Location = new Point(206, 190);
            cbxDepartamento.Name = "cbxDepartamento";
            cbxDepartamento.Size = new Size(191, 28);
            cbxDepartamento.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 192);
            label5.Name = "label5";
            label5.Size = new Size(109, 20);
            label5.TabIndex = 18;
            label5.Text = "Departamento:";
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = SystemColors.ScrollBar;
            btnEliminar.Location = new Point(483, 206);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(173, 60);
            btnEliminar.TabIndex = 17;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click_1;
            // 
            // btnActualisar
            // 
            btnActualisar.BackColor = SystemColors.ScrollBar;
            btnActualisar.Location = new Point(483, 112);
            btnActualisar.Name = "btnActualisar";
            btnActualisar.Size = new Size(173, 60);
            btnActualisar.TabIndex = 16;
            btnActualisar.Text = "Actualizar";
            btnActualisar.UseVisualStyleBackColor = false;
            btnActualisar.Click += btnActualisar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = SystemColors.ScrollBar;
            btnAgregar.Location = new Point(483, 21);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(173, 60);
            btnAgregar.TabIndex = 15;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // cbxCargo
            // 
            cbxCargo.BackColor = SystemColors.ScrollBar;
            cbxCargo.FormattingEnabled = true;
            cbxCargo.Items.AddRange(new object[] { "Jefe", "Gerente", "Empleado" });
            cbxCargo.Location = new Point(206, 145);
            cbxCargo.Name = "cbxCargo";
            cbxCargo.Size = new Size(191, 28);
            cbxCargo.TabIndex = 14;
            cbxCargo.SelectedIndexChanged += cbxCargo_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 145);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
            label4.TabIndex = 13;
            label4.Text = "Cargo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 104);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 12;
            label3.Text = "Telefono:";
            // 
            // mtxtTelefono
            // 
            mtxtTelefono.BackColor = SystemColors.ScrollBar;
            mtxtTelefono.Location = new Point(206, 104);
            mtxtTelefono.Mask = "0000-0000";
            mtxtTelefono.Name = "mtxtTelefono";
            mtxtTelefono.Size = new Size(191, 27);
            mtxtTelefono.TabIndex = 11;
            // 
            // mtxtDUI
            // 
            mtxtDUI.BackColor = SystemColors.ScrollBar;
            mtxtDUI.Location = new Point(206, 61);
            mtxtDUI.Mask = "00000000-0";
            mtxtDUI.Name = "mtxtDUI";
            mtxtDUI.Size = new Size(191, 27);
            mtxtDUI.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 64);
            label2.Name = "label2";
            label2.Size = new Size(37, 20);
            label2.TabIndex = 2;
            label2.Text = "DUI:";
            // 
            // txtNombre
            // 
            txtNombre.BackColor = SystemColors.ScrollBar;
            txtNombre.Location = new Point(206, 21);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(191, 27);
            txtNombre.TabIndex = 1;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 24);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre Completo:";
            // 
            // Asistencias
            // 
            Asistencias.BackColor = SystemColors.InactiveBorder;
            Asistencias.Controls.Add(dgvAsistencias);
            Asistencias.Controls.Add(cbxPermiso);
            Asistencias.Controls.Add(mtxtHoraSalida);
            Asistencias.Controls.Add(label11);
            Asistencias.Controls.Add(mtxtHoraEntrada);
            Asistencias.Controls.Add(label10);
            Asistencias.Controls.Add(btnEnviar);
            Asistencias.Controls.Add(label9);
            Asistencias.Controls.Add(txtIdEmpleado);
            Asistencias.Controls.Add(label8);
            Asistencias.Controls.Add(label7);
            Asistencias.Controls.Add(dtpFecha);
            Asistencias.Location = new Point(4, 29);
            Asistencias.Name = "Asistencias";
            Asistencias.Size = new Size(687, 494);
            Asistencias.TabIndex = 1;
            Asistencias.Text = "Asistencias";
            // 
            // dgvAsistencias
            // 
            dgvAsistencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAsistencias.Location = new Point(5, 270);
            dgvAsistencias.Name = "dgvAsistencias";
            dgvAsistencias.RowHeadersWidth = 51;
            dgvAsistencias.Size = new Size(680, 203);
            dgvAsistencias.TabIndex = 30;
            // 
            // cbxPermiso
            // 
            cbxPermiso.BackColor = SystemColors.ScrollBar;
            cbxPermiso.FormattingEnabled = true;
            cbxPermiso.Items.AddRange(new object[] { "Con permiso", "Sin Permiso" });
            cbxPermiso.Location = new Point(481, 30);
            cbxPermiso.Name = "cbxPermiso";
            cbxPermiso.Size = new Size(191, 28);
            cbxPermiso.TabIndex = 29;
            // 
            // mtxtHoraSalida
            // 
            mtxtHoraSalida.BackColor = SystemColors.ScrollBar;
            mtxtHoraSalida.Location = new Point(188, 133);
            mtxtHoraSalida.Mask = "00:00";
            mtxtHoraSalida.Name = "mtxtHoraSalida";
            mtxtHoraSalida.Size = new Size(191, 27);
            mtxtHoraSalida.TabIndex = 28;
            mtxtHoraSalida.ValidatingType = typeof(DateTime);
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(21, 133);
            label11.Name = "label11";
            label11.Size = new Size(111, 20);
            label11.TabIndex = 27;
            label11.Text = "Hora de Salida:";
            // 
            // mtxtHoraEntrada
            // 
            mtxtHoraEntrada.BackColor = SystemColors.ScrollBar;
            mtxtHoraEntrada.Location = new Point(188, 77);
            mtxtHoraEntrada.Mask = "00:00";
            mtxtHoraEntrada.Name = "mtxtHoraEntrada";
            mtxtHoraEntrada.Size = new Size(191, 27);
            mtxtHoraEntrada.TabIndex = 26;
            mtxtHoraEntrada.ValidatingType = typeof(DateTime);
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(21, 77);
            label10.Name = "label10";
            label10.Size = new Size(121, 20);
            label10.TabIndex = 25;
            label10.Text = "Hora de Entrada:";
            // 
            // btnEnviar
            // 
            btnEnviar.BackColor = SystemColors.ScrollBar;
            btnEnviar.Location = new Point(469, 155);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(173, 60);
            btnEnviar.TabIndex = 24;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = false;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(396, 30);
            label9.Name = "label9";
            label9.Size = new Size(57, 20);
            label9.TabIndex = 23;
            label9.Text = "Estado:";
            // 
            // txtIdEmpleado
            // 
            txtIdEmpleado.BackColor = SystemColors.ScrollBar;
            txtIdEmpleado.Location = new Point(188, 22);
            txtIdEmpleado.Name = "txtIdEmpleado";
            txtIdEmpleado.Size = new Size(191, 27);
            txtIdEmpleado.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(21, 22);
            label8.Name = "label8";
            label8.Size = new Size(93, 20);
            label8.TabIndex = 4;
            label8.Text = "IdEmpleado:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 188);
            label7.Name = "label7";
            label7.Size = new Size(50, 20);
            label7.TabIndex = 3;
            label7.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.CalendarForeColor = SystemColors.InactiveBorder;
            dtpFecha.CalendarMonthBackground = SystemColors.InactiveBorder;
            dtpFecha.Location = new Point(188, 188);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(261, 27);
            dtpFecha.TabIndex = 0;
            // 
            // Reportes
            // 
            Reportes.BackColor = SystemColors.InactiveBorder;
            Reportes.Controls.Add(cbxCargarReporte);
            Reportes.Controls.Add(label15);
            Reportes.Controls.Add(btnGenerarReporte);
            Reportes.Controls.Add(btnExportar);
            Reportes.Controls.Add(dgvResultadosReportes);
            Reportes.Controls.Add(comboBox1);
            Reportes.Controls.Add(label14);
            Reportes.Controls.Add(dtpHasta);
            Reportes.Controls.Add(label13);
            Reportes.Controls.Add(dtpDesde);
            Reportes.Controls.Add(label12);
            Reportes.Location = new Point(4, 29);
            Reportes.Name = "Reportes";
            Reportes.Size = new Size(687, 494);
            Reportes.TabIndex = 2;
            Reportes.Text = "Reportes";
            // 
            // cbxCargarReporte
            // 
            cbxCargarReporte.BackColor = SystemColors.ScrollBar;
            cbxCargarReporte.FormattingEnabled = true;
            cbxCargarReporte.Items.AddRange(new object[] { "Jefe", "Gerente", "Empleado" });
            cbxCargarReporte.Location = new Point(154, 173);
            cbxCargarReporte.Name = "cbxCargarReporte";
            cbxCargarReporte.Size = new Size(191, 28);
            cbxCargarReporte.TabIndex = 29;
            cbxCargarReporte.SelectedIndexChanged += cbxCargarReporte_SelectedIndexChanged;
            cbxCargarReporte.Click += cbxCargarReporte_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(25, 181);
            label15.Name = "label15";
            label15.Size = new Size(49, 20);
            label15.TabIndex = 28;
            label15.Text = "Cargo";
            label15.Click += label15_Click;
            // 
            // btnGenerarReporte
            // 
            btnGenerarReporte.BackColor = SystemColors.ScrollBar;
            btnGenerarReporte.Location = new Point(498, 126);
            btnGenerarReporte.Name = "btnGenerarReporte";
            btnGenerarReporte.Size = new Size(173, 60);
            btnGenerarReporte.TabIndex = 26;
            btnGenerarReporte.Text = "Generar Reporte";
            btnGenerarReporte.UseVisualStyleBackColor = false;
            btnGenerarReporte.Click += btnGenerarReporte_Click_1;
            // 
            // btnExportar
            // 
            btnExportar.BackColor = SystemColors.ScrollBar;
            btnExportar.Location = new Point(498, 30);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(173, 60);
            btnExportar.TabIndex = 25;
            btnExportar.Text = "Exportar Excel";
            btnExportar.UseVisualStyleBackColor = false;
            btnExportar.Click += btnExportar_Click;
            // 
            // dgvResultadosReportes
            // 
            dgvResultadosReportes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultadosReportes.Location = new Point(17, 234);
            dgvResultadosReportes.Name = "dgvResultadosReportes";
            dgvResultadosReportes.RowHeadersWidth = 51;
            dgvResultadosReportes.Size = new Size(664, 252);
            dgvResultadosReportes.TabIndex = 16;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = SystemColors.ScrollBar;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Asistencias", "Planillas", "Empleados por Cargos" });
            comboBox1.Location = new Point(154, 126);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(191, 28);
            comboBox1.TabIndex = 15;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(17, 126);
            label14.Name = "label14";
            label14.Size = new Size(116, 20);
            label14.TabIndex = 8;
            label14.Text = "Tipo de reporte:";
            // 
            // dtpHasta
            // 
            dtpHasta.CalendarForeColor = SystemColors.InactiveBorder;
            dtpHasta.CalendarMonthBackground = SystemColors.InactiveBorder;
            dtpHasta.Location = new Point(154, 85);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(261, 27);
            dtpHasta.TabIndex = 7;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(25, 85);
            label13.Name = "label13";
            label13.Size = new Size(50, 20);
            label13.TabIndex = 6;
            label13.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            dtpDesde.CalendarForeColor = SystemColors.InactiveBorder;
            dtpDesde.CalendarMonthBackground = SystemColors.InactiveBorder;
            dtpDesde.Location = new Point(154, 30);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(261, 27);
            dtpDesde.TabIndex = 5;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(25, 30);
            label12.Name = "label12";
            label12.Size = new Size(54, 20);
            label12.TabIndex = 4;
            label12.Text = "Desde:";
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(695, 527);
            Controls.Add(tabControl1);
            Name = "frmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion de personal";
            Load += frmPrincipal_Load;
            tabControl1.ResumeLayout(false);
            Empleados.ResumeLayout(false);
            Empleados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            Asistencias.ResumeLayout(false);
            Asistencias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAsistencias).EndInit();
            Reportes.ResumeLayout(false);
            Reportes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultadosReportes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage Empleados;
        private TabPage Asistencias;
        private TabPage Reportes;
        private Label label2;
        private TextBox txtNombre;
        private Label label1;
        private Label label3;
        private MaskedTextBox mtxtTelefono;
        private MaskedTextBox mtxtDUI;
        private ComboBox cbxCargo;
        private Label label4;
        private Button btnAgregar;
        private Button btnActualisar;
        private ComboBox cbxDepartamento;
        private Label label5;
        private Button btnEliminar;
        private Label label6;
        private DataGridView dgvEmpleados;
        private ComboBox cbxEstado;
        private DateTimePicker dtpFecha;
        private Label label7;
        private TextBox txtIdEmpleado;
        private Label label8;
        private Label label9;
        private Button btnEnviar;
        private Label label10;
        private MaskedTextBox mtxtHoraEntrada;
        private Label label11;
        private MaskedTextBox mtxtHoraSalida;
        private DateTimePicker dtpHasta;
        private Label label13;
        private DateTimePicker dtpDesde;
        private Label label12;
        private Button btnExportar;
        private DataGridView dgvResultadosReportes;
        private ComboBox comboBox1;
        private Label label14;
        private Button btnGenerarReporte;
        private ComboBox cbxPermiso;
        private DataGridView dgvAsistencias;
        private Label label15;
        private ComboBox cbxCargarReporte;
    }
}
