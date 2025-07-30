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
    public partial class Tabla_Medicamentos : Form
    {
        private MySqlConnection sql = new MySqlConnection("server=shinkansen.proxy.rlwy.net; port= 14286; database=Enfermeria; uid=root; pwd=VaLRVjVGLaRaBSJoPxZrDHXgXSnNoxRF;");
        public Tabla_Medicamentos()
        {
            InitializeComponent();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_nombre.Text) || string.IsNullOrWhiteSpace(txt_tipo.Text) || string.IsNullOrWhiteSpace(txt_fecha_de_vencimiento.Text) || string.IsNullOrWhiteSpace(txt_cantidad_disponible.Text))
            {
                MessageBox.Show("Por favor complete el formulario para poder continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                sql.Open();

                string query = "INSERT INTO medicamentos (nombre, tipo, fecha_de_vencimiento, cantidad_disponible) VALUES " + "(@nombre, @tipo, @fecha_vencimiento, @cantidad_disponible)";

                using (MySqlCommand cmd = new MySqlCommand(query, sql))
                {
                    cmd.Parameters.AddWithValue("@nombre", txt_nombre.Text);
                    cmd.Parameters.AddWithValue("@tipo", txt_tipo.Text);
                    cmd.Parameters.AddWithValue("@fecha_vencimiento", txt_fecha_de_vencimiento.Text);
                    cmd.Parameters.AddWithValue("@cantidad_disponible", txt_cantidad_disponible.Text);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Los Datos Han Sido Ingresados Con Exito", "Mensaje Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                txt_nombre.Clear();
                txt_tipo.Clear();
                txt_fecha_de_vencimiento.Clear();
                txt_cantidad_disponible.Clear();
               

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

