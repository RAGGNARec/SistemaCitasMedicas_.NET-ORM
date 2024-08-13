using CM.UI.Window.ControladorAplicacion;
using CM.UI.Window.VistaModelo;
using System;
using System.Data;
using System.Windows.Forms;

namespace CM.UI.Window.Formulario
{
    public partial class FormConsultorio : Form
    {
        private ConsultorioControlador consultorioControlador;
        private ConsultorioVistaModelo consultorioModelo;
        private bool modoEdicion = false;
        private int idConsultorioEditar = 0;
        public FormConsultorio()
        {
            InitializeComponent();
            consultorioControlador = new ConsultorioControlador();
            consultorioModelo = new ConsultorioVistaModelo();
        }

        private void FormConsultorio_Load(object sender, EventArgs e)
        {
            CargarConsultorios();

        }

        private void CargarConsultorios()
        {
            dataGridViewConsultorios.DataSource = null;
            var consultorios = consultorioControlador.ObtenerConsultorios();

            DataTable consultoriosTable = new DataTable();
            consultoriosTable.Columns.Add("IdConsultorio", typeof(int));
            consultoriosTable.Columns.Add("Ubicacion", typeof(string));
            consultoriosTable.Columns.Add("Descripcion", typeof(string));
            consultoriosTable.Columns.Add("Estado", typeof(string)); // Columna de texto para mostrar "Activo" o "Inactivo"

            foreach (var consultorio in consultorios)
            {
                DataRow row = consultoriosTable.NewRow();
                row["IdConsultorio"] = consultorio.IdConsultorio;
                row["Ubicacion"] = consultorio.Ubicacion;
                row["Descripcion"] = consultorio.Descripcion;
                row["Estado"] = consultorio.Estado == 1 ? "Activo" : "Inactivo"; // Convertir aquí
                consultoriosTable.Rows.Add(row);
            }

            dataGridViewConsultorios.DataSource = consultoriosTable;
        }

        private void LimpiarCampos()
        {
            idConsultorioEditar = 0; // Asegurando que idConsultorioEditar se inicialice correctamente
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
            if (string.IsNullOrWhiteSpace(textUbicacion.Text) ||
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
            consultorioModelo.Ubicacion = textUbicacion.Text;
            consultorioModelo.Descripcion= textDescripcion.Text;
            consultorioModelo.Estado = checkBoxActivo.Checked ? 1 : 0; // Convertir estado de CheckBox a valor numérico

            if (modoEdicion)
            {
                consultorioModelo.IdConsultorio = idConsultorioEditar;
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
                    if (consultorioControlador.ActualizarConsultorio(consultorioModelo))
                    {
                        MessageBox.Show("Consultorio actualizado correctamente.");
                        LimpiarCampos();
                        CargarConsultorios();
                        modoEdicion = false; // Salir del modo edición
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el consultorio. Verifique los datos y vuelva a intentarlo.");
                    }
                }
                else
                {
                    // Modo inserción
                    if (consultorioControlador.InsertarConsultorio(consultorioModelo))
                    {
                        MessageBox.Show("Consultorio insertado correctamente.");
                        LimpiarCampos();
                        CargarConsultorios();
                    }
                    else
                    {
                        MessageBox.Show("Error al insertar el consultorio. Verifique los datos y vuelva a intentarlo.");
                    }
                }
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dataGridViewConsultorios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewConsultorios.Rows[e.RowIndex];
                idConsultorioEditar = Convert.ToInt32(row.Cells["IdConsultorio"].Value);
                textUbicacion.Text = row.Cells["Ubicacion"].Value.ToString();
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
            if (modoEdicion && idConsultorioEditar > 0)
            {
                if (ValidarDatos())
                {
                    ActualizarModeloDesdeUI();

                    if (consultorioControlador.ActualizarConsultorio(consultorioModelo))
                    {
                        MessageBox.Show("Consultorio actualizado correctamente.");
                        LimpiarCampos();
                        CargarConsultorios();
                        modoEdicion = false; // Salir del modo edición
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el consultorio. Verifique los datos y vuelva a intentarlo.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un consultorio para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idConsultorioEditar > 0)
            {
                var confirmacion = MessageBox.Show("¿Está seguro de eliminar este consultorio?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    if (consultorioControlador.EliminarConsultorio(idConsultorioEditar))
                    {
                        MessageBox.Show("Consultorio eliminado correctamente.");
                        LimpiarCampos();
                        CargarConsultorios();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el consultorio. Verifique los datos y vuelva a intentarlo.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un consultorio para eliminar.");
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

