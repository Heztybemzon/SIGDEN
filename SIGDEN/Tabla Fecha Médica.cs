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
    public partial class Tabla_Fecha_Médica : Form
    {
        private MySqlConnection sql = new MySqlConnection("server=shinkansen.proxy.rlwy.net; port= 14286; database=Enfermeria; uid=root; pwd=VaLRVjVGLaRaBSJoPxZrDHXgXSnNoxRF;");
        public Tabla_Fecha_Médica()
        {
            InitializeComponent();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_alergias.Text) || string.IsNullOrWhiteSpace(txtvacunas.Text) || string.IsNullOrWhiteSpace(txtvacunas_faltantes.Text) || string.IsNullOrWhiteSpace(txt_condicion_medica.Text) || string.IsNullOrWhiteSpace(txtasistenciamedica.Text) || string.IsNullOrWhiteSpace(txtpaciente_id.Text))
            {
                MessageBox.Show("Por favor complete el formulario para poder continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                sql.Open();

                string query = "INSERT INTO ficha_medica (alergias, vacunas, vacunas_faltantes, condicion_medica, asistencia_medica, paciente_id) VALUES " + "(@alergias,@vacunas,@vacunas_faltantes, @condicion_medica, @asistencia_medica, @paciente_id)";

                using (MySqlCommand cmd = new MySqlCommand(query, sql))
                {
                    cmd.Parameters.AddWithValue("@alergias", txt_alergias.Text);
                    cmd.Parameters.AddWithValue("@vacunas", txtvacunas.Text);
                    cmd.Parameters.AddWithValue("@vacunas_faltantes", txtvacunas_faltantes.Text);
                    cmd.Parameters.AddWithValue("@condicion_médica", txt_condicion_medica.Text);
                    cmd.Parameters.AddWithValue("@asistencia_medica", txtasistenciamedica.Text);
                    cmd.Parameters.AddWithValue("@paciente_id", txtpaciente_id.Text);
          

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Los Datos Han Sido Ingresados Con Exito", "Mensaje Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                txt_alergias.Clear();
                txtvacunas.Clear();
                txtvacunas_faltantes.Clear();
                txt_condicion_medica.Clear();
                txtasistenciamedica.Clear();
                txtpaciente_id.Clear();

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
    }
}
