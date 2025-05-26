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
    public partial class Tabla_Pacientes : Form
    {
        private MySqlConnection sql = new MySqlConnection("server=shinkansen.proxy.rlwy.net; port= 14286; database=Enfermeria; uid=root; pwd=VaLRVjVGLaRaBSJoPxZrDHXgXSnNoxRF;");
        public Tabla_Pacientes()
        {
            InitializeComponent();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            //Btn Agregar
            if (string.IsNullOrWhiteSpace(txtnombre.Text) || string.IsNullOrWhiteSpace(txtapellido.Text) || string.IsNullOrWhiteSpace(txtpadretutor.Text) || string.IsNullOrWhiteSpace(txtfechaatencion.Text) || string.IsNullOrWhiteSpace(txttelefonopadre.Text)
                || string.IsNullOrWhiteSpace(txtdiagnostico.Text) || string.IsNullOrWhiteSpace(txttratamiento.Text) || string.IsNullOrWhiteSpace(txtobservacion.Text) || string.IsNullOrWhiteSpace(txtretiradopor.Text) || string.IsNullOrWhiteSpace(txtcurso.Text) || string.IsNullOrWhiteSpace(txtfechanac.Text) )
            {
                MessageBox.Show("Por favor complete el formulario para poder continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                sql.Open();

                string query = "INSERT INTO pacientes (nombre, apellido, padre_tutor, fecha_atencion, telefono_padre_tutor,diagnostico,tratamiento,observacion,retirado_por,rol,sexo,curso,fecha_nacimiento,hora_llegada,hora_salida) VALUES " +"(@nombre, @apellido, @padre_tutor, @fecha_atencion, @telefonopadre,@diagnostico,@tratamiento,@observacion,@retirado,@rol,@sexo,@curso,@fechanac,@horallegada,@horasalida)";

                using (MySqlCommand cmd = new MySqlCommand(query, sql))
                {
                    cmd.Parameters.AddWithValue("@nombre", txtnombre.Text);
                    cmd.Parameters.AddWithValue("@apellido", txtapellido.Text);
                    cmd.Parameters.AddWithValue("@padre_tutor", txtpadretutor.Text);
                    cmd.Parameters.AddWithValue("@fecha_atencion", txtfechaatencion.Text);
                    cmd.Parameters.AddWithValue("@telefonopadre", txttelefonopadre.Text);
                    cmd.Parameters.AddWithValue("@diagnostico", txtdiagnostico.Text);
                    cmd.Parameters.AddWithValue("@tratamiento", txttratamiento.Text);
                    cmd.Parameters.AddWithValue("@observacion", txtobservacion.Text);
                    cmd.Parameters.AddWithValue("@retirado", txtretiradopor.Text);
                    cmd.Parameters.AddWithValue("@rol", cmbrol.Text);
                    cmd.Parameters.AddWithValue("@sexo", cmbsexo.Text);
                    cmd.Parameters.AddWithValue("@curso", txtcurso.Text);
                    cmd.Parameters.AddWithValue("@fechanac", txtfechanac.Text);
                    cmd.Parameters.AddWithValue("@horallegada", cmbhorallegada.Text);
                    cmd.Parameters.AddWithValue("@horasalida", cmbhorasalida.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Los Datos Han Sido Ingresados Con Exito", "Mensaje Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                txtnombre.Clear();
                txtapellido.Clear();
                txtpadretutor.Clear();
                txtfechaatencion.Clear();
                txttelefonopadre.Clear();
                txtdiagnostico.Clear();
                txttratamiento.Clear();
                txtobservacion.Clear();
                txtretiradopor.Clear();
                txtcurso.Clear();
                txtfechanac.Clear();
               
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
