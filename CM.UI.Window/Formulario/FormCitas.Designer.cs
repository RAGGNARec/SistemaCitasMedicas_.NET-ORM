using System.Windows.Forms;

namespace CM.UI.Window.Formulario
{
    partial class FormCitas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCitas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.textDescripcion = new System.Windows.Forms.TextBox();
            this.labelCedula = new System.Windows.Forms.Label();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.labelDireccion = new System.Windows.Forms.Label();
            this.labelTelefono = new System.Windows.Forms.Label();
            this.labelCorreo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.dataGridViewCitas = new System.Windows.Forms.DataGridView();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxEstadoCita = new System.Windows.Forms.ComboBox();
            this.checkBoxInactivo = new System.Windows.Forms.CheckBox();
            this.checkBoxActivo = new System.Windows.Forms.CheckBox();
            this.dateTimeFechaRegistro = new System.Windows.Forms.DateTimePicker();
            this.dateTimeFechaCita = new System.Windows.Forms.DateTimePicker();
            this.comboBoxPaciente = new System.Windows.Forms.ComboBox();
            this.comboBoxHorario = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCitas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Honeydew;
            this.label1.Location = new System.Drawing.Point(346, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "DATOS CITAS MEDICAS";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelNombre.ForeColor = System.Drawing.Color.White;
            this.labelNombre.Location = new System.Drawing.Point(350, 38);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(122, 18);
            this.labelNombre.TabIndex = 2;
            this.labelNombre.Text = "Fecha registro:";
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelApellido.ForeColor = System.Drawing.Color.White;
            this.labelApellido.Location = new System.Drawing.Point(30, 150);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(103, 18);
            this.labelApellido.TabIndex = 4;
            this.labelApellido.Text = "Descripcion:";
            // 
            // textDescripcion
            // 
            this.textDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDescripcion.Location = new System.Drawing.Point(33, 169);
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.Size = new System.Drawing.Size(253, 24);
            this.textDescripcion.TabIndex = 3;
            // 
            // labelCedula
            // 
            this.labelCedula.AutoSize = true;
            this.labelCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelCedula.ForeColor = System.Drawing.Color.White;
            this.labelCedula.Location = new System.Drawing.Point(350, 150);
            this.labelCedula.Name = "labelCedula";
            this.labelCedula.Size = new System.Drawing.Size(66, 18);
            this.labelCedula.TabIndex = 6;
            this.labelCedula.Text = "Estado:";
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.BackColor = System.Drawing.Color.SeaGreen;
            this.buttonAgregar.FlatAppearance.BorderSize = 0;
            this.buttonAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgregar.ForeColor = System.Drawing.Color.White;
            this.buttonAgregar.Image = ((System.Drawing.Image)(resources.GetObject("buttonAgregar.Image")));
            this.buttonAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAgregar.Location = new System.Drawing.Point(162, 362);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(113, 35);
            this.buttonAgregar.TabIndex = 7;
            this.buttonAgregar.Text = "NUEVO";
            this.buttonAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAgregar.UseVisualStyleBackColor = false;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // labelDireccion
            // 
            this.labelDireccion.AutoSize = true;
            this.labelDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelDireccion.ForeColor = System.Drawing.Color.White;
            this.labelDireccion.Location = new System.Drawing.Point(30, 206);
            this.labelDireccion.Name = "labelDireccion";
            this.labelDireccion.Size = new System.Drawing.Size(101, 18);
            this.labelDireccion.TabIndex = 11;
            this.labelDireccion.Text = "Estado Cita:";
            // 
            // labelTelefono
            // 
            this.labelTelefono.AutoSize = true;
            this.labelTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelTelefono.ForeColor = System.Drawing.Color.White;
            this.labelTelefono.Location = new System.Drawing.Point(30, 38);
            this.labelTelefono.Name = "labelTelefono";
            this.labelTelefono.Size = new System.Drawing.Size(78, 18);
            this.labelTelefono.TabIndex = 12;
            this.labelTelefono.Text = "Paciente:";
            // 
            // labelCorreo
            // 
            this.labelCorreo.AutoSize = true;
            this.labelCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelCorreo.ForeColor = System.Drawing.Color.White;
            this.labelCorreo.Location = new System.Drawing.Point(30, 95);
            this.labelCorreo.Name = "labelCorreo";
            this.labelCorreo.Size = new System.Drawing.Size(130, 18);
            this.labelCorreo.TabIndex = 13;
            this.labelCorreo.Text = "Horario Medico:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(350, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "Hora cita:";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.DarkOrange;
            this.buttonCancelar.FlatAppearance.BorderSize = 0;
            this.buttonCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.ForeColor = System.Drawing.Color.White;
            this.buttonCancelar.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancelar.Image")));
            this.buttonCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancelar.Location = new System.Drawing.Point(732, 362);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(111, 35);
            this.buttonCancelar.TabIndex = 18;
            this.buttonCancelar.Text = "LIMPIAR";
            this.buttonCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click_1);
            // 
            // dataGridViewCitas
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewCitas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCitas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCitas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.dataGridViewCitas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCitas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewCitas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCitas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewCitas.ColumnHeadersHeight = 30;
            this.dataGridViewCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCitas.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewCitas.EnableHeadersVisualStyles = false;
            this.dataGridViewCitas.GridColor = System.Drawing.Color.SteelBlue;
            this.dataGridViewCitas.Location = new System.Drawing.Point(111, 418);
            this.dataGridViewCitas.Name = "dataGridViewCitas";
            this.dataGridViewCitas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCitas.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewCitas.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewCitas.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewCitas.RowTemplate.Height = 35;
            this.dataGridViewCitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCitas.Size = new System.Drawing.Size(822, 142);
            this.dataGridViewCitas.TabIndex = 20;
            this.dataGridViewCitas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCitas_CellContentClick);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(311, 362);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(107, 35);
            this.btnEditar.TabIndex = 21;
            this.btnEditar.Text = "EDITAR";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click_1);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Crimson;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(448, 362);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(121, 35);
            this.btnEliminar.TabIndex = 22;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox1.Controls.Add(this.comboBoxHorario);
            this.groupBox1.Controls.Add(this.comboBoxPaciente);
            this.groupBox1.Controls.Add(this.comboBoxEstadoCita);
            this.groupBox1.Controls.Add(this.checkBoxInactivo);
            this.groupBox1.Controls.Add(this.checkBoxActivo);
            this.groupBox1.Controls.Add(this.dateTimeFechaRegistro);
            this.groupBox1.Controls.Add(this.dateTimeFechaCita);
            this.groupBox1.Controls.Add(this.labelNombre);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textDescripcion);
            this.groupBox1.Controls.Add(this.labelCorreo);
            this.groupBox1.Controls.Add(this.labelApellido);
            this.groupBox1.Controls.Add(this.labelTelefono);
            this.groupBox1.Controls.Add(this.labelDireccion);
            this.groupBox1.Controls.Add(this.labelCedula);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(194, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(649, 286);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingrese datos de la cita medica";
            // 
            // comboBoxEstadoCita
            // 
            this.comboBoxEstadoCita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstadoCita.FormattingEnabled = true;
            this.comboBoxEstadoCita.Location = new System.Drawing.Point(33, 227);
            this.comboBoxEstadoCita.Name = "comboBoxEstadoCita";
            this.comboBoxEstadoCita.Size = new System.Drawing.Size(209, 24);
            this.comboBoxEstadoCita.TabIndex = 28;
            // 
            // checkBoxInactivo
            // 
            this.checkBoxInactivo.AutoSize = true;
            this.checkBoxInactivo.Location = new System.Drawing.Point(450, 182);
            this.checkBoxInactivo.Name = "checkBoxInactivo";
            this.checkBoxInactivo.Size = new System.Drawing.Size(72, 20);
            this.checkBoxInactivo.TabIndex = 27;
            this.checkBoxInactivo.Text = "Inactivo";
            this.checkBoxInactivo.UseVisualStyleBackColor = true;
            this.checkBoxInactivo.CheckedChanged += new System.EventHandler(this.checkBoxInactivo_CheckedChanged);
            // 
            // checkBoxActivo
            // 
            this.checkBoxActivo.AutoSize = true;
            this.checkBoxActivo.Location = new System.Drawing.Point(355, 182);
            this.checkBoxActivo.Name = "checkBoxActivo";
            this.checkBoxActivo.Size = new System.Drawing.Size(63, 20);
            this.checkBoxActivo.TabIndex = 26;
            this.checkBoxActivo.Text = "Activo";
            this.checkBoxActivo.UseVisualStyleBackColor = true;
            this.checkBoxActivo.CheckedChanged += new System.EventHandler(this.checkBoxActivo_CheckedChanged);
            // 
            // dateTimeFechaRegistro
            // 
            this.dateTimeFechaRegistro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFechaRegistro.Location = new System.Drawing.Point(353, 57);
            this.dateTimeFechaRegistro.Name = "dateTimeFechaRegistro";
            this.dateTimeFechaRegistro.Size = new System.Drawing.Size(200, 22);
            this.dateTimeFechaRegistro.TabIndex = 25;
            // 
            // dateTimeFechaCita
            // 
            this.dateTimeFechaCita.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimeFechaCita.Location = new System.Drawing.Point(353, 116);
            this.dateTimeFechaCita.Name = "dateTimeFechaCita";
            this.dateTimeFechaCita.Size = new System.Drawing.Size(200, 22);
            this.dateTimeFechaCita.TabIndex = 24;
            // 
            // comboBoxPaciente
            // 
            this.comboBoxPaciente.FormattingEnabled = true;
            this.comboBoxPaciente.Location = new System.Drawing.Point(33, 68);
            this.comboBoxPaciente.Name = "comboBoxPaciente";
            this.comboBoxPaciente.Size = new System.Drawing.Size(253, 24);
            this.comboBoxPaciente.TabIndex = 29;
            this.comboBoxPaciente.Text = "Selecciona un Paciente";
            // 
            // comboBoxHorario
            // 
            this.comboBoxHorario.FormattingEnabled = true;
            this.comboBoxHorario.Location = new System.Drawing.Point(33, 123);
            this.comboBoxHorario.Name = "comboBoxHorario";
            this.comboBoxHorario.Size = new System.Drawing.Size(253, 24);
            this.comboBoxHorario.TabIndex = 30;
            this.comboBoxHorario.Text = "Selecciona un Horario Medico";
            // 
            // FormCitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1080, 612);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dataGridViewCitas);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCitas";
            this.Text = "productos";
            this.Load += new System.EventHandler(this.FormCitas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCitas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.TextBox textDescripcion;
        private System.Windows.Forms.Label labelCedula;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Label labelDireccion;
        private System.Windows.Forms.Label labelTelefono;
        private System.Windows.Forms.Label labelCorreo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.DataGridView dataGridViewCitas;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimeFechaCita;
        private System.Windows.Forms.DateTimePicker dateTimeFechaRegistro;
        private System.Windows.Forms.CheckBox checkBoxInactivo;
        private System.Windows.Forms.CheckBox checkBoxActivo;
        private System.Windows.Forms.ComboBox comboBoxEstadoCita;
        private ComboBox comboBoxHorario;
        private ComboBox comboBoxPaciente;
    }
}