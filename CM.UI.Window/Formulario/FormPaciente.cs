using CM.UI.Windows.ControladorAplicacion;
using CM.UI.Windows.VistaModelo;
using System;
using System.Data;
using System.Windows.Forms;

namespace CM.UI.Windows.Formulario
{
    public partial class FormPaciente : Form
    {
        private PacienteControlador pacienteControlador;
        private PacienteVistaModelo pacienteModelo;
        private bool modoEdicion = false;
        private int idPacienteEditar = 0;

        public FormPaciente()
        {
            InitializeComponent();
            pacienteControlador = new PacienteControlador();
            pacienteModelo = new PacienteVistaModelo();
        }

        private void FormPaciente_Load(object sender, EventArgs e)
        {
            CargarPacientes();
        }

        private void CargarPacientes()
        {
            dataGridViewPacientes.DataSource = null;
            var pacientes = pacienteControlador.ObtenerPacientes();

            DataTable pacientesTable = new DataTable();
            pacientesTable.Columns.Add("IdPaciente", typeof(int));
            pacientesTable.Columns.Add("Nombre", typeof(string));
            pacientesTable.Columns.Add("Apellido", typeof(string));
            pacientesTable.Columns.Add("Cedula", typeof(string));
            pacientesTable.Columns.Add("Direccion", typeof(string));
            pacientesTable.Columns.Add("Telefono", typeof(string));
            pacientesTable.Columns.Add("Correo", typeof(string));
            pacientesTable.Columns.Add("Estado", typeof(string)); // Columna de texto para mostrar "Activo" o "Inactivo"
            pacientesTable.Columns.Add("FechaNacimiento", typeof(DateTime));

            foreach (var paciente in pacientes)
            {
                DataRow row = pacientesTable.NewRow();
                row["IdPaciente"] = paciente.IdPaciente;
                row["Nombre"] = paciente.Nombre;
                row["Apellido"] = paciente.Apellido;
                row["Cedula"] = paciente.Cedula;
                row["Direccion"] = paciente.Direccion;
                row["Telefono"] = paciente.Telefono;
                row["Correo"] = paciente.Correo;
                row["Estado"] = paciente.Estado == 1 ? "Activo" : "Inactivo"; // Convertir aquí
                row["FechaNacimiento"] = paciente.FechaNacimiento;
                pacientesTable.Rows.Add(row);
            }

            dataGridViewPacientes.DataSource = pacientesTable;
        }

        private void LimpiarCampos()
        {
            idPacienteEditar = 0; // Asegurando que idPacienteEditar se inicialice correctamente
            modoEdicion = false;
            LimpiarControl(groupBox1.Controls);
            checkBoxActivo.Checked = false;
            checkBoxInactivo.Checked = false;
        }

        private void LimpiarControl(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
                else if (control is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.Value = DateTime.Today;
                }
                else if (control.HasChildren)
                {
                    LimpiarControl(control.Controls); // Llamada recursiva para limpiar controles anidados
                }
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(textNombre.Text) ||
                string.IsNullOrWhiteSpace(textApellido.Text) ||
                string.IsNullOrWhiteSpace(textCedula.Text) ||
                string.IsNullOrWhiteSpace(textDireccion.Text) ||
                string.IsNullOrWhiteSpace(textTelefono.Text) ||
                string.IsNullOrWhiteSpace(textCorreo.Text) ||
                (!checkBoxActivo.Checked && !checkBoxInactivo.Checked))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return false;
            }
            return true;
        }

        private void ActualizarModeloDesdeUI()
        {
            pacienteModelo.Nombre = textNombre.Text;
            pacienteModelo.Apellido = textApellido.Text;
            pacienteModelo.Cedula = textCedula.Text;
            pacienteModelo.Direccion = textDireccion.Text;
            pacienteModelo.Telefono = textTelefono.Text;
            pacienteModelo.Correo = textCorreo.Text;
            pacienteModelo.Estado = checkBoxActivo.Checked ? 1 : 0; // Convertir estado de CheckBox a valor numérico
            pacienteModelo.FechaNacimiento = dateTimeFechaNacimiento.Value;

            if (modoEdicion)
            {
                pacienteModelo.IdPaciente = idPacienteEditar;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                ActualizarModeloDesdeUI();

                if (modoEdicion)
                {
                    // Modo edición
                    if (pacienteControlador.ActualizarPaciente(pacienteModelo))
                    {
                        MessageBox.Show("Paciente actualizado correctamente.");
                        LimpiarCampos();
                        CargarPacientes();
                        modoEdicion = false; // Salir del modo edición
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el paciente. Verifique los datos y vuelva a intentarlo.");
                    }
                }
                else
                {
                    // Modo inserción
                    if (pacienteControlador.InsertarPaciente(pacienteModelo))
                    {
                        MessageBox.Show("Paciente insertado correctamente.");
                        LimpiarCampos();
                        CargarPacientes();
                    }
                    else
                    {
                        MessageBox.Show("Error al insertar el paciente. Verifique los datos y vuelva a intentarlo.");
                    }
                }
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dataGridViewPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewPacientes.Rows[e.RowIndex];
                idPacienteEditar = Convert.ToInt32(row.Cells["IdPaciente"].Value);
                textNombre.Text = row.Cells["Nombre"].Value.ToString();
                textApellido.Text = row.Cells["Apellido"].Value.ToString();
                textCedula.Text = row.Cells["Cedula"].Value.ToString();
                textDireccion.Text = row.Cells["Direccion"].Value.ToString();
                textTelefono.Text = row.Cells["Telefono"].Value.ToString();
                textCorreo.Text = row.Cells["Correo"].Value.ToString();
                string estadoTexto = row.Cells["Estado"].Value.ToString();

                // Convertir estado de texto a CheckBox
                checkBoxActivo.Checked = estadoTexto == "Activo";
                checkBoxInactivo.Checked = estadoTexto == "Inactivo";

                dateTimeFechaNacimiento.Value = Convert.ToDateTime(row.Cells["FechaNacimiento"].Value);

                modoEdicion = true; // Activar modo de edición
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (modoEdicion && idPacienteEditar > 0)
            {
                if (ValidarDatos())
                {
                    ActualizarModeloDesdeUI();

                    if (pacienteControlador.ActualizarPaciente(pacienteModelo))
                    {
                        MessageBox.Show("Paciente actualizado correctamente.");
                        LimpiarCampos();
                        CargarPacientes();
                        modoEdicion = false; // Salir del modo edición
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el paciente. Verifique los datos y vuelva a intentarlo.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un paciente para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idPacienteEditar > 0)
            {
                var confirmacion = MessageBox.Show("¿Está seguro de eliminar este paciente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    if (pacienteControlador.EliminarPaciente(idPacienteEditar))
                    {
                        MessageBox.Show("Paciente eliminado correctamente.");
                        LimpiarCampos();
                        CargarPacientes();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el paciente. Verifique los datos y vuelva a intentarlo.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un paciente para eliminar.");
            }
        }

        // Manejadores de eventos para los CheckBox
        private void checkBoxActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxActivo.Checked)
            {
                checkBoxInactivo.Checked = false;
            }
        }

        private void checkBoxInactivo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxInactivo.Checked)
            {
                checkBoxActivo.Checked = false;
            }
        }
    }
}
