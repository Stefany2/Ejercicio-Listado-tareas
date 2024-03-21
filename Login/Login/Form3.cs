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
    public partial class Form3 : Form
    {
       // Definir la cadena de conexión a la base de datos
        private string connectionString = @"Data Source=(localdb)\senati;Initial Catalog=login;Integrated Security=True";

        public Form3()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Obtener el código de recuperación y la nueva contraseña
            string codigoRecuperacion = textboxCodigo.Text;
            string nuevaContraseña = textboxRecuperar.Text;

            // Crear la conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connection.Open();

                    // Actualizar la contraseña en la tabla "usuarios" basada en el código de recuperación
                    string updateQuery = "UPDATE usuarios SET CONTRASEÑA = @nuevaContraseña WHERE CORREO_ELECTRONICO = (SELECT CORREO_ELECTRONICO   FROM recuperar WHERE codigo = @codigoRecuperacion)";
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                    {
                        // Agregar parámetros para evitar la inyección de SQL
                        updateCommand.Parameters.AddWithValue("@nuevaContraseña", nuevaContraseña);
                        updateCommand.Parameters.AddWithValue("@codigoRecuperacion", codigoRecuperacion);

                        // Ejecutar la consulta de actualización
                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        // Verificar si se actualizó la contraseña en la tabla de usuarios
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("La contraseña se actualizó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar la contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Salir del método si la actualización falló
                        }
                    }

                    // Ahora, puedes insertar la nueva contraseña en la tabla "recuperar"
                    string insertQuery = "INSERT INTO recuperar (codigo, nueva_contraseña) VALUES (@codigo, @nuevaContraseña)";
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        // Agregar parámetros para evitar la inyección de SQL
                        insertCommand.Parameters.AddWithValue("@codigo", codigoRecuperacion);
                        insertCommand.Parameters.AddWithValue("@nuevaContraseña", nuevaContraseña);

                        // Ejecutar la consulta de inserción
                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        // Verificar si se insertaron los datos correctamente en la tabla "recuperar"
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Los datos se guardaron correctamente en la tabla 'recuperar'.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error al guardar los datos en la tabla 'recuperar'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Si el CheckBox está marcado, mostrar la contraseña
            if (checkBox1.Checked)
            {
                textboxRecuperar.UseSystemPasswordChar = false; // Mostrar la contraseña
            }
            else
            {
                textboxRecuperar.UseSystemPasswordChar = true; // Ocultar la contraseña
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
