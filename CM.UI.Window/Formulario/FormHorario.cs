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
    public partial class FormHorario : Form
    {
        private HorarioControlador horarioControlador;
        private HorarioVistaModelo horarioModelo;
        private bool modoEdicion = false;
        private int idHorarioEditar = 0;

        public FormHorario()
        {
            InitializeComponent();

            horarioControlador = new HorarioControlador();
            horarioModelo = new HorarioVistaModelo();
        }


        private void FormHorario_Load(object sender, EventArgs e)
        {
            CargarHorario();

        }

        private void CargarHorario()
        {
            dataGridViewHorario.DataSource = null;
            var horarios = horarioControlador.ObtenerHorario();

            DataTable horariosTable = new DataTable();
            horariosTable.Columns.Add("IdHorario", typeof(int));
            horariosTable.Columns.Add("Fecha", typeof(DateTime));
            horariosTable.Columns.Add("HoraInicio", typeof(TimeSpan)); // HoraHorario como TimeSpan
            horariosTable.Columns.Add("HoraFin", typeof(TimeSpan)); // HoraHorario como TimeSpan
            horariosTable.Columns.Add("Descripcion", typeof(string));
            horariosTable.Columns.Add("Estado", typeof(string)); // Columna de texto para mostrar "Activo" o "Inactivo"

            foreach (var horario in horarios)
            {
                DataRow row = horariosTable.NewRow();
                row["IdHorario"] = horario.IdHorario;
                row["Fecha"] = horario.Fecha;
                row["HoraInicio"] = horario.HoraInicio;
                row["HoraFin"] = horario.HoraFin;
                row["Descripcion"] = horario.Descripcion;
                row["Estado"] = horario.Estado == 1 ? "Activo" : "Inactivo"; // Convertir aquí
                horariosTable.Rows.Add(row);
            }

            dataGridViewHorario.DataSource = horariosTable;
        }


        private void LimpiarCampos()
        {
            idHorarioEditar = 0; // Asegurando que idHorarioEditar se inicialice correctamente
            modoEdicion = false;
            LimpiarControl(groupBox1.Controls);
            checkBoxActivo.Checked = false;
            checkBoxInactivo.Checked = false;


        }

        private void LimpiarControl(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
                else if (control is DateTimePicker)
                {
                    ((DateTimePicker)control).Value = DateTime.Today;
                }
                else if (control.HasChildren)
                {
                    // Llamada recursiva para limpiar controles anidados
                    LimpiarControl(control.Controls);
                }
            }
        }

        private bool ValidarDatos()
        {
            if (
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
            horarioModelo.Fecha = dateTimeFechaRegistro.Value;
            horarioModelo.HoraInicio = dateTimeFechaHorarioInicio.Value.TimeOfDay;
            horarioModelo.HoraFin = dateTimeFechaHorarioFin.Value.TimeOfDay;
            horarioModelo.Descripcion = textDescripcion.Text;
            horarioModelo.Estado = checkBoxActivo.Checked ? 1 : 0; // Convertir estado de CheckBox a valor numérico


            if (modoEdicion)
            {
                horarioModelo.IdHorario = idHorarioEditar; // Solo para modo edición
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
                    if (horarioControlador.ActualizarHorario(horarioModelo))
                    {
                        MessageBox.Show("Horario actualizado correctamente.");
                        LimpiarCampos();
                        CargarHorario();
                        modoEdicion = false; // Salir del modo edición
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el horario. Verifique los datos y vuelva a intentarlo.");
                    }
                }
                else
                {
                    // Modo inserción
                    if (horarioControlador.InsertarHorario(horarioModelo))
                    {
                        MessageBox.Show("Horario insertado correctamente.");
                        LimpiarCampos();
                        CargarHorario();
                    }
                    else
                    {
                        MessageBox.Show("Error al insertar el horario. Verifique los datos y vuelva a intentarlo.");
                    }
                }
            }
        }

        private void buttonCancelar_Click_1(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dataGridViewHorario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewHorario.Rows[e.RowIndex];
                idHorarioEditar = Convert.ToInt32(row.Cells["IdHorario"].Value);
                dateTimeFechaRegistro.Value = Convert.ToDateTime(row.Cells["Fecha"].Value);
                textDescripcion.Text = row.Cells["Descripcion"].Value.ToString();

                // Convertir a TimeSpan HORA INICIO
                TimeSpan Inicio = (TimeSpan)row.Cells["HoraInicio"].Value;
                dateTimeFechaHorarioInicio.Value = DateTime.Today.Add(Inicio);

                // Convertir a TimeSpan HORA INICIO
                TimeSpan Fin = (TimeSpan)row.Cells["HoraFin"].Value;
                dateTimeFechaHorarioFin.Value = DateTime.Today.Add(Fin);

                string estadoTexto = row.Cells["Estado"].Value.ToString();

                // Convertir estado de texto a CheckBox
                checkBoxActivo.Checked = estadoTexto == "Activo";
                checkBoxInactivo.Checked = estadoTexto == "Inactivo";

                modoEdicion = true; // Activar modo de edición
            }
        }
        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (modoEdicion && idHorarioEditar > 0)
            {
                if (ValidarDatos())
                {
                    ActualizarModeloDesdeUI();

                    if (horarioControlador.ActualizarHorario(horarioModelo))
                    {
                        MessageBox.Show("Horario actualizado correctamente.");
                        LimpiarCampos();
                        CargarHorario();
                        modoEdicion = false; // Salir del modo edición
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el horario. Verifique los datos y vuelva a intentarlo.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un horario para editar.");
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (idHorarioEditar > 0)
            {
                var confirmacion = MessageBox.Show("¿Está seguro de eliminar este horario?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    if (horarioControlador.EliminarHorario(idHorarioEditar))
                    {
                        MessageBox.Show("Horario eliminado correctamente.");
                        LimpiarCampos();
                        CargarHorario();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el horario. Verifique los datos y vuelva a intentarlo.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un horario para eliminar.");
            }
        }

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
