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
        Point posicionOriginal;
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
            panelContainer.Controls.Clear();
            panelContainer.Location = posicionOriginal;
            panelContainer.Left += 170;
            Tabla_Pacientes formulario = new Tabla_Pacientes();
            formulario.TopLevel = false;
            formulario.Dock = DockStyle.Fill;


            panelContainer.Controls.Add(formulario);
            formulario.Show();
            hideSubMenu();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            panelContainer.Location = posicionOriginal;
            panelContainer.Left += 400;

            Visitas_Enfermería formulario = new Visitas_Enfermería();
            formulario.TopLevel = false;
            formulario.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(formulario);
            formulario.Show();
            hideSubMenu();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            panelContainer.Location = posicionOriginal;
            panelContainer.Left += 400;

            Tabla_Medicamentos formulario = new Tabla_Medicamentos();
            formulario.TopLevel = false;
            formulario.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(formulario);
            formulario.Show();
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

       


        //Para la transición de la barra despegable
        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                Sidebar.Width -= 25;

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Fecha.Text = DateTime.Now.ToString("hh:mm:ss");
            this.Hora.Text = DateTime.Now.ToLongDateString();
        }

        private void BtnMedicamento_Click(object sender, EventArgs e)
        {
             
            panelContainer.Controls.Clear();
            FrmMedicamentos formulario = new FrmMedicamentos();
            formulario.TopLevel = false;
            formulario.Dock = DockStyle.Fill;


            panelContainer.Controls.Add(formulario);
            formulario.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            panelContainer.Location = posicionOriginal;
            panelContainer.Left += 18;
            FrmSobreNostros formulario = new FrmSobreNostros();
            formulario.TopLevel = false;
            formulario.Dock = DockStyle.Fill;


            panelContainer.Controls.Add(formulario);
            formulario.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FrmHome S = new FrmHome();
            S.Show();
        }

        private void guna2Panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            panelContainer.Location = posicionOriginal;
            panelContainer.Left += 400;

            Tabla_Fecha_Médica formulario = new Tabla_Fecha_Médica();
            formulario.TopLevel = false;
            formulario.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(formulario);
            formulario.Show();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            panelContainer.Location = posicionOriginal;
            panelContainer.Left += 400;
            Tabla_Medicamentos formulario = new Tabla_Medicamentos();
            formulario.TopLevel = false;
            formulario.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(formulario);
            formulario.Show();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            posicionOriginal = panelContainer.Location;
        }
    }
    }