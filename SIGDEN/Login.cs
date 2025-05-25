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

        private void btnIniciarSesión_Click(object sender, EventArgs e)
        {
            con.Open();
            string iniciar_sesion = "SELECT * FROM [user] WHERE usuario = '" + txtUsuario.Text + "' AND contraseña = '" + txtContraseña.Text + "'";
            cmd = new OleDbCommand(iniciar_sesion, con);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                new FrmHome().Show();
                this.Hide();
            }
            else
                MessageBox.Show("Nombre de usuario o contraseña no válidos", "Error de inicio de sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            txtUsuario.Focus();
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

    }
}