using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Form2 : Form
    {
        // Cadena de conexión a la base de datos
        private string connectionString = @"Data Source=(localdb)\senati;Initial Catalog=login;Integrated Security=True";

        public Form2()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            // Obtener los valores ingresados por el usuario
            string nombre = textboxNombre.Text;
            string apellido = textboxApellido.Text;
            string numeroTelefonico = textboxNumeroTelefonico.Text;
            string nuevaContrasena = textboxPass.Text;
            string fechaNacimiento = textboxFecha.Text;

            // Validar que se ingresen todos los campos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(numeroTelefonico) || string.IsNullOrEmpty(nuevaContrasena) || string.IsNullOrEmpty(fechaNacimiento))
            {
                MessageBox.Show("Por favor complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear la conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crear la consulta SQL para insertar los datos
                    string query = "INSERT INTO registrarse (nombres, apellidos, numero_telefonico, nueva_contraseña, fecha_nacimiento) VALUES (@nombres, @apellidos, @numerotelefonico, @nuevacontrasena, @fechanacimiento)";

                    // Crear el comando SQL
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agregar parámetros para evitar la inyección de SQL
                        command.Parameters.AddWithValue("@nombres", nombre);
                        command.Parameters.AddWithValue("@apellidos", apellido);
                        command.Parameters.AddWithValue("@numerotelefonico", numeroTelefonico);
                        command.Parameters.AddWithValue("@nuevacontrasena", nuevaContrasena);
                        command.Parameters.AddWithValue("@fechanacimiento", fechaNacimiento);

                        // Ejecutar la consulta SQL
                        int rowsAffected = command.ExecuteNonQuery();

                        // Verificar si se insertaron los datos correctamente
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("El usuario ha sido registrado exitosamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Cerrar el formulario actual
                            this.Close();

                            // Abrir el formulario "INICIAR"
                            INICIAR iniciarForm = new INICIAR();
                            iniciarForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Error al registrar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textboxNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void textboxCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void textboxPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void textboxFecha_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Si el CheckBox está marcado, mostrar la contraseña
            if (checkBox1.Checked)
            {
                textboxPass.UseSystemPasswordChar = false; // Mostrar la contraseña
            }
            else
            {
                textboxPass.UseSystemPasswordChar = true; // Ocultar la contraseña
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Obtener la fecha seleccionada del DateTimePicker
            DateTime fechaSeleccionada = dateTimePicker1.Value;

            // Mostrar la fecha seleccionada en el TextBox
            textboxFecha.Text = fechaSeleccionada.ToShortDateString();
        }
    }
}
