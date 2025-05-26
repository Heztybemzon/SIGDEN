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
    public partial class FrmMedicamentos : Form
    {
        public FrmMedicamentos()
        {
            InitializeComponent();
           
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2PictureBox1.Controls.Clear();
            guna2PictureBox2.Visible = false;
            guna2PictureBox3.Visible = false;
            guna2PictureBox4.Visible = false;
            guna2PictureBox6.Visible = false;
            guna2Button1.Visible = false;
            guna2Button5.Visible = false;
            guna2Button6.Visible = false;
            guna2Button7.Visible = false;
            guna2Button8.Visible = false;
            guna2ShadowPanel1.Visible = false;
            guna2ShadowPanel2.Visible = false;
            Analgesicos formulario = new Analgesicos();
            formulario.TopLevel = false;
            formulario.Dock = DockStyle.Fill;
            guna2PictureBox1.Controls.Add(formulario);
            formulario.Show();
            
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            guna2PictureBox1.Controls.Clear();
            guna2PictureBox2.Visible = false;
            guna2PictureBox3.Visible = false;
            guna2PictureBox4.Visible = false;
            guna2PictureBox6.Visible = false;
            guna2Button1.Visible = false;
            guna2Button5.Visible = false;
            guna2Button6.Visible = false;
            guna2Button7.Visible = false;
            guna2Button8.Visible = false;
            guna2ShadowPanel1.Visible = false;
            guna2ShadowPanel2.Visible = false;
            Antialergicos formulario = new Antialergicos();
            formulario.TopLevel = false;
            formulario.Dock = DockStyle.Fill;
            guna2PictureBox1.Controls.Add(formulario);
            formulario.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            guna2PictureBox1.Controls.Clear();
            guna2PictureBox2.Visible = false;
            guna2PictureBox3.Visible = false;
            guna2PictureBox4.Visible = false;
            guna2PictureBox6.Visible = false;
            guna2Button1.Visible = false;
            guna2Button5.Visible = false;
            guna2Button6.Visible = false;
            guna2Button7.Visible = false;
            guna2Button8.Visible = false;
            guna2ShadowPanel1.Visible = false;
            guna2ShadowPanel2.Visible = false;
            Material_de_Primeros_Auxilios  formulario = new Material_de_Primeros_Auxilios();
            formulario.TopLevel = false;
            formulario.Dock = DockStyle.Fill;
            guna2PictureBox1.Controls.Add(formulario);
            formulario.Show();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            guna2PictureBox1.Controls.Clear();
            guna2PictureBox2.Visible = false;
            guna2PictureBox3.Visible = false;
            guna2PictureBox4.Visible = false;
            guna2PictureBox6.Visible = false;
            guna2Button1.Visible = false;
            guna2Button5.Visible = false;
            guna2Button6.Visible = false;
            guna2Button7.Visible = false;
            guna2Button8.Visible = false;
            guna2ShadowPanel1.Visible = false;
            guna2ShadowPanel2.Visible = false;
            Gastro_Protectores formulario = new Gastro_Protectores();
            formulario.TopLevel = false;
            formulario.Dock = DockStyle.Fill;
            guna2PictureBox1.Controls.Add(formulario);
            formulario.Show();
        }
    }
}
