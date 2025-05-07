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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void btnIniciarSesión_Click(object sender, EventArgs e)
        {
            con.Open();
            string iniciar_sesion = "SELECT * FROM tbl_users WHERE username= '" + txtUsuario.Text + "' and password= '" + txtUsuario.Text + "'";
            cmd = new OleDbCommand(iniciar_sesion, con);
            OleDbDataReader dr = cmd.ExecuteReader();


        }
    }
}
