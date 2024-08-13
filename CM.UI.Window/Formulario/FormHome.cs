using CM.Dominio.Modelo.Entidades;
using CM.UI.Window.ControladorAplicacion;
using CM.UI.Window.VistaModelo;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CM.UI.Window.Formulario
{
    public partial class FormHome : Form
    {
        //HORARIO MEDICO
        private HorarioMedicoControlador horarioMedicoControlador;
        private HorarioMedicoVistaModelo horarioMedicoModelo;
        //ESPECIALIDAD MEDICO 
        private EspecialidadMedicoControlador especialidadMedicoControlador;
        private EspecialidadMedicoVistaModelo especialidadMedicoModelo;


        //TABLAS PARA LA REFERENCIA Especialidad - Medico - Horario
        private EspecialidadControlador especialidadControlador;
        private MedicoControlador medicoControlador;
        private HorarioControlador horarioControlador;

        private bool modoEdicion = false;
        private int idHorarioMedicoEditar = 0;

        public FormHome()
        {
            InitializeComponent();
            //HORARIO MEDICO
            horarioMedicoControlador = new HorarioMedicoControlador();
            horarioMedicoModelo = new HorarioMedicoVistaModelo();
            //ESPACILIDAD MEDICO
            especialidadMedicoControlador = new EspecialidadMedicoControlador();
            especialidadMedicoModelo = new EspecialidadMedicoVistaModelo();
            //PARA LA REFENCIA DE LA TABLA
            especialidadControlador = new EspecialidadControlador();
            medicoControlador = new MedicoControlador();
            horarioControlador = new HorarioControlador();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            //HORARIO MEDICO
            CargarHorarioMedicos();
            //ESPECIALIDAD
            CargarEpecialidadMedicos();
            //PARA LAS REFERENCIAS
            listarEspecialidad();
            listarMedico();
            //CargarMedico();
            //CargarHorario();
        }

        /// <summary>
        /// TABLA PARA ESPECIALDIAD MEDICO
        /// </summary>

        //CHECK BOX PARA LA ESPECILIDAD
        public void listarEspecialidad()
        {
            checkedListEspecialidades.Items.Clear();
            var lista = especialidadControlador.ObtenerEspecialidad();
            foreach (var item in lista)
            {
                checkedListEspecialidades.Items.Add(new { Id = item.IdEspecialidad, Nombre = item.Nombre });
            }
            checkedListEspecialidades.DisplayMember = "Nombre";
            checkedListEspecialidades.ValueMember = "Id";
        }


        //COMBO BOX PARA EL MEDICO
        private void listarMedico()
        {
            var medicos = medicoControlador.ObtenerMedicos().ToList();
            medicos.Insert(0, new MedicoVistaModelo { Nombre = "Seleccione un Médico", IdMedico = 0 });
            comboBoxMedico.DataSource = medicos;
            comboBoxMedico.DisplayMember = "Nombre";
            comboBoxMedico.ValueMember = "IdMedico";
        }


        //TABLA ESPECIALIDAD MEDICO
        private void CargarEpecialidadMedicos()
        {
            dataGridViewEspecialidadMedico.DataSource = null;
            var especialidadMedicos = especialidadMedicoControlador.ObtenerEspecialidadMedico();

            DataTable especialidadMedicosTable = new DataTable();
            especialidadMedicosTable.Columns.Add("IdEspecialidad", typeof(int));
            especialidadMedicosTable.Columns.Add("Especialidad", typeof(string));
            especialidadMedicosTable.Columns.Add("Medico", typeof(string));

            foreach (var especialidadMedico in especialidadMedicos)
            {
                DataRow row = especialidadMedicosTable.NewRow();
                row["IdEspecialidad"] = especialidadMedico.IdMedicoEspecialidad;


                // Obtener el nombre del Especialidad desde el controlador de especialidad
                var especialidad = especialidadControlador.ObtenerEspecialidadPorId(especialidadMedico.IdEspecialidad);
                // Asumiendo que "Descripcion" es el campo que contiene el nombre del consultorio
                row["Especialidad"] = especialidad != null ? especialidad.nombre : "";

                // Obtener el nombre del medico desde el controlador del medico
                var medico = medicoControlador.ObtenerMedicoPorId(especialidadMedico.IdMedico);
                // Asumiendo que "Descripcion" es el campo que contiene el nombre del consultorio
                row["Medico"] = medico != null ? medico.nombre : "";



                especialidadMedicosTable.Rows.Add(row);
            }

            dataGridViewEspecialidadMedico.DataSource = especialidadMedicosTable;
        }

        //LIMPIAR CAMPOS DE ESPCIALIDAD MEDICO
        private void LimpiarCampos()
        {
            idHorarioMedicoEditar = 0;
            modoEdicion = false;
            comboBoxMedico.SelectedIndex = 0;
            foreach (int index in checkedListEspecialidades.CheckedIndices)
            {
                checkedListEspecialidades.SetItemCheckState(index, CheckState.Unchecked);
            }
        }


        private void LimpiarEspecialidad(Control.ControlCollection controls)
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
                    LimpiarEspecialidad(control.Controls); // Llamada recursiva para limpiar controles anidados
                }
            }
        }


        private bool ValidarDatos()
        {
            if (comboBoxMedico.SelectedIndex == 0 || checkedListEspecialidades.CheckedItems.Count == 0)
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return false;
            }
            return true;
        }


        private void ActualizarModeloDesdeUI()
        {
            especialidadMedicoModelo.IdEspecialidad = (int)comboBoxMedico.SelectedValue;


            if (modoEdicion)
            {
                especialidadMedicoModelo.IdMedicoEspecialidad = idHorarioMedicoEditar;
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                var especialidadMedicoModelo = new EspecialidadMedicoVistaModelo
                {
                    IdMedico = (int)comboBoxMedico.SelectedValue,
                    IdEspecialidad = ((dynamic)checkedListEspecialidades.SelectedItem).Id
                };

                if (modoEdicion)
                {
                    especialidadMedicoModelo.IdMedicoEspecialidad = idHorarioMedicoEditar;
                    if (especialidadMedicoControlador.ActualizarEspecialidadMedico(especialidadMedicoModelo))
                    {
                        MessageBox.Show("Especialidad Médico actualizada correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar la Especialidad Médico.");
                    }
                    modoEdicion = false;
                }
                else
                {
                    if (especialidadMedicoControlador.InsertarEspecialidadMedico(especialidadMedicoModelo))
                    {
                        MessageBox.Show("Especialidad Médico insertada correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error al insertar la Especialidad Médico.");
                    }
                }
                LimpiarCampos();
                CargarEpecialidadMedicos();
            }
        }


        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dataGridViewHorarioMedicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewEspecialidadMedico.Rows[e.RowIndex];
                idHorarioMedicoEditar = Convert.ToInt32(row.Cells["IdEspecialidad"].Value);


                modoEdicion = true; // Activar modo de edición
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (modoEdicion && idHorarioMedicoEditar > 0)
            {
                if (ValidarDatos())
                {
                    ActualizarModeloDesdeUI();

                    if (horarioMedicoControlador.ActualizarHorarioMedico(horarioMedicoModelo))
                    {
                        MessageBox.Show("HorarioMedico actualizado correctamente.");
                        LimpiarCampos();
                        // CargarHorarioMedicos();
                        modoEdicion = false; // Salir del modo edición
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el horarioMedico. Verifique los datos y vuelva a intentarlo.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un horarioMedico para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idHorarioMedicoEditar > 0)
            {
                var confirmacion = MessageBox.Show("¿Está seguro de eliminar esta especialidad médico?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmacion == DialogResult.Yes)
                {
                    if (especialidadMedicoControlador.EliminarEspecialidadMedico(idHorarioMedicoEditar))
                    {
                        MessageBox.Show("Especialidad Médico eliminada correctamente.");
                        LimpiarCampos();
                        CargarEpecialidadMedicos();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar la Especialidad Médico.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una especialidad médico para eliminar.");
            }
        }



























        /// <summary>
        /// TABLA PARA HORARIO MEDICO
        /// </summary>
        private void CargarHorarioMedicos()
        {
            dataGridViewHorarioMedico.DataSource = null;
            var horarioMedicos = horarioMedicoControlador.ObtenerHorarioMedico();

            DataTable horarioMedicosTable = new DataTable();
            horarioMedicosTable.Columns.Add("IdHorario", typeof(int));
            horarioMedicosTable.Columns.Add("Medico", typeof(string));
            horarioMedicosTable.Columns.Add("HorarioInicio", typeof(string));
            horarioMedicosTable.Columns.Add("HorarioFin", typeof(string));

            foreach (var horarioMedico in horarioMedicos)
            {
                DataRow row = horarioMedicosTable.NewRow();
                row["IdHorario"] = horarioMedico.IdHorarioMedico;


                // Obtener el nombre del medico desde el controlador de especialidad
                var medico = medicoControlador.ObtenerMedicoPorId(horarioMedico.IdHorario);
                // Asumiendo que "Descripcion" es el campo que contiene el nombre del consultorio
                row["Medico"] = medico != null ? medico.nombre : "";

                // Obtener el nombre del medico desde el controlador del medico
                var horario = horarioControlador.ObtenerHorarioPorId(horarioMedico.IdHorario);
                // Asumiendo que "Descripcion" es el campo que contiene el nombre del consultorio
                row["HorarioInicio"] = horario?.horaInicio.ToString() ?? "";
                row["HorarioFin"] = horario?.horaFin.ToString() ?? "";

                horarioMedicosTable.Rows.Add(row);
            }
            dataGridViewHorarioMedico.DataSource = horarioMedicosTable;
        }


        private void horafecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }
    }
}
