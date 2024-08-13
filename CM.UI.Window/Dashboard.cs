using CM.UI.Window.Formulario;
using CM.UI.Windows.Formulario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CM.UI.Window
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void btnCerrar_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void btnMaximizar_Click(object sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Maximized;
        btnMaximizar.Visible = false;
        btnRestaurar.Visible = true;
    }

    private void btnRestaurar_Click(object sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Normal;
        btnRestaurar.Visible = false;
        btnMaximizar.Visible = true;
    }

    private void btnMinimizar_Click(object sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Minimized;
    }


    [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
    private extern static void ReleaseCapture();
    [DllImport("user32.DLL", EntryPoint = "SendMessage")]

    private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

    private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
    {
        ReleaseCapture();
        SendMessage(this.Handle, 0x112, 0xf012, 0);
    }



    private void btnsalir_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
        private void AbrirFormEnPanel(Form formHija)
        {
            // Verificar si el formulario hijo ya está abierto
            if (panelContenedor.Controls.Count > 0 && panelContenedor.Controls[0] is Form formActual && formActual.GetType() == formHija.GetType())
            {
                // Si es el mismo tipo de formulario, no hacer nada
                return;
            }

            // Preparar el formulario hijo
            formHija.TopLevel = false;
            formHija.FormBorderStyle = FormBorderStyle.None;
            formHija.Dock = DockStyle.Fill;

            // Limpiar el panel y agregar el formulario hijo
            panelContenedor.Controls.Clear();
            panelContenedor.Controls.Add(formHija);
            formHija.Show();
        }


        private void btnproductos_Click(object sender, EventArgs e)
    {
        AbrirFormEnPanel(new FormPaciente());
    }
 
        private void btnMedicos_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormMedico());

        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormCitas());

        }

        private void btnConsultorios_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormConsultorio());
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormEspecialidades());

        }

        private void horafecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btnHorarios_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormHorario());

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormHome());

        }
    }
}
