 using pjGestionEmpleados.Datos;
using pjGestionEmpleados.Entidades;
using pjGestionEmpleados.Presentacion.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjGestionEmpleados.Presentacion
{
    public partial class frmEmpleados : Form
    {
        public frmEmpleados()
        {
            InitializeComponent();
        }
        #region "Variables"
            int iCodigoEmpleado = 0;
            bool bEstadoGuardar = true;
        #endregion
        #region "Métodos"

        private void CargarEmpleados(string cBusqueda)
        {
            D_Empleados Datos = new D_Empleados();
            dgvLista.DataSource = Datos.Listar_Empleados(cBusqueda);

            FormatoListarEmpleados();
        }

        private void FormatoListarEmpleados()
        {
            dgvLista.Columns[0].Width = 45;
            dgvLista.Columns[1].Width = 118;
            dgvLista.Columns[2].Width = 144;
            dgvLista.Columns[3].Width = 83;
            dgvLista.Columns[4].Width = 130;
            dgvLista.Columns[5].Width = 118;
            dgvLista.Columns[6].Width = 115;
            dgvLista.Columns[6].Width = 115;

        }

        private void CargarDepartamentos()
        {
            D_Departamentos Datos = new D_Departamentos();
            cmbDepartamento.DataSource = Datos.Listar_Departamentos();
            cmbDepartamento.ValueMember = "id_departamento";
            cmbDepartamento.DisplayMember = "nombre_departamento";
            cmbDepartamento.SelectedIndex = -1;

        }

        private void CargarCargos()
        {
            D_Cargos Datos = new D_Cargos();
            cmbCargo.DataSource = Datos.Listar_Cargos();
            cmbCargo.ValueMember = "id_cargo";
            cmbCargo.DisplayMember = "nombre_cargo";
            cmbCargo.SelectedIndex = -1; 

        }

        private void ActivarTextos(bool bEstado)
        {
            txtNombre.Enabled = bEstado;
            txtDireccion.Enabled = bEstado;
            txtTelefono.Enabled = bEstado;
            txtSalario.Enabled = bEstado;
            cmbDepartamento.Enabled = bEstado;
            cmbCargo.Enabled = bEstado;
            dtpFechaNacimiento.Enabled = bEstado;

            txtBuscar.Enabled = !bEstado;
        }

        private void ActivarBotones(bool bEstado)
        {
            btnNuevo.Enabled = bEstado;
            btnActualizar.Enabled = bEstado;
            btnEliminar.Enabled = bEstado;
            btnReporte.Enabled = bEstado;
            

            btnGuardar.Visible = !bEstado;
            btnCancelar.Visible = !bEstado;
        }

        private void SeleccionarEmpleados()
        {
            iCodigoEmpleado = Convert.ToInt32(dgvLista.CurrentRow.Cells["ID"].Value);

            txtNombre.Text = Convert.ToString(dgvLista.CurrentRow.Cells["Nombre"].Value);
            txtDireccion.Text = Convert.ToString(dgvLista.CurrentRow.Cells["Direccción"].Value);
            txtTelefono.Text = Convert.ToString(dgvLista.CurrentRow.Cells["Teléfono"].Value);
            txtSalario.Text = Convert.ToString(dgvLista.CurrentRow.Cells["Salario"].Value);
            cmbDepartamento.Text = Convert.ToString(dgvLista.CurrentRow.Cells["Departamento"].Value);
            cmbCargo.Text = Convert.ToString(dgvLista.CurrentRow.Cells["Cargo"].Value);
            dtpFechaNacimiento.Value = Convert.ToDateTime(dgvLista.CurrentRow.Cells["Fecha de Nacimiento"].Value);
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtSalario.Clear();
            txtBuscar.Clear();

            cmbDepartamento.SelectedIndex = -1;
            cmbCargo.SelectedIndex = -1;

            dtpFechaNacimiento.Value = DateTime.Now;

            iCodigoEmpleado = 0;
        }

        private void GuardarEmpleado()
        {
            E_Empleado Empleado = new E_Empleado();
            Empleado.Nombre_Empleado = txtNombre.Text;
            Empleado.Direccion_Empleado = txtDireccion.Text;
            Empleado.Telefono = txtTelefono.Text;
            Empleado.Salario = Convert.ToDecimal(txtSalario.Text);
            Empleado.Fecha_Nacimiento_Empleado = dtpFechaNacimiento.Value;
            Empleado.ID_Departamento = Convert.ToInt32(cmbDepartamento.SelectedValue);
            Empleado.ID_Cargo = Convert.ToInt32(cmbCargo.SelectedValue);

            D_Empleados Datos = new D_Empleados();
            string Respuesta = Datos.Guardar_Empleado(Empleado);

            if (Respuesta == "OK")
            {
                CargarEmpleados("%");
                Limpiar();
                ActivarTextos(false);
                ActivarBotones(true);

                MessageBox.Show("Datos Guardados Correctamente", "Sistema de Gestión de Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(Respuesta, "Sistema de Gestión de Empleados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ActualizarEmpleado()
        {
            E_Empleado Empleado = new E_Empleado();

            Empleado.ID_Empleado = iCodigoEmpleado;
            Empleado.Nombre_Empleado = txtNombre.Text;
            Empleado.Direccion_Empleado = txtDireccion.Text;
            Empleado.Telefono = txtTelefono.Text;
            Empleado.Salario = Convert.ToDecimal(txtSalario.Text);
            Empleado.Fecha_Nacimiento_Empleado = dtpFechaNacimiento.Value;
            Empleado.ID_Departamento = Convert.ToInt32(cmbDepartamento.SelectedValue);
            Empleado.ID_Cargo = Convert.ToInt32(cmbCargo.SelectedValue);

            D_Empleados Datos = new D_Empleados();
            string Respuesta = Datos.Actualizar_Empleado(Empleado);

            if (Respuesta == "OK")
            {
                CargarEmpleados("%");
                Limpiar();
                ActivarTextos(false);
                ActivarBotones(true);

                MessageBox.Show("Datos Actualizados Correctamente", "Sistema de Gestión de Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(Respuesta, "Sistema de Gestión de Empleados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DesactivarEmpleado(int iCodigoEmpleado)
        {
            D_Empleados Datos = new D_Empleados();
            string Respuesta = Datos.Desactivar_Empleado(iCodigoEmpleado);

            if (Respuesta == "OK")
            {
                CargarEmpleados("%");
                Limpiar();
                ActivarTextos(false);
                ActivarBotones(true);

                MessageBox.Show("Registro Eliminado Correctamente", "Sistema de Gestión de Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(Respuesta, "Sistema de Gestión de Empleados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private bool ValidarTextos() 
        {
            bool HayTextosVacios = false;

            if(string.IsNullOrEmpty(txtNombre.Text)) HayTextosVacios = true;
            if(string.IsNullOrEmpty(txtTelefono.Text)) HayTextosVacios = true;
            if(string.IsNullOrEmpty(txtSalario.Text)) HayTextosVacios = true;
           
            return HayTextosVacios;
        }
        #endregion

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            CargarEmpleados("%");
            CargarDepartamentos();
            CargarCargos();
                        
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarEmpleados(txtBuscar.Text);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarEmpleados(txtBuscar.Text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            bEstadoGuardar = true;
            iCodigoEmpleado = 0;

            ActivarTextos(true);
            ActivarBotones(false);
            Limpiar();

            txtNombre.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            bEstadoGuardar = true;
            iCodigoEmpleado = 0;

            ActivarTextos(false);
            ActivarBotones(true);
            Limpiar();
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarEmpleados();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (iCodigoEmpleado == 0)
            {
                MessageBox.Show("Selecciona un Registro", "Sistema de Gestión de Empleados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                bEstadoGuardar = false;


                ActivarTextos(true);
                ActivarBotones(false);

                txtNombre.Select();
            }
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(ValidarTextos())
            {
                MessageBox.Show("Hay Campos Vacio, debes llenar los campos (*) obligatorios", "Sistema de Gestión de Empleados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (bEstadoGuardar)
                {
                    GuardarEmpleado();
                }
                else
                {
                    ActualizarEmpleado();
                }
                
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (iCodigoEmpleado == 0)
            {
                MessageBox.Show("Selecciona un Registro", "Sistema de Gestión de Empleados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult resultado = MessageBox.Show("¿Estás seguro de eliminar el registro seleccionado?", "Sistema de Gestión de Empleados", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                { 
                DesactivarEmpleado(iCodigoEmpleado);
                }
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            frmReportesEmpleados formReporteEmpleados = new frmReportesEmpleados();
            formReporteEmpleados.txtFiltrar.Text = txtBuscar.Text;
            formReporteEmpleados.ShowDialog();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
