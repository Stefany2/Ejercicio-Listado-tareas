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
    public partial class INICIAR : Form
    { 
         // Definir la cadena de conexión a la base de datos
        private string connectionString = @"Data Source=(localdb)\senati;Initial Catalog=login;Integrated Security=True";
    
        public INICIAR()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void textboxUsuario_TextChanged(object sender, EventArgs e)
        {
            // ingresar correo de usuario 

        }

        private void INICIAR_Load(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Si el CheckBox está marcado, mostrar la contraseña
            if (checkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = false; // Mostrar la contraseña
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true; // Ocultar la contraseña
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Obtener los valores ingresados por el usuario
            string correoElectronico = textboxUsuario.Text;
            string contrasena = txtPassword.Text;

            // Validar que se ingresen ambos campos
            if (string.IsNullOrEmpty(correoElectronico) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor ingrese su correo electrónico y contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string query = "INSERT INTO USUARIOS (CORREO_ELECTRONICO, CONTRASEÑA) VALUES (@CorreoElectronico, @Contrasena)";

                    // Crear el comando SQL
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agregar parámetros para evitar la inyección de SQL
                        command.Parameters.AddWithValue("@CorreoElectronico", correoElectronico);
                        command.Parameters.AddWithValue("@Contrasena", contrasena);

                        // Ejecutar la consulta SQL
                        int rowsAffected = command.ExecuteNonQuery();

                        // Verificar si se insertaron los datos correctamente
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Usuario registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Redireccionar al formulario Form5
                            Form4 form4 = new Form4();
                            form4.Show();
                            this.Hide(); // Opcional: Ocultar el formulario actual
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //olvido contraseña

                // Crear una instancia del formulario Form3
               Form3 form3 = new Form3();

                // Mostrar el formulario Form3
                form3.Show();

                // Opcional: Ocultar el formulario actual
                this.Hide();
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // CREAR UNA CUENTA
            // Crear una instancia del formulario Form2
            Form2 form2 = new Form2();

            // Mostrar el formulario Form2
            form2.Show();

            // Opcional: Cerrar el formulario actual
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario actual
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            // Minimizar el formulario
            this.WindowState = FormWindowState.Minimized;
        }

        private void INICIAR_MouseMove(object sender, MouseEventArgs e)
        {
          
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
