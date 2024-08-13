using CM.Dominio.Modelo.Entidades;
using CM.UI.Window.ControladorAplicacion;
using CM.UI.Window.VistaModelo;
using CM.UI.Windows.ControladorAplicacion;
using CM.UI.Windows.VistaModelo;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CM.UI.Window.Formulario
{
    public partial class FormCitas : Form
    {
        private CitasControlador citaControlador;
        private CitasVistaModelo citaModelo;
        //combo box
        private PacienteControlador pacienteControlador;
        private HorarioMedicoControlador horarioMedicoControlador;

        private bool modoEdicion = false;
        private int idCitaEditar = 0;

        public FormCitas()
        {
            InitializeComponent();

            //COMNO BOX PARA ESTADO CITAS datos quemados
            InicializarComboBoxEstadoCita();

            citaControlador = new CitasControlador();
            citaModelo = new CitasVistaModelo();

            //PARA EL COMBO BOX 
            pacienteControlador = new PacienteControlador();
            horarioMedicoControlador = new HorarioMedicoControlador();
        }




        private void InicializarComboBoxEstadoCita()
        {
            comboBoxEstadoCita.Items.Clear();
            comboBoxEstadoCita.Items.Add("Selecciona el estado"); // Texto inicial
            comboBoxEstadoCita.Items.AddRange(new object[] {
            "Pendiente",
            "Confirmada",
            "Cancelada",
            "Completada"
            });
            // Seleccionar el texto inicial por defecto
            comboBoxEstadoCita.SelectedIndex = 0;
        }

        private void FormCitas_Load(object sender, EventArgs e)
        {
            CargarCitas();
            InicializarComboBoxEstadoCita();

            //COMBO BOX 
            CargarPaciente();

        }

        //PARA EL COMBO BOX PACIENTE 
        private void CargarPaciente()
        {
            var paciente = pacienteControlador.ObtenerPacientes().ToList();

            // Agregar el texto "Seleccione un paciente" como primer elemento
            paciente.Insert(0, new PacienteVistaModelo { Nombre = "Seleccione un paciente", IdPaciente = 0 });

            comboBoxPaciente.DataSource = paciente;
            comboBoxPaciente.DisplayMember = "Paciente"; // Mostrar la Ubicacion del consultorio
            comboBoxPaciente.ValueMember = "IdPaciente";
        }

    

        private void CargarCitas()
        {
            dataGridViewCitas.DataSource = null;
            var citas = citaControlador.ObtenerCitas();

            DataTable citasTable = new DataTable();
            citasTable.Columns.Add("IdCita", typeof(int));
            citasTable.Columns.Add("Paciente", typeof(string));
            citasTable.Columns.Add("HorarioMedico", typeof(string));
            citasTable.Columns.Add("Descripcion", typeof(string));
            citasTable.Columns.Add("EstadoCita", typeof(string));
            citasTable.Columns.Add("FechaRegistro", typeof(DateTime));
            citasTable.Columns.Add("HoraCita", typeof(TimeSpan)); // HoraCita como TimeSpan
            citasTable.Columns.Add("Estado", typeof(string)); // Columna de texto para mostrar "Activo" o "Inactivo"

            foreach (var cita in citas)
            {
                DataRow row = citasTable.NewRow();
                row["IdCita"] = cita.IdCita;
                row["Paciente"] = cita.IdPaciente;


                // Obtener el nombre del consultorio desde el controlador de consultorios
                var paciente = pacienteControlador.ObtenerPacientePorId(cita.IdPaciente);
                row["Paciente"] = paciente != null ? paciente.nombre : ""; // Asumiendo que "Descripcion" es el campo que contiene el nombre del consultorio



                row["HorarioMedico"] = cita.IdHorarioMedico;
                row["Descripcion"] = cita.Descripcion;
                row["EstadoCita"] = cita.EstadoCita;
                row["FechaRegistro"] = cita.FechaRegistro;
                row["HoraCita"] = cita.HoraCita;
                row["Estado"] = cita.Estado == 1 ? "Activo" : "Inactivo"; // Convertir aquí
                
                
                
                citasTable.Rows.Add(row);
            }

            dataGridViewCitas.DataSource = citasTable;
        }


        private void LimpiarCampos()
        {
            idCitaEditar = 0; // Asegurando que idCitaEditar se inicialice correctamente
            modoEdicion = false;
            LimpiarControl(groupBox1.Controls);
            checkBoxActivo.Checked = false;
            checkBoxInactivo.Checked = false;
            // Limpiar ComboBox y seleccionar texto inicial
            comboBoxEstadoCita.SelectedIndex = 0;
            comboBoxPaciente.SelectedIndex = 0;

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
            if (comboBoxPaciente.SelectedIndex == -1 ||
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
            citaModelo.IdPaciente = (int)comboBoxPaciente.SelectedValue;
            citaModelo.Descripcion = textDescripcion.Text;
            citaModelo.EstadoCita = comboBoxEstadoCita.SelectedItem.ToString();
            citaModelo.HoraCita = dateTimeFechaCita.Value.TimeOfDay;
            citaModelo.FechaRegistro = dateTimeFechaRegistro.Value;
            citaModelo.Estado = checkBoxActivo.Checked ? 1 : 0; // Convertir estado de CheckBox a valor numérico

           
            if (modoEdicion)
            {
                citaModelo.IdCita = idCitaEditar; // Solo para modo edición
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
                    if (citaControlador.ActualizarCitas(citaModelo))
                    {
                        MessageBox.Show("Cita actualizado correctamente.");
                        LimpiarCampos();
                        CargarCitas();
                        modoEdicion = false; // Salir del modo edición
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el cita. Verifique los datos y vuelva a intentarlo.");
                    }
                }
                else
                {
                    // Modo inserción
                    if (citaControlador.InsertarCitas(citaModelo))
                    {
                        MessageBox.Show("Cita insertado correctamente.");
                        LimpiarCampos();
                        CargarCitas();
                    }
                    else
                    {
                        MessageBox.Show("Error al insertar el cita. Verifique los datos y vuelva a intentarlo.");
                    }
                }
            }
        }

        private void buttonCancelar_Click_1(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dataGridViewCitas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewCitas.Rows[e.RowIndex];
                idCitaEditar = Convert.ToInt32(row.Cells["IdCita"].Value);
                string nombrePaciente = row.Cells["Paciente"].Value.ToString();
                textDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
                comboBoxEstadoCita.SelectedItem = row.Cells["EstadoCita"].Value.ToString();
                dateTimeFechaRegistro.Value = Convert.ToDateTime(row.Cells["FechaRegistro"].Value);
                
                // Convertir a TimeSpan
                TimeSpan horaCita = (TimeSpan)row.Cells["HoraCita"].Value;
                dateTimeFechaCita.Value = DateTime.Today.Add(horaCita);
                
                string estadoTexto = row.Cells["Estado"].Value.ToString();

                // Convertir estado de texto a CheckBox
                checkBoxActivo.Checked = estadoTexto == "Activo";
                checkBoxInactivo.Checked = estadoTexto == "Inactivo";

                modoEdicion = true; // Activar modo de edición
            }
        }
        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (modoEdicion && idCitaEditar > 0)
            {
                if (ValidarDatos())
                {
                    ActualizarModeloDesdeUI();

                    if (citaControlador.ActualizarCitas(citaModelo))
                    {
                        MessageBox.Show("Cita actualizado correctamente.");
                        LimpiarCampos();
                        CargarCitas();
                        modoEdicion = false; // Salir del modo edición
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el cita. Verifique los datos y vuelva a intentarlo.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cita para editar.");
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (idCitaEditar > 0)
            {
                var confirmacion = MessageBox.Show("¿Está seguro de eliminar este cita?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    if (citaControlador.EliminarCitas(idCitaEditar))
                    {
                        MessageBox.Show("Cita eliminado correctamente.");
                        LimpiarCampos();
                        CargarCitas();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el cita. Verifique los datos y vuelva a intentarlo.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cita para eliminar.");
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
