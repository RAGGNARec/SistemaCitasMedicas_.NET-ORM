using CM.Dominio.Modelo.Entidades;
using CM.UI.Window.ControladorAplicacion;
using CM.UI.Window.VistaModelo;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CM.UI.Window.Formulario
{
    public partial class FormMedico : Form
    {
        private MedicoControlador medicoControlador;
        private MedicoVistaModelo medicoModelo;
        private ConsultorioControlador consultorioControlador;
        private bool modoEdicion = false;
        private int idMedicoEditar = 0;

        public FormMedico()
        {
            InitializeComponent();
            medicoControlador = new MedicoControlador();
            medicoModelo = new MedicoVistaModelo();
            consultorioControlador = new ConsultorioControlador();

        }

        private void FormMedico_Load(object sender, EventArgs e)
        {
            CargarMedicos();
            CargarConsultorios();
        }

        private void CargarMedicos()
        {
            dataGridViewMedicos.DataSource = null;
            var medicos = medicoControlador.ObtenerMedicos();

            DataTable medicosTable = new DataTable();
            medicosTable.Columns.Add("IdMedico", typeof(int));
            medicosTable.Columns.Add("Nombre", typeof(string));
            medicosTable.Columns.Add("Apellido", typeof(string));
            medicosTable.Columns.Add("Direccion", typeof(string));
            medicosTable.Columns.Add("Telefono", typeof(string));
            medicosTable.Columns.Add("Correo", typeof(string));
            medicosTable.Columns.Add("CodigoMedico", typeof(string));
            medicosTable.Columns.Add("NombreConsultorio", typeof(string)); // Mostrar el nombre del consultorio en lugar de IdConsultorio
            medicosTable.Columns.Add("Estado", typeof(string));

            foreach (var medico in medicos)
            {
                DataRow row = medicosTable.NewRow();
                row["IdMedico"] = medico.IdMedico;
                row["Nombre"] = medico.Nombre;
                row["Apellido"] = medico.Apellido;
                row["Direccion"] = medico.Direccion;
                row["Telefono"] = medico.Telefono;
                row["Correo"] = medico.Correo;
                row["CodigoMedico"] = medico.CodigoMedico;

                // Obtener el nombre del consultorio desde el controlador de consultorios
                var consultorio = consultorioControlador.ObtenerConsultorioPorId(medico.IdConsultorio);
                row["NombreConsultorio"] = consultorio != null ? consultorio.ubicacion : ""; // Asumiendo que "Descripcion" es el campo que contiene el nombre del consultorio

                row["Estado"] = medico.Estado == 1 ? "Activo" : "Inactivo";
                medicosTable.Rows.Add(row);
            }

            dataGridViewMedicos.DataSource = medicosTable;
        }


        private void CargarConsultorios()
        {
            var consultorios = consultorioControlador.ObtenerConsultorios().ToList();

            // Agregar el texto "Seleccione una Consulta" como primer elemento
            consultorios.Insert(0, new ConsultorioVistaModelo { Ubicacion = "Seleccione una Consulta", IdConsultorio = 0 });

            comboBoxConsultorio.DataSource = consultorios;
            comboBoxConsultorio.DisplayMember = "Ubicacion"; // Mostrar la Ubicacion del consultorio
            comboBoxConsultorio.ValueMember = "IdConsultorio";
        }


        private void LimpiarCampos()
        {
            idMedicoEditar = 0;
            modoEdicion = false;
            LimpiarControl(groupBox1.Controls);
            checkBoxActivo.Checked = false;
            checkBoxInactivo.Checked = false;

            // Seleccionar el texto por defecto "Seleccione una Consulta"
            comboBoxConsultorio.SelectedIndex = 0;
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
                    LimpiarControl(control.Controls);
                }
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(textNombre.Text) ||
                string.IsNullOrWhiteSpace(textApellido.Text) ||
                comboBoxConsultorio.SelectedIndex == -1 ||
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
            medicoModelo.Nombre = textNombre.Text;
            medicoModelo.Apellido = textApellido.Text;
            medicoModelo.IdConsultorio = (int)comboBoxConsultorio.SelectedValue;
            medicoModelo.Direccion = textDireccion.Text;
            medicoModelo.Telefono = textTelefono.Text;
            medicoModelo.Correo = textCorreo.Text;
            medicoModelo.CodigoMedico = textCodigoMedico.Text;
            medicoModelo.Estado = checkBoxActivo.Checked ? 1 : 0;

            if (modoEdicion)
            {
                medicoModelo.IdMedico = idMedicoEditar;
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                ActualizarModeloDesdeUI();

                if (modoEdicion)
                {
                    if (medicoControlador.ActualizarMedico(medicoModelo))
                    {
                        MessageBox.Show("Médico actualizado correctamente.");
                        LimpiarCampos();
                        CargarMedicos();
                        modoEdicion = false;
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el médico. Verifique los datos y vuelva a intentarlo.");
                    }
                }
                else
                {
                    if (medicoControlador.InsertarMedico(medicoModelo))
                    {
                        MessageBox.Show("Médico insertado correctamente.");
                        LimpiarCampos();
                        CargarMedicos();
                    }
                    else
                    {
                        MessageBox.Show("Error al insertar el médico. Verifique los datos y vuelva a intentarlo.");
                    }
                }
            }
        }

        private void buttonCancelar_Click_1(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dataGridViewMedicos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewMedicos.Rows[e.RowIndex];
                idMedicoEditar = Convert.ToInt32(row.Cells["IdMedico"].Value);
                textNombre.Text = row.Cells["Nombre"].Value.ToString();
                textApellido.Text = row.Cells["Apellido"].Value.ToString();
                textDireccion.Text = row.Cells["Direccion"].Value.ToString();
                textTelefono.Text = row.Cells["Telefono"].Value.ToString();
                textCorreo.Text = row.Cells["Correo"].Value.ToString();
                textCodigoMedico.Text = row.Cells["CodigoMedico"].Value.ToString();
                string estadoTexto = row.Cells["Estado"].Value.ToString();

                // Obtener el nombre del consultorio y seleccionarlo en el ComboBox
                string nombreConsultorio = row.Cells["NombreConsultorio"].Value.ToString();
                var consultorioSeleccionado = comboBoxConsultorio.Items.Cast<ConsultorioVistaModelo>().FirstOrDefault(c => c.Ubicacion == nombreConsultorio);

                if (consultorioSeleccionado != null)
                {
                    comboBoxConsultorio.SelectedItem = consultorioSeleccionado;
                }
                else
                {
                    comboBoxConsultorio.SelectedIndex = -1;
                    MessageBox.Show("Error al obtener el consultorio del médico seleccionado.");
                }

                checkBoxActivo.Checked = estadoTexto == "Activo";
                checkBoxInactivo.Checked = estadoTexto == "Inactivo";

                modoEdicion = true;
            }
        }



        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (modoEdicion && idMedicoEditar > 0)
            {
                if (ValidarDatos())
                {
                    ActualizarModeloDesdeUI();

                    if (medicoControlador.ActualizarMedico(medicoModelo))
                    {
                        MessageBox.Show("Médico actualizado correctamente.");
                        LimpiarCampos();
                        CargarMedicos();
                        modoEdicion = false;
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el médico. Verifique los datos y vuelva a intentarlo.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un médico para editar.");
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (idMedicoEditar > 0)
            {
                var confirmacion = MessageBox.Show("¿Está seguro de eliminar este médico?", "Confirmar Eliminación", MessageBoxButtons.YesNo);
                if (confirmacion == DialogResult.Yes)
                {
                    if (medicoControlador.EliminarMedico(idMedicoEditar))
                    {
                        MessageBox.Show("Médico eliminado correctamente.");
                        LimpiarCampos();
                        CargarMedicos();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el médico.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un médico para eliminar.");
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
