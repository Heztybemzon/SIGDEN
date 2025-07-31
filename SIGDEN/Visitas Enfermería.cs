using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SIGDEN
{
    public partial class Visitas_Enfermería : Form
    {
        private MySqlConnection sql = new MySqlConnection("server=shinkansen.proxy.rlwy.net; port= 14286; database=Enfermeria; uid=root; pwd=VaLRVjVGLaRaBSJoPxZrDHXgXSnNoxRF;");
        public Visitas_Enfermería()
        {
            InitializeComponent();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtpaciente_id.Text) || string.IsNullOrWhiteSpace(txtfecha_visita.Text) || string.IsNullOrWhiteSpace(txtmotivo.Text) || string.IsNullOrWhiteSpace(txtmedicamento_administrado.Text) )
            {
                MessageBox.Show("Por favor complete el formulario para poder continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                sql.Open();

                string query = "INSERT INTO visitas_enfermeria (paciente_id, fecha_visita, motivo, medicamento_administrado) VALUES " + "(@paciente_id, @fecha_visita, @motivo, medicamento_administrado)";


                using (MySqlCommand cmd = new MySqlCommand(query, sql))
                {
                    cmd.Parameters.AddWithValue("@paciente_id", txtpaciente_id.Text);
                    cmd.Parameters.AddWithValue("@fecha_visita", txtfecha_visita.Text);
                    cmd.Parameters.AddWithValue("@motivo", txtmotivo.Text);
                    cmd.Parameters.AddWithValue("@medicamento_administrado", txtmedicamento_administrado.Text);
                  
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Los Datos Han Sido Ingresados Con Exito", "Mensaje Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                txtpaciente_id.Clear();
                txtfecha_visita.Clear();
                txtmotivo.Clear();
                txtmedicamento_administrado.Clear();
               

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al registrar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sql.Close();
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtpaciente_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void Visitas_Enfermería_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
