using SistemaDeGestionPersonal.core.Clases;
using SistemaDeGestionPersonal.core.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeGestionPersonal
{
    public partial class frmActualizar : Form
    {
        private readonly IEmpleadoDAO empleadoDAO = new EmpleadoDAO();
        private readonly ICargoDAO cargoDAO = new CargoDAO();
        private readonly IDepartamentoDAO deptoDAO = new DepartamentoDAO();
        private readonly int _empleadoId;
        private Empleado empleado;


        internal frmActualizar(Empleado emp)
        {
            InitializeComponent();
            empleado = emp ?? throw new ArgumentNullException(nameof(emp));  // Corrección: usa 'emp', no 'empleado'
            _empleadoId = emp.Id;  // Asigna el Id del empleado
            CargarCombos();
            CargarDatos();
        }

        private void CargarCombos()
        {
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
        }

        private void CargarDatos()
        {
            txtNombre.Text = empleado.NombreCompleto;
            mtxtDUI.Text = empleado.Dui;
            mtxtTelefono.Text = empleado.Telefono;
            cbxEstado.Text = empleado.Estado;
            cbxDepartamento.SelectedValue = empleado.DepartamentoId;
            cbxCargo.SelectedValue = empleado.CargoId;
        }

        private void btnActualisar_Click(object sender, EventArgs e)
        {
            empleado.NombreCompleto = txtNombre.Text;
            empleado.Dui = mtxtDUI.Text;
            empleado.Telefono = mtxtTelefono.Text;
            empleado.Estado = cbxEstado.Text;
            empleado.DepartamentoId = (int)cbxDepartamento.SelectedValue;
            empleado.CargoId = (int)cbxCargo.SelectedValue;
            if (empleadoDAO.Update(empleado))
            {
                MessageBox.Show("Empleado actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
