using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Runtime.InteropServices;

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

        private void menuButtom_Click(object sender, EventArgs e)
        {
            if (sidebarTimer.Enabled)
            {
                sidebarTimer.Stop();
            }

            sidebarTimer.Start();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private bool estaMaximizado = false;
        private void BtnMaximize_Click(object sender, EventArgs e)
        {


            if (estaMaximizado)
            {
                this.WindowState = FormWindowState.Normal;
                BtnMaximize.Image = Properties.Resources.cuadrado; // tu ícono de maximizar
                estaMaximizado = false;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                BtnMaximize.Image = Properties.Resources.minimizar; // tu ícono de restaurar
                estaMaximizado = true;
            }
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


        //Para la transición de la barra despegable
        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                Sidebar.Width -= 15;

                if (Sidebar.Width <= Sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                Sidebar.Width += 30;

                if (Sidebar.Width >= Sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }

            }

        }
    }

}
