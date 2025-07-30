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
    public partial class Tabla_Medicamentos_Administrados : Form
    {
        private MySqlConnection sql = new MySqlConnection("server=shinkansen.proxy.rlwy.net; port= 14286; database=Enfermeria; uid=root; pwd=VaLRVjVGLaRaBSJoPxZrDHXgXSnNoxRF;");
        public Tabla_Medicamentos_Administrados()
        {
               InitializeComponent();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            //Btn Agregar
            if (string.IsNullOrWhiteSpace(txt_paciente_id.Text) || string.IsNullOrWhiteSpace(txt_medicamento_id.Text) || string.IsNullOrWhiteSpace(txt_cantidad_administrada.Text) || string.IsNullOrWhiteSpace(txt_fecha_administracion.Text) || string.IsNullOrWhiteSpace(txt_obsevaciones.Text))
            {
                MessageBox.Show("Por favor complete el formulario para poder continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                sql.Open();

                string query = "INSERT INTO medicamentos_administrados (paciente_id, medicamento_id, cantidad_administrada, fecha_administracion, observaciones) VALUES " + "(@paciente_id, @medicamento_id, @cantidad_administrada, @fecha_administracion, @observaciones)";

                using (MySqlCommand cmd = new MySqlCommand(query, sql))
                {
                    cmd.Parameters.AddWithValue("@paciente_id", txt_paciente_id.Text);
                    cmd.Parameters.AddWithValue("@medicamento_id", txt_medicamento_id.Text);
                    cmd.Parameters.AddWithValue("@cantidad_administrada", txt_cantidad_administrada.Text);
                    cmd.Parameters.AddWithValue("@fecha_administracion", txt_fecha_administracion.Text);
                    cmd.Parameters.AddWithValue("@observaciones", txt_obsevaciones.Text);
                 
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Los Datos Han Sido Ingresados Con Exito", "Mensaje Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                txt_paciente_id.Clear();
                txt_medicamento_id.Clear();
                txt_cantidad_administrada.Clear();
                txt_fecha_administracion.Clear();
                txt_obsevaciones.Clear();


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al registrar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sql.Close();
            }






            //Fin Btn
        }
    }

    }

