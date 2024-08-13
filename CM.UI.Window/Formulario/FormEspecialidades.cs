using CM.UI.Window.ControladorAplicacion;
using CM.UI.Window.VistaModelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CM.UI.Window.Formulario
{
    public partial class FormEspecialidades : Form
    {
        private EspecialidadControlador especialidadControlador;
        private EspecialidadVistaModelo especialidadModelo;
        private bool modoEdicion = false;
        private int idEspecialidadEditar = 0;

        public FormEspecialidades()
        {
            InitializeComponent();
            especialidadControlador = new EspecialidadControlador();
            especialidadModelo = new EspecialidadVistaModelo();
        }

        private void FormEspecialidades_Load(object sender, EventArgs e)
        {
            CargarEspecialidads();
        }

        private void CargarEspecialidads()
        {
            dataGridViewEspecialidad.DataSource = null;
            var especialidads = especialidadControlador.ObtenerEspecialidad();

            DataTable especialidadsTable = new DataTable();
            especialidadsTable.Columns.Add("IdEspecialidad", typeof(int));
            especialidadsTable.Columns.Add("Nombre", typeof(string));
            especialidadsTable.Columns.Add("Descripcion", typeof(string));
            especialidadsTable.Columns.Add("Estado", typeof(string)); // Columna de texto para mostrar "Activo" o "Inactivo"

            foreach (var especialidad in especialidads)
            {
                DataRow row = especialidadsTable.NewRow();
                row["IdEspecialidad"] = especialidad.IdEspecialidad;
                row["Nombre"] = especialidad.Nombre;
                row["Descripcion"] = especialidad.Descripcion;
                row["Estado"] = especialidad.Estado == 1 ? "Activo" : "Inactivo"; // Convertir aquí
                especialidadsTable.Rows.Add(row);
            }

            dataGridViewEspecialidad.DataSource = especialidadsTable;
        }

        private void LimpiarCampos()
        {
            idEspecialidadEditar = 0; // Asegurando que idEspecialidadEditar se inicialice correctamente
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
                string.IsNullOrWhiteSpace(textDescripcion.Text) ||
                (!checkBoxActivo.Checked && !checkBoxInactivo.Checked))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return false;
            }
            return true;
        }

        private void ActualizarModeloDesdeUI()
        {
            especialidadModelo.Nombre = textNombre.Text;
            especialidadModelo.Descripcion = textDescripcion.Text;
            especialidadModelo.Estado = checkBoxActivo.Checked ? 1 : 0; // Convertir estado de CheckBox a valor numérico

            if (modoEdicion)
            {
                especialidadModelo.IdEspecialidad = idEspecialidadEditar;
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                ActualizarModeloDesdeUI();

                if (modoEdicion)
                {
                    // Modo edición
                    if (especialidadControlador.ActualizarEspecialidad(especialidadModelo))
                    {
                        MessageBox.Show("Especialidad actualizado correctamente.");
                        LimpiarCampos();
                        CargarEspecialidads();
                        modoEdicion = false; // Salir del modo edición
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el especialidad. Verifique los datos y vuelva a intentarlo.");
                    }
                }
                else
                {
                    // Modo inserción
                    if (especialidadControlador.InsertarEspecialidad(especialidadModelo))
                    {
                        MessageBox.Show("Especialidad insertado correctamente.");
                        LimpiarCampos();
                        CargarEspecialidads();
                    }
                    else
                    {
                        MessageBox.Show("Error al insertar el especialidad. Verifique los datos y vuelva a intentarlo.");
                    }
                }
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dataGridViewEspecialidads_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewEspecialidad.Rows[e.RowIndex];
                idEspecialidadEditar = Convert.ToInt32(row.Cells["IdEspecialidad"].Value);
                textNombre.Text = row.Cells["Nombre"].Value.ToString();
                textDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
                string estadoTexto = row.Cells["Estado"].Value.ToString();

                // Convertir estado de texto a CheckBox
                checkBoxActivo.Checked = estadoTexto == "Activo";
                checkBoxInactivo.Checked = estadoTexto == "Inactivo";

                modoEdicion = true; // Activar modo de edición
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (modoEdicion && idEspecialidadEditar > 0)
            {
                if (ValidarDatos())
                {
                    ActualizarModeloDesdeUI();

                    if (especialidadControlador.ActualizarEspecialidad(especialidadModelo))
                    {
                        MessageBox.Show("Especialidad actualizado correctamente.");
                        LimpiarCampos();
                        CargarEspecialidads();
                        modoEdicion = false; // Salir del modo edición
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el especialidad. Verifique los datos y vuelva a intentarlo.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un especialidad para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idEspecialidadEditar > 0)
            {
                var confirmacion = MessageBox.Show("¿Está seguro de eliminar este especialidad?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    if (especialidadControlador.EliminarEspecialidad(idEspecialidadEditar))
                    {
                        MessageBox.Show("Especialidad eliminado correctamente.");
                        LimpiarCampos();
                        CargarEspecialidads();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el especialidad. Verifique los datos y vuelva a intentarlo.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un especialidad para eliminar.");
            }
        }

        // Manejadores de eventos para los CheckBox
        private void checkBoxInactivo_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBoxInactivo.Checked)
            {
                checkBoxActivo.Checked = false;
            }
        }

        private void checkBoxActivo_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBoxActivo.Checked)
            {
                checkBoxInactivo.Checked = false;
            }

        }

    }
}


