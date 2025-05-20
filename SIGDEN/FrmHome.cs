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
    public partial class FrmHome : Form
    {
        bool sidebarExpand;

        public FrmHome()
        {
            InitializeComponent();
            customizeDesing();
        }

        private void customizeDesing()
        {
            PanelSubMenu.Visible = false;
        }

        private void hideSubMenu()
        {
            if (PanelSubMenu.Visible == true)
                PanelSubMenu.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void BtnBDD_Click(object sender, EventArgs e)
        {
            showSubMenu(PanelSubMenu);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //Códigos para llamar al formulario 
            hideSubMenu();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            //Códigos para llamar al formulario 
            hideSubMenu();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            //Códigos para llamar al formulario 
            hideSubMenu();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                Sidebar.Width -= 15;

                if (Sidebar.Width <= Sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    timer1.Stop();
                }
            }
            else
            {
                Sidebar.Width += 30;

                if (Sidebar.Width >= Sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    timer1.Stop();
                }
            }
        }

        private void menuButtom_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
            }

            timer1.Start();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void guna2Button8_Click(object sender, EventArgs e)
        {
            guna2Button8.TextAlign = HorizontalAlignment.Center;
            guna2Button8.ImageAlign = HorizontalAlignment.Center;
       

        }
    }
}
