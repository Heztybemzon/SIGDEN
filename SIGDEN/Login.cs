using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SIGDEN
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        int paso = 0;
        Timer animacionTimer = new Timer();

        private void btnIniciarSesión_Click(object sender, EventArgs e)
        {
            paso = 0;

            // Restablecer el estado inicial de los controles
            PanelPastillas.Left = -PanelPastillas.Width;
            guna2PictureBox1.Width = 150;  // o cualquier tamaño original
            guna2PictureBox1.Height = 150;
            guna2PictureBox1.Left = (this.Width - guna2PictureBox1.Width) / 2;
            guna2PictureBox1.Top = (this.Height - guna2PictureBox1.Height) / 2;

            animacionTimer.Interval = 30;  // Ajusta el intervalo del temporizador a 30 ms
            animacionTimer.Tick += AnimacionTimer_Tick;  // Asocia el evento Tick con el método AnimacionTimer_Tick
            animacionTimer.Start();  // Inicia el temporizador
            con.Open();
            string iniciar_sesion = "SELECT * FROM [user] WHERE usuario = '" + txtUsuario.Text + "' AND contraseña = '" + txtContraseña.Text + "'";
            cmd = new OleDbCommand(iniciar_sesion, con);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                new FrmMedicamentos().Show();
                this.Hide();
            }
            else
                MessageBox.Show("Nombre de usuario o contraseña no válidos", "Error de inicio de sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            txtUsuario.Focus();
        }


        private void AnimacionTimer_Tick(object sender, EventArgs e)
        {
            {
                paso++;

                // Hacer que el formulario se desvanezca
                if (this.Opacity > 0)
                {
                    this.Opacity -= 0.05;  // Decrecer la opacidad del formulario
                }

                if (paso > 60)
                {
                    animacionTimer.Stop();
                    panelLogin.Visible = false;
                    guna2PictureBox2.Visible = true;
                    ProgressBarEmergente.Visible = true;
                    IniciarProgressBar();
                }
            }

        }

        private void cBMostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            if (cBMostrarContraseña.Checked)
            {
                txtContraseña.PasswordChar = '\0';

            }
            else
            {
                txtContraseña.PasswordChar = '·';

            }
        }

        private void txtContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnIniciarSesión.PerformClick();
            }
        }
        private void IniciarProgressBar()
        {
            ProgressBarEmergente.Value = 0;  // Reiniciar la barra de progreso a 0
            Timer progressTimer = new Timer();
            progressTimer.Interval = 100;  // Intervalo de 100ms para incrementar la barra
            progressTimer.Tick += (s, e) =>
            {
                if (ProgressBarEmergente.Value < ProgressBarEmergente.Maximum)
                {
                    ProgressBarEmergente.Value += 1;
                }
                else
                {
                    progressTimer.Stop();  // Detener el temporizador cuando la barra esté llena
                }
            };
            progressTimer.Start();
        }

 
    }
}
