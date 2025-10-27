using SistemaDeGestionPersonal.core.Clases;
using SistemaDeGestionPersonal.core.DAO;

namespace SistemaDeGestionPersonal
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridViews();
            CargarCombos();
            CargarEmpleados();
            CargarAsistencias();
        }
        // DAOs
        private readonly IEmpleadoDAO empleadoDAO = new EmpleadoDAO();
        private readonly IDepartamentoDAO deptoDAO = new DepartamentoDAO();
        private readonly ICargoDAO cargoDAO = new CargoDAO();
        private readonly IAsistenciasDAO asistenciaDAO = new AsistenciaDAO();

        // Estado
        private int empleadoSeleccionadoId = -1;

        #region Configuraci�n de DataGridViews

        private void ConfigurarDataGridViews()
        {
            // dgvEmpleados
            dgvEmpleados.AutoGenerateColumns = false;
            dgvEmpleados.Columns.Clear();
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Visible = false });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NombreCompleto", HeaderText = "Nombre" });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DUI", HeaderText = "DUI" });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Telefono", HeaderText = "Tel�fono" });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Estado", HeaderText = "Estado" });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NombreDepartamento", HeaderText = "Departamento" });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NombreCargo", HeaderText = "Cargo" });

            // dgvAsistencias
            dgvAsistencias.AutoGenerateColumns = false;
            dgvAsistencias.Columns.Clear();
            dgvAsistencias.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Visible = false });
            dgvAsistencias.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NombreEmpleado", HeaderText = "Empleado" });
            dgvAsistencias.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Fecha", HeaderText = "Fecha", DefaultCellStyle = { Format = "dd/MM/yyyy" } });
            dgvAsistencias.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "HoraEntrada", HeaderText = "Entrada", DefaultCellStyle = { Format = @"hh\:mm" } });
            dgvAsistencias.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "HoraSalida", HeaderText = "Salida", DefaultCellStyle = { Format = @"hh\:mm" } });
            dgvAsistencias.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Estado", HeaderText = "Estado" });
            dgvAsistencias.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nota", HeaderText = "Nota" });

            // dgvResultadosReporte
            dgvResultadosReportes.AutoGenerateColumns = false;
            dgvResultadosReportes.Columns.Clear();
            dgvResultadosReportes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NombreCompleto", HeaderText = "Empleado" });
            dgvResultadosReportes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SalarioBase", HeaderText = "Salario Base", DefaultCellStyle = { Format = "C2" } });
            dgvResultadosReportes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DiasPresente", HeaderText = "D�as Presente" });
            dgvResultadosReportes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DiasJustificados", HeaderText = "Justificados" });
            dgvResultadosReportes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DiasTarde", HeaderText = "Tardes" });
            dgvResultadosReportes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DiasAusentes", HeaderText = "Ausencias" });
            dgvResultadosReportes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DescuentoTarde", HeaderText = "Desc. Tardes", DefaultCellStyle = { Format = "C2" } });
            dgvResultadosReportes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DescuentoAusente", HeaderText = "Desc. Ausencias", DefaultCellStyle = { Format = "C2" } });
            dgvResultadosReportes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PagoNeto", HeaderText = "Pago Neto", DefaultCellStyle = { Format = "C2" } });
        }

        #endregion

        #region Carga de Combos y Datos

        private void CargarCombos()
        {
            // Empleados Tab
            var cargos = cargoDAO.GetAll();
            cbxCargo.DisplayMember = "Nombre";
            cbxCargo.ValueMember = "Id";
            cbxCargo.DataSource = cargos;

            var deptos = deptoDAO.GetAll();
            cbxDepartamento.DisplayMember = "Nombre";
            cbxDepartamento.ValueMember = "Id";
            cbxDepartamento.DataSource = deptos;

            cbxEstado.Items.Clear();
            cbxEstado.Items.AddRange(new string[] { "Activo", "Desactivo" });

            // Asistencias Tab
            cbxPermiso.Items.Clear();
            cbxPermiso.Items.AddRange(new string[] { "Presente", "Ausente", "Tarde", "Justificado" });

            // Reportes Tab
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] { "Asistencia", "Planilla", "Empleados por cargo" });
        }

        private void CargarEmpleados()
        {
            dgvEmpleados.DataSource = empleadoDAO.GetAllWithRelations();
        }

        private void CargarAsistencias()
        {
            // Aqu� cargar�as con JOIN para NombreEmpleado, pero por simplicidad:
            var asistencias = asistenciaDAO.GetAll();
            foreach (var a in asistencias)
            {
                var emp = empleadoDAO.GetById(a.EmpleadoId);
                a.NombreEmpleado = emp?.NombreCompleto ?? "Desconocido";
            }
            dgvAsistencias.DataSource = asistencias;
        }

        #endregion

        #region Eventos - Empleados

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvEmpleados.Rows[e.RowIndex];
            empleadoSeleccionadoId = Convert.ToInt32(row.Cells["Id"].Value);

            txtNombre.Text = row.Cells["NombreCompleto"].Value?.ToString() ?? "";
            mtxtDUI.Text = row.Cells["DUI"].Value?.ToString() ?? "";
            mtxtTelefono.Text = row.Cells["Telefono"].Value?.ToString() ?? "";
            cbxEstado.Text = row.Cells["Estado"].Value?.ToString() ?? "";

            if (int.TryParse(row.Cells["DepartamentoId"].Value?.ToString(), out int deptoId))
                cbxDepartamento.SelectedValue = deptoId;
            if (int.TryParse(row.Cells["CargoId"].Value?.ToString(), out int cargoId))
                cbxCargo.SelectedValue = cargoId;
        }



        private void LimpiarCamposEmpleado()
        {
            txtNombre.Clear();
            mtxtDUI.Clear();
            mtxtTelefono.Clear();
            cbxEstado.SelectedIndex = -1;
            cbxDepartamento.SelectedIndex = -1;
            cbxCargo.SelectedIndex = -1;
            empleadoSeleccionadoId = -1;
        }

        #endregion

        #region Eventos - Asistencias

        private void btnEnviarAsistencia_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtIdEmpleado.Text, out int empId))
                {
                    MessageBox.Show("Ingrese un ID de empleado v�lido.");
                    return;
                }

                if (cbxPermiso.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un estado de asistencia.");
                    return;
                }

                var asistencia = new Asistencias
                {
                    Fecha = dtpFecha.Value.Date,
                    HoraEntrada = TimeSpan.Parse(mtxtHoraEntrada.Text),
                    HoraSalida = TimeSpan.Parse(mtxtHoraSalida.Text),
                    Estado = cbxPermiso.SelectedItem.ToString(),
                    EmpleadoId = empId
                };

                asistenciaDAO.Insert(asistencia);
                MessageBox.Show("Asistencia registrada correctamente.");
                CargarAsistencias();
                LimpiarCamposAsistencia();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCamposAsistencia()
        {
            txtIdEmpleado.Clear();
            dtpFecha.Value = DateTime.Today;
            mtxtHoraEntrada.Text = "";
            mtxtHoraSalida.Text = "";
            cbxPermiso.SelectedIndex = -1;
        }

        #endregion

        #region Eventos - Reportes

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            string tipo = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(tipo))
            {
                MessageBox.Show("Seleccione un tipo de reporte.");
                return;
            }

            switch (tipo)
            {
                case "Planilla":
                    var servicio = new NominaDAO();
                    var nomina = servicio.CalcularNominaMensual(dtpDesde.Value);
                    dgvResultadosReportes.DataSource = nomina;
                    break;

                case "Asistencia":
                    // Aqu� podr�as filtrar asistencias entre fechas
                    MessageBox.Show("Funcionalidad de reporte de asistencia no implementada a�n.");
                    break;

                case "Empleados por cargo":
                    // Filtrar empleados por cargo
                    MessageBox.Show("Funcionalidad de empleados por cargo no implementada a�n.");
                    break;

                default:
                    MessageBox.Show("Tipo de reporte no reconocido.");
                    break;
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Exportaci�n a Excel no implementada a�n.");
        }

        #endregion

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || cbxCargo.SelectedValue == null || cbxDepartamento.SelectedValue == null)
                {
                    MessageBox.Show("Complete los campos obligatorios: Nombre, Cargo y Departamento.");
                    return;
                }

                var emp = new Empleado
                {
                    NombreCompleto = txtNombre.Text,
                    Dui = mtxtDUI.Text,
                    Telefono = mtxtTelefono.Text,
                    Estado = cbxEstado.Text,
                    DepartamentoId = (int)cbxDepartamento.SelectedValue,
                    CargoId = (int)cbxCargo.SelectedValue
                };

                empleadoDAO.Insert(emp);
                MessageBox.Show("Empleado registrado correctamente.");
                CargarEmpleados();
                LimpiarCamposEmpleado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxCargo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnActualisar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (empleadoSeleccionadoId == -1)
            {
                MessageBox.Show("Seleccione un empleado.");
                return;
            }

            if (MessageBox.Show("�Desea dar de baja a este empleado?\nSi tiene historial, solo se marcar� como inactivo.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (empleadoDAO.Delete(empleadoSeleccionadoId))
                {
                    MessageBox.Show("Empleado dado de baja correctamente.");
                    CargarEmpleados();
                    LimpiarCamposEmpleado();
                }
            }
        }
    }

}

