using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGDEN
{
    public partial class FrmProgressBar : Form
    {
        int progreso = 0;
        public FrmProgressBar()
        {
            InitializeComponent();
        }

        private void FrmProgressBar_Load(object sender, EventArgs e)
        {
            timer1.Start();
            this.BackColor = Color.White; // o el color que quieras
            this.TransparencyKey = Color.Lime; // clave para "recortar" fondo
            this.FormBorderStyle = FormBorderStyle.None; // sin bordes
        }

        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {
            if (progreso < 100)
            {
                progreso += 1;
                guna2CircleProgressBar1.Value = progreso;
                guna2CircleProgressBar1.Text = progreso.ToString() + "%"; // Opcional
            }
            else
            {
                timer1.Stop(); // Detiene el Timer al llegar al 100%
            }
        }
    }
}
